using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : Equippable
{
    [SerializeField] Light lightCone;

    private void Start()
    {
        offset = new Vector3(0, 0, 0.1f);
    }

    /// <summary>
    /// toggle flashlight light on/off
    /// </summary>
    public override void Action()
    {
        lightCone.enabled = !lightCone.enabled;
    }
}
