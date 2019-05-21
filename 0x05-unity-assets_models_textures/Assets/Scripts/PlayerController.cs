using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 8.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 movement = Vector3.zero;
    private Vector3 startPos;
    private CharacterController cc;
    private Transform t;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        t = GetComponent<Transform>();
        startPos = t.position;
    }

    // Update is called once per frame
    void Update()
    {
        playerControl();

        if (t.position.y < -15)
        {
            t.position = new Vector3(startPos.x, startPos.y + 15, startPos.z);
        }
    }

    void playerControl()
    {
        if (cc.isGrounded)
        {
            movement = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            movement *= speed;

            if (Input.GetButtonDown("Jump"))
            {
                movement.y = jumpSpeed;
            }
        }
        movement.y -= gravity * Time.deltaTime;
        cc.Move(movement * Time.deltaTime);
    }
}
