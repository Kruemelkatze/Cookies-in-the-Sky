using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApprenticeController : MonoBehaviour
{

    public float Speed;
    public float JumpForce;
    public float distToGround;
    public float MaxDropSpeed = -25;

    private Rigidbody2D rigid;
    private Collider2D collider2D;
    private AudioSource stepperSource;

    public bool isGrounded = false;

    public bool moveLeft, moveRight;

    public LayerMask GroundedLayerMask;

    Animator animator;

    void Awake()
    {
    }

    // Use this for initialization
    void Start()
    {
        stepperSource = GetComponent<AudioSource>();
        rigid = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<Collider2D>();
        distToGround = this.collider2D.bounds.extents.y;
        animator = GetComponent<Animator>();
        Grid.EventHub.KillzoneTriggered += KillzoneTriggered;

        stepperSource.mute = true;
        stepperSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        float verticalVelocity = Math.Max(rigid.velocity.y, MaxDropSpeed);
        isGrounded = IsGrounded2D();

        if (Grid.GameLogic.IsDialogActive)
        {
            animator.SetBool("moveLeft", false);
            animator.SetBool("moveRight", false);
            animator.SetBool("idle", true);
            animator.SetBool("jump", false);
            rigid.velocity = new Vector2(0, verticalVelocity);
        }
        else
        {

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rigid.velocity = new Vector2(-Speed, verticalVelocity);
                animator.SetBool("moveLeft", true);
                animator.SetBool("moveRight", false);
                animator.SetBool("idle", false);


            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                rigid.velocity = new Vector2(Speed, verticalVelocity);
                animator.SetBool("moveLeft", false);
                animator.SetBool("moveRight", true);
                animator.SetBool("idle", false);

            }
            else
            {
                animator.SetBool("moveLeft", false);
                animator.SetBool("moveRight", false);

                animator.SetBool("idle", isGrounded);

                rigid.velocity = new Vector2(0, verticalVelocity);

            }

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                Grid.SoundManager.PlaySingle(Grid.SoundManager.JumpSound);
                float h = rigid.velocity.x;
                rigid.velocity = new Vector2(h, JumpForce);
                //animator.SetBool ("jump", true);
                //animator.SetBool ("idle", false);
                //animator.SetBool ("moveLeft", false);
                //animator.SetBool ("moveRight", 
                animator.SetBool("jump", true);
            }
        }
        animator.SetBool("jump", !isGrounded);



        stepperSource.mute = !animator.GetBool("idle") || animator.GetBool("jump");

        //if (animator.GetBool ("jump") && isGrounded)
        //	animator.SetBool ("jump", false);


    }

    bool IsGrounded2D()
    {
        var hit = Physics2D.Raycast(transform.position, -Vector2.up, distToGround + 0.1f, GroundedLayerMask);

        // If it hits something...
        return hit != null && hit.distance > 0.1f;
    }


    void KillzoneTriggered()
    {
        gameObject.SetActive(false);
    }
}
