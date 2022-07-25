using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equippable : MonoBehaviour
{
    public Vector3 offset = new Vector3(0,0,0);

    protected EquipManager equipManager;

    public virtual void Action()
    {
        Debug.Log("equippable action");
    }

    /// <summary>
    /// disable item collision and parent item to player on equip
    /// </summary>
    /// <param name="player"></param>
    public virtual void OnEquip(GameObject player)
    {
        GetComponent<Rigidbody>().Sleep();
        GetComponent<Collider>().enabled = false;
        transform.parent = player.transform;
        transform.localPosition = offset;
    }    
    
    /// <summary>
    /// disable item collision and parent item to player on equip
    /// </summary>
    /// <param name="player"></param>
    public virtual void OnEquip(EquipManager player)
    {
        equipManager = player;
        GetComponent<Rigidbody>().Sleep();
        GetComponent<Collider>().enabled = false;
        transform.parent = player.transform;
        transform.localPosition = offset;
    }

    /// <summary>
    /// reenable collisions and release player parenting
    /// </summary>
    public virtual void OnUnEquip()
    {
        GetComponent<Rigidbody>().WakeUp();
        GetComponent<Collider>().enabled = true;
        transform.parent = null;
    }
}
