using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tranformation2 : MonoBehaviour
{

    public GameObject player;

    public GameObject Box;

    private BoxCollider2D PlayerCol2;

    private SpriteRenderer Player2;

    public Transform GroundCheck;

    public SpriteRenderer LiveSprite;

    bool isSpiked;

    public LayerMask spikelayer;

    private void FixedUpdate()
    {
        isSpiked = Physics2D.OverlapCircle(GroundCheck.position, 1.2f, spikelayer);
    }

    private void Start()
    {
        Player2 = GetComponent<SpriteRenderer>();
        PlayerCol2 = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        
        gameObject.GetComponent<SpriteRenderer>();
        if (Input.GetKeyDown(KeyCode.T))
        {
                Skinless2();
            Box.transform.position = player.transform.position;
        }
        if (isSpiked == true)
        {
            if (Player2.enabled == true)
            {
                if (LiveSprite == true)
                {
                    Skinless2();
                }
            }
        }
    }

    public void Skinless2()
    {
        Player2.enabled = !Player2.enabled;
        PlayerCol2.enabled = !PlayerCol2.enabled;
    }
}