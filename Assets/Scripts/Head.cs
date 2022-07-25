using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : ScriptableObject
{
    Hat equippedHat;

    /// <summary>
    /// set equippedHat to new hat
    /// </summary>
    /// <param name="hat">hat to equip</param>
    public void Equip(Hat hat, EquipManager player)
    {
        if (equippedHat != null)
        {
            equippedHat.OnUnEquip();
        }
        
        equippedHat = hat;
        hat.OnEquip(player);
    }

    /// <summary>
    /// unequip hat
    /// </summary>
    public void UnEquip()
    {
        equippedHat.OnUnEquip();
        equippedHat = null;
    }

    /// <summary>
    /// check if head currently has hat equipped
    /// </summary>
    /// <returns>true if holding item</returns>
    public bool HoldingItem()
    {
        return equippedHat != null;
    }
}
