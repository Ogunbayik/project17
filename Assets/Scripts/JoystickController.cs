using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoystickController : MonoBehaviour
{
    [HideInInspector]
    public Vector3 direction;

    [SerializeField] private RectTransform knob;
    [SerializeField] private RectTransform center;
    [SerializeField] private float knobRange;

    private Vector3 mousePosition;
    
    void Start()
    {
        ActivateJoystick(false);
    }

    void Update()
    {
        mousePosition = Input.mousePosition;

        if(Input.GetMouseButtonDown(0))
        {
            knob.position = mousePosition;
            center.position = mousePosition;
            ActivateJoystick(true);
        }
        else if(Input.GetMouseButton(0))
        {
            knob.position = mousePosition;
            direction = (knob.position - center.position);
            knob.position = center.position + Vector3.ClampMagnitude(direction,center.sizeDelta.x * knobRange);
        }
        else if(Input.GetMouseButtonUp(0))
        {
            direction = Vector3.zero;
            ActivateJoystick(false);
        }
    }

    private void ActivateJoystick(bool isActive)
    {
        knob.gameObject.SetActive(isActive);
        center.gameObject.SetActive(isActive);
    }

}
