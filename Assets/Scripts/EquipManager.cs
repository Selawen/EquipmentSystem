using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EquipManager : MonoBehaviour
{
    GameObject player;

    [Tooltip("the text to display when an item can be picked up")]
    [SerializeField] TextMeshProUGUI pickupText;

    [Header("Equip slots")]
    [SerializeReference] private Hand[] hands;
    [SerializeReference] private Head head;

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
            pickupObj.offset.x *= -1;               //temporarily set pickup offset to left hand instead of right
            hands[1].Equip(pickupObj, this);
            Debug.Log("equipped " + pickupObj.name + " to left hand");

            pickupObj.offset.x *= -1;               //reset pickup offset

            pickupObj = null;
            pickupText.enabled = false;
        }
    }

    /// <summary>
    /// put hat on head
    /// </summary>
    /// <param name="h">hat to place on head</param>
    public void OnHead(Hat h)
    {
        //unequip hat from hand
        for (int i= 0; i<2; i++)
        {
            if (hands[i].HoldingHat() == h)  //unequip if the hat being held is the hat to be put on head
            {
                hands[i].UnEquip();
                continue;
            }
        }

        //drop hat if already wearing one
        if (head.HoldingItem())
        {
            head.UnEquip();
        }

        head.Equip(h, this);
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

    /// <summary>
    /// check whether the player is holding a gun in either hand
    /// </summary>
    /// <returns>equipped gun if held, null if not</returns>
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
