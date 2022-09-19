using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    protected Animator animator;
    protected GameObject player;
    
    [SerializeField] protected float movementSpeed;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag(TagManager.PLAYER);
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        
    }
    protected void Chasing()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, movementSpeed * Time.deltaTime);
        transform.LookAt(player.transform.position);
    }
}
