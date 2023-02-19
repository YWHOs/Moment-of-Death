using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health;

    Player target;
    [SerializeField] int damage;

    bool isDead;
    public bool IsDead() { return isDead; }

    void Start()
    {
        target = FindObjectOfType<Player>();
    }

    public void Damage(int _damage)
    {
        BroadcastMessage("TakeDamage");
        health -= _damage;

        if(health <= 0)
        {
            if (isDead) return;
            isDead = true;
            GetComponent<Animator>().SetTrigger("Die");
        }
    }

    public void AttackPlayer()
    {
        if (target == null) return;
        target.GetDamage(damage);
        target.GetComponent<SplatterUI>().ShowImage();
    }
}
