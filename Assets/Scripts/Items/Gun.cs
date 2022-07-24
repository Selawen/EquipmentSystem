using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Equippable
{
    [SerializeField] GameObject impactHolePrefab;

    /// <summary>
    /// fire gun
    /// </summary>
    public override void Action()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.forward, out hit);
        if (hit.collider.tag.Contains(""))
        {
            GameObject hole = Instantiate<GameObject>(impactHolePrefab, hit.point, hit.transform.rotation);
            hole.transform.Rotate(new Vector3(90, 0, 0));
        }
    }
}
