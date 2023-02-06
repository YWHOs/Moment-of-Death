using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] int ammoAmount;

    public int CurrentAmmo() { return ammoAmount; }

    public void ReduceAmmo()
    {
        ammoAmount--;
    }
}
