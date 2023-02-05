using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health;

    Player target;
    [SerializeField] int damage;

    void Start()
    {
        target = FindObjectOfType<Player>();
    }

    public void Damage(int _damage)
    {
        health -= _damage;

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void AttackPlayer()
    {
        if (target == null) return;
        target.GetDamage(damage);
    }
}
