using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private JoystickController joystick;

    [SerializeField] private float speed;
    
    private GameObject powerBar;
    private float horizontal;
    private float vertical;
    private Vector3 movementDirection;
    
    void Start()
    {
        joystick = FindObjectOfType<JoystickController>();
        animator = GetComponent<Animator>();
        powerBar = transform.GetChild(2).gameObject;
    }

    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        horizontal = joystick.direction.x;
        vertical = joystick.direction.y;

        powerBar.transform.position = new Vector3(transform.position.x, 3f, transform.position.z);
        powerBar.transform.rotation = Quaternion.Euler(Vector3.zero);
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
