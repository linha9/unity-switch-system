using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NickController : MonoBehaviour
{
    public float speed = 10.0f;

    private Rigidbody2D rb2d;
    private List<Collider2D> colliders;

    private float horizontalMove;
    private float verticalMove;

    #region Unity Cycle
    private void Awake()
    {
        this.horizontalMove = 0.0f;
        this.verticalMove = 0.0f;

        this.rb2d = GetComponent<Rigidbody2D>();
        this.colliders = new List<Collider2D>();
    }

    private void Update()
    {
        updatePlayerInputMovement();

        if (Input.GetButtonDown("Activate"))
        {
            // FOR LATER: Use raycasting, Use events to handle input system
            this.colliders.ForEach(collider => collider.GetComponent<Switch>()?.Toggle());
        }
    }

    private void FixedUpdate()
    {
        if (!Mathf.Approximately(horizontalMove, 0.0f) || !Mathf.Approximately(verticalMove, 0.0f))
        {
            Move();
        }

        
    }
    #endregion Unity Cycle

    #region Unity Events Handler
    private void OnTriggerEnter2D(Collider2D collider)
    {
        colliders.Add(collider);
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        colliders.Remove(collider);
    }
    #endregion

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
