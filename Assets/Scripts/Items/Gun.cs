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
            Vector3 scatter = new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), 0);
            RaycastHit hit;
            Physics.Raycast(transform.position, transform.forward + scatter, out hit);

            // create bullet impact
            GameObject hole = Instantiate<GameObject>(impactHolePrefab, hit.point, new Quaternion(hit.normal.x, hit.normal.y, hit.normal.z, 0));
            hole.transform.Rotate(new Vector3(90, 0, 0));

            ammo--;
        }
    }

    /// <summary>
    /// add ammo to gun
    /// </summary>
    /// <param name="amount">the amount of ammo to add</param>
    public void AddAmmo(int amount)
    {
        ammo += amount;
    }
}
