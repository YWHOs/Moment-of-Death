using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int playerHealth;


    public void GetDamage(int _damage)
    {
        playerHealth -= _damage;
        if(playerHealth <= 0)
        {
            GetComponent<DeathHandler>().IfDead();
        }
    }
}
