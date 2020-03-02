using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemy;
    public int[,] Grid;
    int Columns, Rows;
    bool right, left;
    Vector3 initPosition;
    void Start()
    {
        initPosition = transform.position;
        StartCoroutine(MakeGrid());
    }

    void Update()
    {

        if (right)
        {
            StartCoroutine(MovingRight());
        }
        if (left)
        {
            StartCoroutine(MovingLeft());
        }
    }

    IEnumerator MovingRight()
    {
        right = false;
        for (float i = transform.position.x; i <= 4; i+=0.2f)
        {
            transform.position = new Vector3(i, transform.position.y);
            yield return new WaitForSeconds(0.5f);
        }
        transform.position += new Vector3(0, - 0.5f);
        left = true;
    }
    IEnumerator MovingLeft()
    {
        left = false;
        for (float i = transform.position.x; i >= -4; i -= 0.2f)
        {
            transform.position = new Vector3(i, transform.position.y);
            yield return new WaitForSeconds(0.5f);
        }
        transform.position += new Vector3(0, -0.5f);
        right = true;
    }


    IEnumerator MakeGrid()
    {
        Columns = 10;
        Rows = 4;
        Grid = new int[Columns, Rows];
        for (int i = 0; i < Columns; i++)
        {
            for (int j = 0; j < Rows; j++)
            {
                Grid[i, j] = Random.Range(0, 10);
                SpawnEnemies(i, j, Grid[i, j]);
                yield return new WaitForSeconds(0.05f);
            }
        }
        right = true;
    }

    void SpawnEnemies(int x, int y, int value)
    {
        var go = Instantiate(enemy, new Vector3(x - (5 - 0.5f), y - (0 - 0.5f)), Quaternion.identity);
        go.transform.parent = this.transform;
    }
}
