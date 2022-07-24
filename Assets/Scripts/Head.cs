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
    public void Equip(Hat hat, GameObject player)
    {
        if (equippedHat != null)
        {
            equippedHat.OnUnEquip();
        }
        
        equippedHat = hat;
        hat.OnEquip(player);
    }

    public void UnEquip()
    {
        equippedHat.OnUnEquip();
    }
}
