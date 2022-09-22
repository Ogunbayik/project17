using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : EnemyBase
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private GameObject fireballPrefab;
    [SerializeField] private float fireballSpeed;
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
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        transform.LookAt(player.transform.position);
        animator.SetTrigger(TagManager.ATTACK_PARAMETER);

        PowerBarPosition();
        distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance > attackRange && this.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            currentState = States.Chase;
            animator.ResetTrigger(TagManager.ATTACK_PARAMETER);
        }
    }

    public void SummonFireball()
    {
        var fireball = Instantiate(fireballPrefab);
        var direction = (attackPoint.position - transform.position).normalized;
        var loodDirection = (player.transform.position - fireball.transform.position);

        fireball.transform.position = attackPoint.position;
        fireball.transform.LookAt(loodDirection);
        fireball.GetComponent<Rigidbody>().AddForce(direction * fireballSpeed * Time.deltaTime, ForceMode.Impulse);

        DestroyFireball(fireball);
    }

    private void DestroyFireball(GameObject obj)
    {
        float destroyTime = 5f;
        Destroy(obj,destroyTime);
    }
}
