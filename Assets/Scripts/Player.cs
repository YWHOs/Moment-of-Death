using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetDamage(int _damage)
    {
        playerHealth -= _damage;
        if(playerHealth <= 0)
        {
            GetComponent<DeathHandler>().IfDead();
        }
    }
}
