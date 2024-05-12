using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpPower;
    public bool grounded;
    public Transform groundCheck;
    public Rigidbody2D rb;
    public LayerMask groundLayer;

    private Vector2 movement;

    void Start()
    {
        
    }

    void Update()
    {
        grounded = Physics2D.Raycast(groundCheck.position, Vector2.down, 0.1f, groundLayer);
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), grounded ? (Input.GetKey(KeyCode.W) ? jumpPower : rb.velocity.y) : rb.velocity.y);
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(movement.x * speed * Time.fixedDeltaTime, movement.y);
    }
}
