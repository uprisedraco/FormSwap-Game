using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Transform player;

    [SerializeField]
    private Vector3 cameraOffset = new Vector3(-5.5f, 4.15f, -7.8f);

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        transform.rotation = Quaternion.Euler(17f, 35f, 0f);
    }

    void LateUpdate()
    {
        transform.position = player.position + cameraOffset;
    }
}
