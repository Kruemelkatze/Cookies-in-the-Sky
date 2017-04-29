using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApprenticeController : MonoBehaviour
{

    public float Speed;
    public float JumpForce;
    public float distToGround;

    private Rigidbody2D rigid;
    private Collider2D collider2D;

    public bool isGrounded = false;

    public LayerMask GroundedLayerMask;

    void Awake()
    {
    }

    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<Collider2D>();
        distToGround = this.collider2D.bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        float verticalVelocity = rigid.velocity.y;

        if (Grid.GameLogic.IsDialogActive)
        {
            rigid.velocity = new Vector2(0, verticalVelocity);
            return;
        }


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigid.velocity = new Vector2(-Speed, verticalVelocity);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rigid.velocity = new Vector2(Speed, verticalVelocity);
        }
        else
        {
            rigid.velocity = new Vector2(0, verticalVelocity);
        }

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded2D())
        {
            float h = rigid.velocity.x;
            rigid.velocity = new Vector2(h, JumpForce);
        }
    }

    bool IsGrounded2D()
    {
        var hit = Physics2D.Raycast(transform.position, -Vector2.up, distToGround + 0.1f, GroundedLayerMask);

        // If it hits something...
        return hit != null && hit.distance > 0.1f;
    }
}
