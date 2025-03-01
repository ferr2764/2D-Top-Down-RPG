using System;
using UnityEngine;

public class Staff : MonoBehaviour, IWeapon
{
    [SerializeField] private WeaponInfo weaponInfo;
    private void Update()
    {
        MouseFollowWithOffset();
    }

    private void MouseFollowWithOffset()
    {
        var mouse = Input.mousePosition;
        var playerScreenPoint = Camera.main.WorldToScreenPoint(PlayerController.Instance.transform.position);

        float angle = Mathf.Atan2(mouse.y, mouse.x) * Mathf.Rad2Deg;

        ActiveWeapon.Instance.transform.rotation = Quaternion.Euler(0, mouse.x < playerScreenPoint.x ? -100 : 0, angle);
    }

    public void Attack()
    {
        Debug.Log("Staff attack");
    }

    public WeaponInfo GetWeaponInfo()
    {
        return weaponInfo;
    }
}
