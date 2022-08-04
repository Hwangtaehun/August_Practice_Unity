using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    private float width;

    private void Awake()
    {
        BoxCollider2D backgroundCollider = GetComponent<BoxCollider2D>();
        width = backgroundCollider.size.x;
    }

    // Update is called once per frame
    private void Update()
    {
        if(transform.position.x <= -width)
        {
            Repositon();
        }
    }

    private void Repositon()
    {
        Vector2 offset = new Vector2(width * 2.0f, 0);
        transform.position = (Vector2)transform.position + offset;
    }
}
