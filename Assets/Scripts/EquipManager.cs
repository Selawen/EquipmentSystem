using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipManager : MonoBehaviour
{
    GameObject player;

    [SerializeField] private Hand[] hands;
    [SerializeField] private Head head;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<EquipManager>().gameObject;
        hands = new Hand[]{ new Hand(), new Hand()};
        head = new Head();
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
        if (col.gameObject.TryGetComponent<Hat>(out Hat hat))
        {
            head.Equip(hat, player);
            Debug.Log("equipped " + hat.name);
            return;
        }
            if (col.gameObject.TryGetComponent<Equippable>(out Equippable item))
        {
            hands[0].Equip(item, player);
            Debug.Log("equipped " + item.name);
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
}
