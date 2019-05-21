using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 8.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 movement = Vector3.zero;
    private CharacterController cc;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
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
