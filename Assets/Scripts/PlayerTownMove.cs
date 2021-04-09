using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTownMove : MonoBehaviour
{
    public float WaitTime = 1f;

    public bool canMove;

    public float speed;

    public float jumpForce;

    bool isGrounded;

    bool EndLevel;

    public Transform GroundCheck;

    public LayerMask groundlayer;

    public Rigidbody2D rb2d;

    bool isSpiked;

    public LayerMask spikelayer;

    public LayerMask doorlayer;

    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        Alive = true;
        isSpiked = false;
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Alive == false)
        {
            HP = 1;
        }
        if (isSpiked == true)
        {
            TakeDamage();
        }
        if (HP <= 0)
        {
            rb2d.velocity = Vector2.zero;
            transform.position = new Vector3(0, 0, 0);
            Alive = false;
        }
        if (canMove == false)
        {
            rb2d.velocity = Vector2.zero;
            return;
        }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (isGrounded)
                {
                    {
                        Jump();
                    }
                }
            }
        }

    void FixedUpdate()
    {
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector2 movement = new Vector2(moveHorizontal, moveVertical);
            rb2d.AddForce(movement * speed);
            isGrounded = Physics2D.OverlapCircle(GroundCheck.position, 1.2f, groundlayer);
            isSpiked = Physics2D.OverlapCircle(GroundCheck.position, 1.2f, spikelayer);
            EndLevel = Physics2D.OverlapCircle(GroundCheck.position, 1.2f, doorlayer);
        }
    }

    IEnumerator Door_Animation()
    {
        yield return new WaitForSeconds(WaitTime);
        rb2d.velocity = Vector2.zero;
    }

    private void LateUpdate()
    {
        if (EndLevel == true)
        {
            Door_Animation();
        }
    }

    public float HP;

    bool Alive;

    public float TakenDMG;

    void TakeDamage()
    {
        HP = HP - TakenDMG;
    }

    void Jump()
    {
        rb2d.velocity = Vector2.up * jumpForce;
    }
}
