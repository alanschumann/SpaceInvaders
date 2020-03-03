using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public bool canStart;
    private void Start()
    {
        canStart = false;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Bullet>() != null)
        {
            canStart = true;
        }
    }

}
