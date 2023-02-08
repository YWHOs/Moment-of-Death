using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float lighting;
    [SerializeField] float angle;

    void OnTriggerEnter(Collider _other)
    {
        if(_other.gameObject.tag == "Player")
        {
            _other.GetComponentInChildren<Flashlight>().LightBattery(lighting, angle);
            Destroy(gameObject);
        }
    }
}
