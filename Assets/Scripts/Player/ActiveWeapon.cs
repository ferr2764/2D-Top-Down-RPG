using System;
using UnityEngine;

public class ActiveWeapon : Singleton<ActiveWeapon>
{
    [SerializeField] private MonoBehaviour currentWeapon;
    private PlayerControls playerControls;
    private bool attackButtonDown, isAttacking = false;
    protected override void Awake()
    {
        base.Awake();
        playerControls = new();
    }
    private void OnEnable()
    {
        playerControls.Enable();
    }
    private void Start()
    {
        playerControls.Combat.Attack.started += _ => StartAttacking();
        playerControls.Combat.Attack.canceled += _ => StopAttacking();
    }
    private void Update()
    {
        Attack();
    }

    private void Attack()
    {
        if (attackButtonDown && !isAttacking)
        {
            isAttacking = true;
            (currentWeapon as IWeapon).Attack();
        }
    }

    public void ToggleIsAttacking(bool value)
    {
        isAttacking = value;
    }
    public void StartAttacking()
    {
        attackButtonDown = true;
    }
    public void StopAttacking()
    {
        attackButtonDown = false;
    }
}
