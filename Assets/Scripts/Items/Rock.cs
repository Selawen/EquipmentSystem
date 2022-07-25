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
        //eventually stop rock from rolling away after throwing
        if (rb.useGravity && rb.velocity.magnitude < 0.25f && GetComponent<Collider>().enabled)
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
            rb.useGravity = false;
        }
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


}
