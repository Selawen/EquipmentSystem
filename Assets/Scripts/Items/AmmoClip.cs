using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoClip : Equippable
{
    [SerializeField] int ammo;

    /// <summary>
    /// reload gun if gun is in other hand
    /// </summary>
    public override void Action()
    {
        Gun g = equipManager.IsHoldingGun();
        
        if (g != null)
        {
            g.AddAmmo(ammo);
            Destroy(this.gameObject);
        }
    }
}
