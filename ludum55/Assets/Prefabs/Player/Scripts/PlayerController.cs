using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private float moveX;
    private float moveY;
    private Rigidbody2D rb;
    Vector2 moveDir;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        InputManagement();
    }

    void FixedUpdate()
    {
        Move();
    }
    void InputManagement()
    {
        float moveX = Input.GetAxisRaw("Horizontal") * moveSpeed;
        float moveY = Input.GetAxisRaw("Vertical") * moveSpeed;

        moveDir = new Vector2(moveX, moveY).normalized;
        
    }
    void Move()
    {
        rb.velocity = new Vector2(moveDir.x * moveSpeed, moveDir.y * moveSpeed);
    }
    
}
