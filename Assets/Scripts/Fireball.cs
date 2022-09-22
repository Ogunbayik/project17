using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    private GameObject player;
    private Rigidbody rb;

    [SerializeField] private float movementSpeed;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag(TagManager.PLAYER);
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        Movement();
    }
    
    private void Movement()
    {
        //transform.LookAt(player.transform.position);
        var direction = (player.transform.position - transform.position);

        rb.AddForce(direction * movementSpeed * Time.deltaTime, ForceMode.Impulse);

        
    }
}
