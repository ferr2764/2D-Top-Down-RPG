using System;
using System.Collections;
using UnityEngine;

public class ActiveWeapon : Singleton<ActiveWeapon>
{
    public MonoBehaviour CurrentWeapon { get; set; }
    private PlayerControls playerControls;
    private bool attackButtonDown, isAttacking = false;
    private float attackCD;
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

        AttackCooldown();
    }

    private void AttackCooldown()
    {
        isAttacking = true;
        StopAllCoroutines();
        StartCoroutine(TimeBetweenAttackRoutine());
    }

    private IEnumerator TimeBetweenAttackRoutine()
    {
        yield return new WaitForSeconds(attackCD);
        isAttacking= false;
    }

    private void Update()
    {
        Attack();
    }

    private void Attack()
    {
        if (attackButtonDown && !isAttacking)
        {
            AttackCooldown();
            (CurrentWeapon as IWeapon).Attack();
        }
    }
    public void StartAttacking()
    {
        attackButtonDown = true;
    }
    public void StopAttacking()
    {
        attackButtonDown = false;
    }

    public void WeaponNull()
    {
        CurrentWeapon = null;
    }

    public void NewWeapon(MonoBehaviour monoBehaviour)
    {
        CurrentWeapon = monoBehaviour;
        AttackCooldown();
        attackCD = (CurrentWeapon as IWeapon).GetWeaponInfo().weaponCD;
    }
}
