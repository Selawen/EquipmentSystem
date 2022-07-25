using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : Equippable
{
    [SerializeField] Light lightCone;

    /// <summary>
    /// toggle flashlight light on/off
    /// </summary>
    public override void Action()
    {
        lightCone.enabled = !lightCone.enabled;
    }
}
