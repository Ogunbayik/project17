using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;
    private Camera cam;
    [SerializeField] private Vector3 offsetPosition;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(TagManager.PLAYER);
        cam = Camera.main;
    }

    void LateUpdate()
    {
        cam.transform.position = player.transform.position + offsetPosition;
    }
}
