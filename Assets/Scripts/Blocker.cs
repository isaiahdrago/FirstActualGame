using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocker : MonoBehaviour
{
    public GameObject Player;

    public SpriteRenderer PlayerSprite;

    private BoxCollider2D BlockerCol;

    public void Start()
    {
        BlockerCol = GetComponent<BoxCollider2D>();
    }

    public void Update()
    {
        gameObject.GetComponent<SpriteRenderer>();
        if (PlayerSprite.enabled == false)
        {
            ColActive();
        }
        if (PlayerSprite.enabled == true)
        {
            ColDeactive();
        }
    }

    void ColActive()
    {
        BlockerCol.enabled = true;
    }

    void ColDeactive()
    {
        BlockerCol.enabled = false;
    }
}
