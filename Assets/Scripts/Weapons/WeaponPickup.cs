using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] private Weapon weaponHolder;
    private Weapon weapon;

    void Awake()
    {
        if (weaponHolder != null)
        {
            weapon = Instantiate(weaponHolder, transform.position, Quaternion.identity, transform);
        }
    }

    void Start()
    {
        if (weapon != null)
        {
            TurnVisual(weapon, false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Weapon currentWeapon = other.GetComponentInChildren<Weapon>();

            if (currentWeapon != null)
            {
                TurnVisual(currentWeapon, false);
                currentWeapon.gameObject.SetActive(false);
            }

            weapon.transform.SetParent(other.transform, false);
            weapon.transform.localPosition = Vector3.zero;
            weapon.transform.localRotation = Quaternion.identity;

            TurnVisual(weapon, true);
            weapon.gameObject.SetActive(true);
        }
    }

    private void TurnVisual(Weapon weapon, bool on)
    {
        foreach (var component in weapon.GetComponentsInChildren<Renderer>())
        {
            component.enabled = on;
        }
    }

    private void TurnVisual(bool on)
    {
        foreach (var component in weapon.GetComponentsInChildren<Renderer>())
        {
            component.enabled = on;
        }
    }
}