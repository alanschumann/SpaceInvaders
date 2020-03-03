using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public bool canExit;
    private void Start()
    {
        canExit = false;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Bullet>() != null)
        {
            canExit = true;
        }
    }
}
