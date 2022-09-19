using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : EnemyBase
{
    private enum States
    {
        Chase,
        Attack
    }
    private States currentState;

    [SerializeField] private float attackRange;

    private float distance;
    private void Start()
    {
        currentState = States.Chase;
    }

    void Update()
    {
        switch(currentState)
        {
            case States.Chase: Chase();
                break;
            case States.Attack: Attack();
                break;
        }
    }

    private void Chase()
    {
        base.Chasing();
        distance = Vector3.Distance(transform.position, player.transform.position);
        if(distance < attackRange)
        {
            currentState = States.Attack;
        }
    }

    private void Attack()
    {
        transform.LookAt(player.transform.position);
        animator.SetTrigger(TagManager.ATTACK_PARAMETER);
        distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance > attackRange)
        {
            currentState = States.Chase;
            animator.ResetTrigger(TagManager.ATTACK_PARAMETER);
        }
    }
}
