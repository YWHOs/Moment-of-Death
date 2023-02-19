using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera camera;
    [SerializeField] float range;
    [SerializeField] int damage;
    [SerializeField] float delay;
    [SerializeField] TextMeshProUGUI ammoText;

    [SerializeField] ParticleSystem particleShoot;
    [SerializeField] GameObject particleHit;
    [SerializeField] AmmoType ammoType;
    Ammo ammo;


    bool canShoot = true;

    void OnEnable()
    {
        canShoot = true;
    }
    void Start()
    {
        ammo = GetComponentInParent<Ammo>();
    }
    // Update is called once per frame
    void Update()
    {
        AmmoUI();
        if (Input.GetButtonDown("Fire1") && canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    void AmmoUI()
    {
        int currentAmmo = ammo.CurrentAmmo(ammoType);
        ammoText.text = currentAmmo.ToString();
    }
    IEnumerator Shoot()
    {
        canShoot = false;
        if (ammo.CurrentAmmo(ammoType) > 0)
        {
            ammo.ReduceAmmo(ammoType);
            particleShoot.Play();
            RayCast();
        }
        yield return new WaitForSeconds(delay);
        canShoot = true;
    }

    void RayCast()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, range))
        {
            // hit particle
            Hit(hit);
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy == null) return;

            enemy.Damage(damage);
        }
        else
        {
            return;
        }
    }
    void Hit(RaycastHit _hit)
    {
        GameObject hit = Instantiate(particleHit, _hit.point, Quaternion.LookRotation(_hit.normal));
        Destroy(hit, 0.1f);
    }

}
