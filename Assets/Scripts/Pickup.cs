using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    void OnTriggerEnter(Collider _other)
    {
        if(_other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
