using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    EnemyManager enemyManager;
    Player player;
    public Text scoreCanvas;
    public Image lifeCanvas;

    public int score;
    public int life;
    void Start()
    {
        enemyManager = FindObjectOfType<EnemyManager>();
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        Score();
        Life();
    }

    void Score()
    {
        scoreCanvas.text = ("Score: "+score);
    }

    void Life()
    {
        life = player.life;
        print(life);
        if (life == 3)
        {
            lifeCanvas.fillAmount = 1;
        }
        if (life == 2)
        {
            lifeCanvas.fillAmount = 0.66f;
        }
        if (life == 1)
        {
            lifeCanvas.fillAmount = 0.33f;
        }
        if (life == 0)
        {
            lifeCanvas.fillAmount = 0.0f;
        }

    }



}
