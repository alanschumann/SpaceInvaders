using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] EnemyManager enemyManager;
    [SerializeField] Player player;
    [SerializeField] StartButton startButton;
    [SerializeField] ExitButton exitButton;
    public GameObject panelInGameGO, startButtonGO, quitButtonGO, enemyManagerGO, panelScore, panelInstructions;
    public Text scoreCanvas, finalScore, countDown;
    public Image lifeCanvas;

    bool loose;
    public int score;
    public int life;
    float currCountdownValue;
    void Start()
    {
        loose = false;
        Cursor.visible = false;
        panelScore.SetActive(false);
        startButtonGO.SetActive(true);
        quitButtonGO.SetActive(true);
        panelInGameGO.SetActive(false);
        enemyManagerGO.SetActive(false);
        panelInstructions.SetActive(true);
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




    public IEnumerator StartCountdown(float countdownValue = 5)
    {
        removeBullets();
        panelScore.SetActive(true);
        finalScore.text = "YOUR SCORE       " + score;
        enemyManagerGO.SetActive(false);
        panelInGameGO.SetActive(false);
        currCountdownValue = countdownValue;
        while (currCountdownValue > 0)
        {
           countDown.text="BACK TO MENU IN   " + currCountdownValue;
            yield return new WaitForSeconds(1f);
            currCountdownValue--;
        }
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }


    void removeBullets()
    {
        Bullet[] bullets = FindObjectsOfType<Bullet>();
        for (int i = 0; i < bullets.Length; i++)
        {
            bullets[i].gameObject.SetActive(false);
        }
    }


    void initGame()
    {
        enemyManagerGO.SetActive(true);
        panelInGameGO.SetActive(true);
        quitButtonGO.SetActive(false);
        startButtonGO.SetActive(false);
        enemyManager.CreateGrid();
        panelInstructions.SetActive(false);
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
        if (life == 0 && loose == false)
        {
            lifeCanvas.fillAmount = 0.0f;
            loose = true;
            if (loose)
                StartCoroutine(StartCountdown());
        }

    }



}
