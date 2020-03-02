using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public int life;
    private Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Start()
    {

    }

    private void FixedUpdate()
    {
        ApplyInput();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            life--;
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            life++;
        }
    }


    private void ApplyInput()
    {
        float xinput = Input.GetAxis("Horizontal");
        float xForce = xinput * speed * Time.deltaTime * 10;
        rb2d.velocity = new Vector2(xForce, 0);

    }
}
