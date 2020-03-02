using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet :MonoBehaviour, IBullet
{
    public float velocity;
    private Rigidbody2D rb2d;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        StartCoroutine(DestroyOnTime());
    }
    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(0, velocity * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }

    IEnumerator DestroyOnTime()
    {
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }
}
