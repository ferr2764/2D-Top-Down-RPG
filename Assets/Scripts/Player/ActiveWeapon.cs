using System;
using System.Collections;
using UnityEngine;

public class ActiveWeapon : Singleton<ActiveWeapon>
{
    public MonoBehaviour CurrentActiveWeapon { get; set; }
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

    
    public void StartAttacking()
    {
        attackButtonDown = true;
    }
    public void StopAttacking()
    {
        attackButtonDown = false;
    }

    private void Attack()
    {
        if (attackButtonDown && !isAttacking && CurrentActiveWeapon)
        {
            //AttackCooldown();
            (CurrentActiveWeapon as IWeapon).Attack();
        }
    }

    public void WeaponNull()
    {
        CurrentActiveWeapon = null;
    }

    public void NewWeapon(MonoBehaviour monoBehaviour)
    {
        CurrentActiveWeapon = monoBehaviour;
        //AttackCooldown();
        attackCD = (CurrentActiveWeapon as IWeapon).GetWeaponInfo().weaponCooldown;
    }
}
