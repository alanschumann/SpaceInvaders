using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float life;
    int typeOfEnemy;
    public bool isDetectable;
    Animator animator;
    float points;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    private void Start()
    {
        isDetectable = true;
        typeOfEnemy = Random.Range(0, 4);
        animator.SetInteger("Type", typeOfEnemy);
        if (typeOfEnemy == 3)
        {
            this.gameObject.name = "Red";
            life = 2;
        }
        if (typeOfEnemy == 2)
        {
            this.gameObject.name = "Yellow";
            life = 2;
        }
        if (typeOfEnemy == 1)
        {
            this.gameObject.name = "Green";
            life = 1;
        }
        if (typeOfEnemy == 0)
        {
            this.gameObject.name = "Blue";
            life = 1;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<IBullet>() != null)
        {
            isDetectable = false;
            life--;
            DestroyEnemyFunc();
        }
        else
        {
            print("Shtoo");
        }

    }




    public void DestroyEnemyFunc()
    {
        StartCoroutine(FindFriends());
        animator.SetTrigger("Damage");
        if (life <= 0)
        {
            StartCoroutine(DestroyEnemy());
        }

    }

    public IEnumerator DestroyEnemy()
    {
        
        animator.SetTrigger("Death");
        yield return new WaitForSeconds(1f);
        if (this.gameObject.name == "Red")
        {
            GameController gc = FindObjectOfType<GameController>();
            gc.score += 10;
        }
        if (this.gameObject.name == "Yellow")
        {
            GameController gc = FindObjectOfType<GameController>();
            gc.score += 5;
        }
        if (this.gameObject.name == "Green")
        {
            GameController gc = FindObjectOfType<GameController>();
            gc.score += 2;
        }
        if (this.gameObject.name == "Blue")
        {
            GameController gc = FindObjectOfType<GameController>();
            gc.score += 1;
        }
        Destroy(this.gameObject);
    }


    IEnumerator FindFriends()
    {


        RaycastHit2D hitUp = Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y + 0.3f), transform.up, 0.6f);
        if (hitUp && hitUp.collider.name == this.gameObject.name)
        {
            var go = hitUp.collider.GetComponent<Enemy>();
            go.life = life;
            if (go.isDetectable)
            {
                go.DestroyEnemyFunc();
                go.isDetectable = false;
            }
        }
        yield return new WaitForSeconds(0.1f);
        RaycastHit2D hitRight = Physics2D.Raycast(new Vector3(transform.position.x + 0.35f, transform.position.y), transform.right, 0.6f);
        if (hitRight && hitRight.collider.name == this.gameObject.name)
        {
            var go = hitRight.collider.GetComponent<Enemy>();
            go.life = life;
            if (go.isDetectable)
            {
                go.DestroyEnemyFunc();
                go.isDetectable = false;
            }

        }
        yield return new WaitForSeconds(0.1f);
        RaycastHit2D hitLeft = Physics2D.Raycast(new Vector3(transform.position.x - 0.35f, transform.position.y), -transform.right, 0.6f);
        if (hitLeft && hitLeft.collider.name == this.gameObject.name)
        {
            var go = hitLeft.collider.GetComponent<Enemy>();
            go.life = life;
            if (go.isDetectable)
            {
                go.DestroyEnemyFunc();
                go.isDetectable = false;
            }

        }
        yield return new WaitForSeconds(0.1f);
        RaycastHit2D hitDown = Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y - 0.35f), -transform.up, 0.6f);
        if (hitDown && hitDown.collider.name == this.gameObject.name)
        {

            var go = hitDown.collider.GetComponent<Enemy>();
            go.life = life;
            if (go.isDetectable)
            {
                go.DestroyEnemyFunc();
                go.isDetectable = false;
            }

        }
        
        isDetectable = true;
    }

}

