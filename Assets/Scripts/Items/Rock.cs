using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : Equippable
{
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        //stop rock from rolling when almost stopped
        if (rb.useGravity && rb.velocity.magnitude < 0.25f && GetComponent<Collider>().enabled || transform.position.y<0.08)
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
            rb.useGravity = false;
        }
    }

    /// <summary>
    /// disable item collision and parent item to player on equip
    /// </summary>
    /// <param name="player"></param>
    public override void OnEquip(GameObject player)
    {   
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezeAll;
        base.OnEquip(player);
    }

    /// <summary>
    /// throw rock
    /// </summary>
    public override void Action()
    {
        rb.WakeUp();
        rb.useGravity = true;
        rb.AddForce(transform.parent.forward *200);
        rb.constraints = RigidbodyConstraints.None;
        transform.parent = null;

        StartCoroutine(UnEquip());
        StartCoroutine(ResetPhysics());
    }

    /// <summary>
    /// coroutine to avoid physics trouble
    /// </summary>
    /// <returns></returns>
    IEnumerator UnEquip()
    {
        yield return new WaitForSeconds(0.35f);
        GetComponent<Collider>().enabled = true;
    }

    /// <summary>
    /// reset the rigidbody to start condition after a while
    /// </summary>
    /// <returns></returns>
    IEnumerator ResetPhysics()
    {
        yield return new WaitForSeconds(10);

        rb.constraints = RigidbodyConstraints.FreezeAll;
        rb.useGravity = false;
    }
}
