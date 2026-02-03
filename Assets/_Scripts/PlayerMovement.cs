using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjustable speed in the Inspector
    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
    }

    void Update()
    {
        // Read input from the keyboard (WASD or Arrow keys) every frame
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        // Normalize the input vector to ensure consistent speed in all directions (especially diagonals)
        moveInput.Normalize();
    }

    void FixedUpdate()
    {
        // Apply velocity in the FixedUpdate for consistent physics updates
        rb.velocity = moveInput * moveSpeed * Time.fixedDeltaTime * 100f; // Multiply by 100 to convert to appropriate units
    }
}
