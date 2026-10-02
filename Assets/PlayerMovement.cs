using UnityEngine;

using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour

{

    public float moveSpeed = 5f;

    private Rigidbody2D rb;

    private Vector2 input;

    void Start()

    {

        rb = GetComponent<Rigidbody2D>();

    }

    void Update()

    {

        input = Vector2.zero;

        if (Keyboard.current.wKey.isPressed)

            input.y += 1;

        if (Keyboard.current.sKey.isPressed)

            input.y -= 1;

        if (Keyboard.current.dKey.isPressed)

            input.x += 1;

        if (Keyboard.current.aKey.isPressed)

            input.x -= 1;

        input = input.normalized;

    }
    void OnTriggerEnter2D(Collider2D other)
    { Debug.Log("Player has entered the trigger zone!");
        
    }
    void FixedUpdate()

    {

        rb.linearVelocity = input * moveSpeed;

    }

}