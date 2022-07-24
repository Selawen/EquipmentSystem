using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : ScriptableObject
{
    Equippable equippedItem;

    /// <summary>
    /// set equippedItem to new item
    /// </summary>
    /// <param name="item"></param>
    public void Equip(Equippable item, GameObject player)
    {
        if (equippedItem != null)
            equippedItem.OnUnEquip();
        equippedItem = item;
        item.OnEquip(player);
    }

    /// <summary>
    /// activate item action if item is equipped
    /// </summary>
    public void UseItem()
    {
        if (equippedItem != null)
            equippedItem.Action();
    }
}
