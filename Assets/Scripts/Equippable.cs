using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equippable : MonoBehaviour
{
    [Tooltip("the offset to use when equipping to right hand")]
    public Vector3 offset = new Vector3(0,0,0);

    protected EquipManager equipManager;

    private void Start()
    {
        //if no offset is set, set to default offset
        if (offset == new Vector3(0, 0, 0))
            offset = new Vector3(0.25f, 0, 0.5f);
    }

    public virtual void Action()
    {
        Debug.Log("equippable action");
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
