using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    [Header("Horizontal Movement Settings")]
    
    [SerializeField] private float walkspeed = 1;
    
    
    [Header("Ground Check Settings")]
    [SerializeField] private float jumpForce = 45;
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private float groundCheckY = 0.2f;
    [SerializeField] private float groundCheckX = 0.5f;
    [SerializeField] private LayerMask whatIsGround;

    private Rigidbody2D rigid;
    private float xAxis;
    Animator anim;

    public static Control Instance;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInputs();
        Move();
        Jump();
        Flip();
    }


    void GetInputs()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
    }

    void Flip()
    {
        if(xAxis < 0)
        {
            transform.localScale = new Vector2(-1, transform.localScale.y);
        }
        else if(xAxis > 0)
        {
            transform.localScale = new Vector2(1, transform.localScale.y);
        }
    }

    private void Move()
    {
        rigid.velocity = new Vector2(walkspeed * xAxis, rigid.velocity.y);
        anim.SetBool("Walking", rigid.velocity.x != 0 && Grounded());
    }


    public bool Grounded()
    {
        if (Physics2D.Raycast(groundCheckPoint.position, Vector2.down, groundCheckY, whatIsGround) 
            || Physics2D.Raycast(groundCheckPoint.position + new Vector3(groundCheckX,0,0), Vector2.down, groundCheckY, whatIsGround)
            || Physics2D.Raycast(groundCheckPoint.position + new Vector3(-groundCheckX, 0, 0), Vector2.down, groundCheckY, whatIsGround))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void Jump()
    {
        if(Input.GetButtonUp("Jump") && rigid.velocity.y > 0)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, 0);
        }

        if (Input.GetButtonDown("Jump") && Grounded())
        {
            rigid.velocity = new Vector3(rigid.velocity.x, jumpForce);
        }

        anim.SetBool("Jumping", !Grounded());
    }
}
