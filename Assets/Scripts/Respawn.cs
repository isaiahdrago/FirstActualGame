using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    bool Rigid;

    public GameObject Player;

    public Rigidbody2D rb2d;

    public void Start()
    {
        Rigid = false;
    }

    public void Update()
    {
        gameObject.GetComponent<Rigidbody2D>();
        if (Rigid == true)
        {
            rb2d.velocity = Vector2.zero;
            Rigid = false;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Player.transform.position = new Vector3(0, 0, 0);
        Rigid = true;
    }
}
