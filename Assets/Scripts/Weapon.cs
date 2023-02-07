using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera camera;
    [SerializeField] float range;
    [SerializeField] int damage;
    [SerializeField] float delay;

    [SerializeField] ParticleSystem particleShoot;
    [SerializeField] GameObject particleHit;
    Ammo ammo;
    [SerializeField] AmmoType ammoType;

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
        if (Input.GetButtonDown("Fire1") && canShoot)
        {
            StartCoroutine(Shoot());
        }
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
