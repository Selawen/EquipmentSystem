using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : ScriptableObject
{
    Equippable equippedItem;
    
    /// <summary>
    /// set equipped item to new item
    /// </summary>
    /// <param name="item"></param>
    public void Equip(Equippable item, ActionManager player)
    {
        equippedItem = item;
        item.OnEquip(player);
    }

    /// <summary>
    /// unequip item currently held
    /// </summary>
    public void UnEquip()
    {
        equippedItem.OnUnEquip();        
        equippedItem = null;
    }

    /// <summary>
    /// activate item action if item is equipped
    /// </summary>
    public void UseItem()
    {
        if (equippedItem != null)
            equippedItem.Action();
    }

    /// <summary>
    /// check if hand is currently holding an item
    /// </summary>
    /// <returns>true if holding item</returns>
    public bool HoldingItem()
    {
        return equippedItem != null;
    }

    /// <summary>
    /// return gun if holding one
    /// </summary>
    /// <returns>gun currently held</returns>
    public Gun HoldingGun()
    {
        if (equippedItem == null)
            return null;

        if (equippedItem.GetType() == typeof(Gun))
        {
            return (Gun)equippedItem;
        }
        
        return null;
    }
    
    /// <summary>
    /// return hat if holding one
    /// </summary>
    /// <returns>hat currently held</returns>
    public Hat HoldingHat()
    {
        if (equippedItem == null)
            return null;

        if (equippedItem.GetType() == typeof(Hat))
        {
            return (Hat)equippedItem;
        }
        
        return null;
    }
}
