using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public int life;
    private Rigidbody2D rb2d;
    private SpriteRenderer sp;
    Color colorDamage = Color.red;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
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
        
    }


    private void ApplyInput()
    {
        float xinput = Input.GetAxis("Horizontal");
        float xForce = xinput * speed * Time.deltaTime * 10;
        rb2d.velocity = new Vector2(xForce, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Enemy>() != null)
        {
            life--;
            StartCoroutine(DamageColor());
        }
        if (collision.collider.GetComponent<IBullet>() != null)
        {
            life--;
            StartCoroutine(DamageColor());
        }
    }

    IEnumerator DamageColor()
    {
        float i = 0;
        while (i<1)
        {
            sp.color = colorDamage;
            yield return new WaitForSeconds(0.03f);
            sp.color = Color.white;
            yield return new WaitForSeconds(0.03f);
            i += 0.1f;
        }
    }
}
