using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private JoystickController joystick;

    [SerializeField] private float speed;

    private float horizontal;
    private float vertical;
    private Vector3 movementDirection;
    
    void Start()
    {
        joystick = FindObjectOfType<JoystickController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        horizontal = joystick.direction.x;
        vertical = joystick.direction.y;

        movementDirection = new Vector3(horizontal, 0f, vertical).normalized;
        var currentSpeed = movementDirection.magnitude;
        animator.SetFloat(TagManager.SPEED_PARAMETER, currentSpeed);
        transform.position += movementDirection * speed * Time.deltaTime;

        Rotation();

    }

    private void Rotation()
    {
        var currentSpeed = movementDirection.magnitude;
        if (currentSpeed != 0)
        {
            var lookDirection = new Vector3(horizontal, 0f, vertical);
            transform.LookAt(lookDirection);
        }
        else
        {
            transform.LookAt(null);
        }
    }
}
