using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NickController : MonoBehaviour
{
    public float speed = 10.0f;

    private Rigidbody2D rb2d;

    private float horizontalMove;
    private float verticalMove;

    private void Awake()
    {
        horizontalMove = 0.0f;
        verticalMove = 0.0f;

        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
            
    }


    private void Update()
    {
        updatePlayerInputMovement();
    }

    private void FixedUpdate()
    {
        if (!Mathf.Approximately(horizontalMove, 0.0f) || !Mathf.Approximately(verticalMove, 0.0f))
        {
            Move();
        }
    }

    private void Move()
    {
        Vector2 move = new Vector2(horizontalMove * speed * Time.deltaTime, verticalMove * speed * Time.deltaTime);
        rb2d.MovePosition(rb2d.position + move);
    }

    private void updatePlayerInputMovement()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
    }
}
