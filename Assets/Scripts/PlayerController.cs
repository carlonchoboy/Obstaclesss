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

    public int life;

    public Gamemanager gm;

    public Animator anim;

    private float speed = 0f;

    private Rigidbody rigidbody;

    private Vector3 moveDirection;

    private float distToGround;

    private Collider collider;

    private bool isRunning = false;

    private float lastPosY;

    private bool isJumping = false;

    private bool isFalling = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
        distToGround = collider.bounds.extents.y;
        lastPosY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        CheckCanJump();
        CheckAnimations();
        lastPosY = transform.position.y;
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.X) && isGrounded())
        {
            speed = speed - acceleration * UnityEngine.Time.deltaTime;
        }
        else
        {
            if (speed > decelartion * UnityEngine.Time.deltaTime)
                speed = speed - decelartion * UnityEngine.Time.deltaTime;
            else if (speed < -decelartion * UnityEngine.Time.deltaTime)
                speed = speed + decelartion * UnityEngine.Time.deltaTime;
            else
                speed = 0;
        }
        Vector3 temp = new Vector3(-1, 0, 0);
        temp = temp.normalized * speed * UnityEngine.Time.deltaTime;
        rigidbody.MovePosition(transform.position + temp);
    }

    private void CheckAnimations()
    {
        if (speed != 0)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
        anim.SetBool("isRunning", isRunning);
        if (isJumping)
        {
            anim.SetBool("isJumping", isJumping);
            anim.SetBool("isGrounded", false);
        }
        if (isJumping && transform.position.y < lastPosY)
        {
            isJumping = false;
            isFalling = true;
            anim.SetBool("isFalling", isFalling);
            anim.SetBool("isJumping", isJumping);
        }
        if (isFalling)
        {
            if (isGrounded())
            {
                isFalling = false;
                anim.SetBool("isGrounded",true);
                anim.SetBool("isFalling", isFalling);
            }
        }

    }

    private void CheckCanJump()
    {
        if (isGrounded() && Input.GetButtonDown("Jump"))
        {
            moveDirection.y = jumpForce;
            rigidbody.velocity = moveDirection;
            isJumping = true;
        }
    }

    private bool isGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f, Ground.value);
    }

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "obstacle")
        {
            life -= 1;
        }
        if (life <= 0)
        {
            //playerController.enabled = false;
            FindObjectOfType<Gamemanager>().EndGame();
        }
    }

}
