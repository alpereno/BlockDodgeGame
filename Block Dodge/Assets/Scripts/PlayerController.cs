using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public event System.Action onPlayerDeath;
    [SerializeField] private float speed = 7;
    float screenHalfWidthWorldUnits;
    float halfPlayerWidth;
    float orthographicSize;
    //in orthographic mode size value is equal to screen half height on world units. = orthographicSize = screen height / 2
    //aspect ratio = screen width / screen height

    private void Start()
    {
        orthographicSize = Camera.main.orthographicSize;
        halfPlayerWidth = transform.localScale.x / 2;
        screenHalfWidthWorldUnits = Camera.main.aspect * orthographicSize;
    }

    private void Update()
    {
        move();
        checkBorder();
    }

    private void move()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        Vector2 velocity = moveInput * speed;
        transform.Translate(velocity * Time.deltaTime);
    }

    private void checkBorder()
    {
        //player can teleport when reaches the screen border
        //if you don't want to teleport you can delete "-" and add "+" signs in new vector2 line
        if (transform.position.x < -screenHalfWidthWorldUnits - halfPlayerWidth)
        {
            transform.position = new Vector2(screenHalfWidthWorldUnits, transform.position.y);
        }
        if (transform.position.x > screenHalfWidthWorldUnits + halfPlayerWidth)
        {
            transform.position = new Vector2(-screenHalfWidthWorldUnits, transform.position.y);
        }

        //up and down border
        //plyar can't teleport
        if (transform.position.y > orthographicSize)
        {
            transform.position = new Vector2(transform.position.x, orthographicSize);
        }
        if (transform.position.y < -orthographicSize)
        {
            transform.position = new Vector2(transform.position.x, -orthographicSize);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Block"))
        {   //check if is it null 
            if (onPlayerDeath != null)
            {
                onPlayerDeath();
            }
            Destroy(gameObject);
        }
    }
}
