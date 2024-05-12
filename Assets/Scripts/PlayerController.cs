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
    public GameObject projectile;
    public Transform gunArm;

    private Camera worldCamera;
    private Vector2 movement;

    private void Start()
    {
        worldCamera = FindObjectOfType<Camera>();
    }

    void Update()
    {
        grounded = Physics2D.Raycast(groundCheck.position, Vector2.down, 0.1f, groundLayer);
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), grounded ? (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space) ? jumpPower : rb.velocity.y) : rb.velocity.y);
        Aim();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(movement.x * speed * Time.fixedDeltaTime, movement.y);
    }

    private Vector3 GetMousePos()
    {
        Vector3 mousePos = worldCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        return mousePos;
    }

    private void Aim()
    {
        Vector3 mousePos = GetMousePos();
        Vector3 aimDirection = (mousePos - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        gunArm.eulerAngles = new Vector3(0, 0, angle);

        Vector3 localScale = Vector3.one;
        if (Mathf.Abs(angle) > 90)
        {
            localScale.y = -1f;
        }
        else
        {
            localScale.y = +1f;
        }

        gunArm.localScale = localScale;
    }
}
