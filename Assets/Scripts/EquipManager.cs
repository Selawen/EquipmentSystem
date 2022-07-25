using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EquipManager : MonoBehaviour
{
    GameObject player;
    [SerializeField] TextMeshProUGUI pickupText;

    [SerializeField] private Hand[] hands;
    [SerializeField] private Head head;

    private Equippable pickupObj;

    // Start is called before the first frame update
    void Start()
    {
        player = this.gameObject;
        hands = new Hand[]{ ScriptableObject.CreateInstance<Hand>(), ScriptableObject.CreateInstance<Hand>()};
        head = ScriptableObject.CreateInstance<Head>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// equip item on collision
    /// </summary>
    /// <param name="col"></param>
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.TryGetComponent<Equippable>(out Equippable item))
        {
            pickupText.enabled = true;
            pickupObj = item;
        }
    }

    /// <summary>
    /// make sure item can't be picked up outside range
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionExit(Collision collision)
    {
        if (pickupText.enabled || pickupObj != null)
        {
            pickupText.enabled = false;
            pickupObj = null;
        }
    }

    /// <summary>
    /// pick up item with right hand if item is in range
    /// </summary>
    void OnRightHand()
    {
        //drop item if already holding one
        if (hands[0].HoldingItem())
        {
            hands[0].UnEquip();
        }

        if (pickupObj != null)
        {
            hands[0].Equip(pickupObj, this);
            //hands[0].Equip(pickupObj, player);            
            Debug.Log("equipped " + pickupObj.name + " to right hand");
            
            pickupObj = null;
            pickupText.enabled = false;
        }
    }    
    
    /// <summary>
    /// pick up item with left hand if item is in range
    /// </summary>
    void OnLeftHand()
    {
        //drop item if already holding one
        if (hands[1].HoldingItem())
        {
            hands[1].UnEquip();
        }

        if (pickupObj != null)
        {
            pickupObj.offset.x *= -1;
            //hands[1].Equip(pickupObj, player);
            hands[1].Equip(pickupObj, this);
            Debug.Log("equipped " + pickupObj.name + " to left hand");
            
            pickupObj = null;
            pickupText.enabled = false;
        }
    }

    /// <summary>
    /// use item in right hand
    /// </summary>
    void OnRightItem()
    {
        hands[0].UseItem();
    }

    /// <summary>
    /// use item in left hand
    /// </summary>
    void OnLeftItem()
    {
        hands[1].UseItem();
    }

    public Gun IsHoldingGun()
    {
        for (int i = 0; i < 2; i++)
        {
            Gun g = hands[i].HoldingGun();
            if (g != null)
                return g;
        }
        return null;
    }
}
