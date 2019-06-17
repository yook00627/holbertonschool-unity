﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform t;
    private Vector3 offset;

    public GameObject player;
    public float turnSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<Transform>();
        offset = t.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * turnSpeed, Vector3.left) * offset;
        t.position = player.transform.position + offset * Time.timeScale;
        transform.LookAt(player.transform.position);
    }
}
