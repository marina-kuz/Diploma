using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed, bound;
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float h=Input.GetAxisRaw("Horizontal");
        if(h>0)
            rb.velocity = Vector2.right*speed;
        else if(h<0)
            rb.velocity = Vector2.left*speed;
        else
            rb.velocity = Vector2.zero;
        
        transform.position=new Vector2(Mathf.Clamp(transform.position.x,-bound,bound),
            transform.position.y);
    }
}
