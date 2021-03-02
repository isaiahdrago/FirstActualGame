using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public bool canMove;

    private SpriteRenderer Player1;

    public float speed;

    public float jumpForce;

    bool isGrounded;

    public Transform GroundCheck;

    public LayerMask groundlayer;

    public Rigidbody2D rb2d;

    bool isSpiked;

    public LayerMask spikelayer;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Player1 = GetComponent<SpriteRenderer>();
        canMove = true;
        Alive = true;
        isSpiked = false;
    }

    void FixedUpdate()
    {
        if (Player1.enabled == true)
            {
                float moveHorizontal = Input.GetAxis("Horizontal");
                float moveVertical = Input.GetAxis("Vertical");
                Vector2 movement = new Vector2(moveHorizontal, moveVertical);
                rb2d.AddForce(movement * speed);
                isGrounded = Physics2D.OverlapCircle(GroundCheck.position, 1.2f, groundlayer);
            isSpiked = Physics2D.OverlapCircle(GroundCheck.position, 1.2f, spikelayer);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                if (Player1.enabled == true)
                {
                    Jump();
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            Skinless1();
            canMove = !canMove;
        }
        if (canMove == false)
        {
            rb2d.velocity = Vector2.zero;
            return;
        }
        if (HP <= 0)
        {
            rb2d.velocity = Vector2.zero;
            transform.position = new Vector3(0, 0, 0);
            Alive = false;
        }
        if (Alive == false)
        {
            if (Player1.enabled == false)
            {
                Skinless1();
            }
        }
        if (Alive == false)
        {
            HP = 1;
        }
        if (isSpiked == true)
        {
            TakeDamage();
        }
    }

    void Jump()
    {
        rb2d.velocity = Vector2.up* jumpForce;
    }

    public void Skinless1()
    {
        Player1.enabled = !Player1.enabled;
    }

    public float HP;

    bool Alive;

    public float TakenDMG;

    void TakeDamage()
    {
        HP = HP - TakenDMG;
    }
}
