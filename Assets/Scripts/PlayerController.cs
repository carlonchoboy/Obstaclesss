using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public float moveSpeed = 5f;

    public float maxSpeed = 10f;

    public float acceleration = 1f;

    public float decelartion = 1f;

    public float jumpForce = 10f;

    public LayerMask Ground;

    private float speed = 0f;

    private Rigidbody rigidbody;

    private Vector3 moveDirection;

    private float distToGround;

    private Collider collider;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
        distToGround = collider.bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        CheckJump();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.X) && isGrounded())
        {
            speed = speed - acceleration * Time.deltaTime;
        }
        else
        {
            if (speed > decelartion * Time.deltaTime)
                speed = speed - decelartion * Time.deltaTime;
            else if (speed < -decelartion * Time.deltaTime)
                speed = speed + decelartion * Time.deltaTime;
            else
                speed = 0;
        }
        Vector3 temp = new Vector3(-1, 0, 0);
        temp = temp.normalized * speed * Time.deltaTime;
        rigidbody.MovePosition(transform.position + temp);

        if (rigidbody.position.y < -1f)
        {
            FindObjectOfType<Gamemanager>().EndGame();
        }
    }

    private void CheckJump()
    {
        if (isGrounded() && Input.GetButtonDown("Jump"))
        {
            moveDirection.y = jumpForce;
            rigidbody.velocity = moveDirection;
        }
    }

    private bool isGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f, Ground.value);
    }
}
