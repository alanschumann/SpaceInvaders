using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] EnemyManager enemyManager;
    [SerializeField] Player player;
    [SerializeField] StartButton startButton;
    [SerializeField] ExitButton exitButton;
    public GameObject panelInGameGO, startButtonGO, quitButtonGO, enemyManagerGO;
    public Text scoreCanvas;
    public Image lifeCanvas;


    public int score;
    public int life;
    void Start()
    {
        Cursor.visible = false;
        startButtonGO.SetActive(true);
        quitButtonGO.SetActive(true);
        panelInGameGO.SetActive(false);
        enemyManagerGO.SetActive(false);
    }

    void Update()
    {
        if (startButtonGO)
        {
            if (startButton.canStart)
            {
                initGame();
            }
        }

        if (quitButtonGO)
        {
            if (exitButton.canExit)
            {
                Application.Quit();
            }
        }



        Score();
        Life();
    }



    void initGame()
    {
        enemyManagerGO.SetActive(true);
        panelInGameGO.SetActive(true);
        quitButtonGO.SetActive(false);
        startButtonGO.SetActive(false);
        enemyManager.CreateGrid();
        startButton.canStart = false;
    }



    void Score()
    {
        scoreCanvas.text = ("Score: " + score);
    }

    void Life()
    {
        life = player.life;
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
