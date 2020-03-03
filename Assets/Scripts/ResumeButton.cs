using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeButton : MonoBehaviour
{
    public bool canResume;
    private void Start()
    {
        canResume = false;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Bullet>() != null)
        {
            canResume = true;
        }
    }
}
