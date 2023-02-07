using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;

    [System.Serializable]
    class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmount;
    }

    public int CurrentAmmo(AmmoType _ammoType) { return GetAmmoSlot(_ammoType).ammoAmount; }

    public void ReduceAmmo(AmmoType _ammoType)
    {
        GetAmmoSlot(_ammoType).ammoAmount--;
    }

    AmmoSlot GetAmmoSlot(AmmoType _ammoType)
    {
        foreach(AmmoSlot slot in ammoSlots)
        {
            if (slot.ammoType == _ammoType)
                return slot;
        }
        return null;
    }
}
