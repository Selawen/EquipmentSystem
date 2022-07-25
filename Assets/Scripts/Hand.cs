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
    public void Equip(Equippable item, GameObject player)
    {
        equippedItem = item;
        item.OnEquip(player);
    }
    public void Equip(Equippable item, EquipManager player)
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

    public Gun HoldingGun()
    {
        if (equippedItem.GetType() == typeof(Gun))
        {
            return (Gun)equippedItem;
            Debug.Log("Holding gun");
        }
        else
            return null;
    }
}
