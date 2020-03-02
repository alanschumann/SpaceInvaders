using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPoint : MonoBehaviour
{
    public float velocityBullet;
    public GameObject bullet;
    public GameObject smoke;
    bool instantiateBullet;

    private void Start()
    {
        smoke.SetActive(false);
    }
    public void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Smoke());
            SpawnBullet();
        }
    }

    void SpawnBullet()
    {
        GameObject newBala = Instantiate(bullet, transform.position, Quaternion.identity);
        Bullet controlBullet = newBala.GetComponent<Bullet>();
        controlBullet.velocity = velocityBullet;
    }

    IEnumerator Smoke()
    {
        smoke.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        smoke.SetActive(false);
    }
}
