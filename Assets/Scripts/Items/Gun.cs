using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Equippable
{
    [SerializeField] GameObject impactHolePrefab;
    int ammo = 5;

    /// <summary>
    /// fire gun
    /// </summary>
    public override void Action()
    {
        if (ammo > 0)
        {
            RaycastHit hit;
            Physics.Raycast(transform.position, transform.forward, out hit);

            GameObject hole = Instantiate<GameObject>(impactHolePrefab, hit.point, hit.transform.rotation);
            hole.transform.Rotate(new Vector3(90, 0, 0));

            ammo--;
            //Debug.Log("ammo left: " + ammo);
        }
    }

    public void AddAmmo(int amount)
    {
        ammo += amount;
    }
}
