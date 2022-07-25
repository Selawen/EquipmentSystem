using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gun : Equippable
{
    [Tooltip("the prefab to instantiate on point of impact")]
    [SerializeField] GameObject impactHolePrefab;
    
    int ammo = 5;
    int maxAmmo = 6;

    [Tooltip("is the gun in full automatic mode")]
    [SerializeField] bool automatic = false;
    bool shooting = false;

    [Header("gun UI")]
    [SerializeField] GameObject gunPanel;
    [SerializeField] TextMeshProUGUI ammoText;
    [SerializeField] TextMeshProUGUI autoText;

    public override void OnEquip(ActionManager player)
    {
        base.OnEquip(player);
        UpdateAmmoText();
        autoText.text = "automatic mode " + (automatic ? "on" : "off");
        gunPanel.SetActive(true);
    }

    public override void OnUnEquip()
    {
        base.OnUnEquip();
        gunPanel.SetActive(false);
    }

    /// <summary>
    /// fire gun
    /// </summary>
    public override void Action()
    {
        // stop shooting if already shooting
        if (shooting)
        {
            StopCoroutine(AutoShoot());
            shooting = false;
            return;
        }

        if (ammo > 0)
        {
            Vector3 scatter = new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), 0);
            RaycastHit hit;
            Physics.Raycast(transform.position, transform.forward + scatter, out hit);

            // create bullet impact
            GameObject hole = Instantiate<GameObject>(impactHolePrefab, hit.point, new Quaternion(hit.normal.x, hit.normal.y, hit.normal.z, 0));
            hole.transform.Rotate(new Vector3(90, 0, 0));

            ammo--;
            UpdateAmmoText();

            if (automatic)
            {
                shooting = true;
                StartCoroutine(AutoShoot());
            }
        }
    }

    /// <summary>
    /// add ammo to gun
    /// </summary>
    /// <param name="amount">the amount of ammo to add</param>
    public void AddAmmo(int amount)
    {
        ammo += amount;

        ammo = Mathf.Min(maxAmmo, ammo);
        UpdateAmmoText();
    }

    void UpdateAmmoText()
    {
        ammoText.text = "Ammo: " + ammo.ToString() + "/" + maxAmmo.ToString();
    }

    void OnAutoMode()
    {
        automatic = !automatic;
        autoText.text = "automatic mode " + (automatic ? "on" : "off");
    }

    /// <summary>
    /// if automatic is turned on keep shooting until empty
    /// </summary>
    /// <returns></returns>
    IEnumerator AutoShoot()
    {
        yield return new WaitForSeconds(0.2f);
        if (ammo > 0 && shooting)
        {

            Vector3 scatter = new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), 0);
            RaycastHit hit;
            Physics.Raycast(transform.position, transform.forward + scatter, out hit);

            // create bullet impact
            GameObject hole = Instantiate<GameObject>(impactHolePrefab, hit.point, new Quaternion(hit.normal.x, hit.normal.y, hit.normal.z, 0));
            hole.transform.Rotate(new Vector3(90, 0, 0));

            ammo--; 
            UpdateAmmoText();

            StartCoroutine(AutoShoot());
        } else
        {
            shooting = false;
        }
    }
}
