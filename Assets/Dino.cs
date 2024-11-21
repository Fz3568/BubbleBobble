using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Dino : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer PRenderer;

    public float speed;
    public float jumpForce;
    public float gravity;
    public float terminalvelocity;
    Vector3 movement;

    public Transform GroundCheck;
    bool GroundTouch;

    public Transform CeillingCheck;
    bool CeillingTouch;

    public GameObject BubblePrefab;
    public float ShotSpeed;
    
    private PlayerInput playerInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        PRenderer = rb.GetComponent<SpriteRenderer>();
        playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        //supposedly this thing reads input from the "player input" object and spits out a vector2
        Vector2 input = playerInput.actions["Move"].ReadValue<Vector2>();
        
        
        //Sets the X movement equal to the speed in the positive or negative direction
        //movement.x = Input.GetAxis("Horizontal") * speed;
        movement.x = input.x * speed;

        //checks if there is a collider on the "Ground" layer below the player
        //REMEMBER: All ground objs must be on the 3rd layer
        GroundTouch = false;
        Collider2D[] Below = Physics2D.OverlapCircleAll(GroundCheck.position, 0.1f);
        foreach (Collider2D b in Below)
        {
            if (b.gameObject.layer == 3)
            {
                GroundTouch = true;
            }
        }

        //checks if there is a collider on the "Ground" layer above the player
        CeillingTouch = false;
        Collider2D[] Above = Physics2D.OverlapCircleAll(CeillingCheck.position, 0.1f);
        foreach (Collider2D a in Above)
        {
            if (a.gameObject.layer == 3)
            {
                CeillingTouch = true;
            }
        }

        //Sets the Y movement to the Jump Force if either W or the UpArrow are pushed, and there is Ground below
        /*if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && GroundTouch)
        {
            movement.y = jumpForce;
        }
        */
        
        //so I THINK this reads from "player input" object, and when you press the designated key that's assigned
        //it will basically say "input triggered" and do things
        //by default the key is space, space used for shoot MAKES NO SENSE 
        if (playerInput.actions["Jump"].triggered && GroundTouch && !PauseGame.isPaused)
        {
            movement.y = jumpForce;
        }
        
        //flips the player sprite according to movement
        if (movement.x < 0)
        {
            PRenderer.flipX = true;
        }
        if (movement.x > 0)
        {
            PRenderer.flipX = false;
        }
        
        //if (Input.GetKeyDown(KeyCode.Space))
        //by default is left mouse button (or trigger? or key?, idk the right term here)
        if (playerInput.actions["Shoot"].triggered && !PauseGame.isPaused)
        {
            if (PRenderer.flipX)
            {
                Shoot(-1, ShotSpeed);
            }
            else
            {
                Shoot(1, ShotSpeed);
            }
        }

    }

    private void FixedUpdate()
    {
        //subtracts gravity from the Y movement, capped at the terminal velocity
        if (movement.y > terminalvelocity)
        {
            movement.y -= gravity;
        }
        else
        {
            movement.y = terminalvelocity;
        }

        //stops jump if hits ceilling, stops gravity force if touching ground
        if (CeillingTouch && movement.y > 0)
        {
            movement.y = 0;
        }
        if (GroundTouch && movement.y < 0)
        {
            movement.y = 0;
        }

        //adds the movement to the player's current position
        rb.MovePosition(transform.position + movement * Time.deltaTime);
    }

    void Shoot(int Dir, float Fast)
    {
        GameObject bubble = Instantiate(BubblePrefab, transform.position, Quaternion.identity);
        bubble.GetComponent<Shot>().Direction = Dir;
        bubble.GetComponent<Shot>().Speed = Fast;
        Destroy(bubble, 4f);
    }
}
