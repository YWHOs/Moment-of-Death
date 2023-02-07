using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] int ammoAmount;
    [SerializeField] AmmoType ammoType;

    void OnTriggerEnter(Collider _other)
    {
        if(_other.gameObject.tag == "Player")
        {
            FindObjectOfType<Ammo>().IncreaseAmmo(ammoType, ammoAmount);
            Destroy(gameObject);
        }
    }
}
