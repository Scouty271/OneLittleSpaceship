using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public float hittetAsteroids;
    public float shootetProjectilesForQuote;

    public bool gameOverLoose;
    public bool gameOverWin;

    public Text scoreText;

    public int score;

    public GameController gameController;

    public GameCanvas gameCanvas;
    public AfterLevelCanvas afterLevelCanvas;

    public Player currPlayer;

    public AsteroidSpawner asteroidSpawnerRef;
    public AsteroidSpawner currAsteroidSpawner;

    public Image imageGoldAfterLevelCanvas;

    public float hitQuote;

    public int collectedGold;

    public Player player1;
    public Player player2;
    public Player player3;
    public Player player4;

    public Projectile projectile1;
    public Projectile projectile2;
    public Projectile projectile3;
    public Projectile projectile4;

    private void Update()
    {
        if (shootetProjectilesForQuote != 0)
        {
            hitQuote = hittetAsteroids / shootetProjectilesForQuote;
        }
    }

    public void setGameOverWin()
    {
        gameOverWin = true;

        afterLevelCanvas.activeBecauseGameWon = true;

        gameCanvas.goFromGameCanvasToAfterGameCanvas();
    }

    public void setGameOverLoose()
    {
        gameOverLoose = true;

        afterLevelCanvas.activeBecauseGameOver = true;

        gameCanvas.goFromGameCanvasToAfterGameCanvas();
    }

    public void createLevel()
    {
        if (FindObjectOfType<GameController>().ship1Selected)
            currPlayer = Instantiate(player1, transform);

        if (FindObjectOfType<GameController>().ship2Selected)
            currPlayer = Instantiate(player2, transform);

        if (FindObjectOfType<GameController>().ship3Selected)
            currPlayer = Instantiate(player3, transform);

        if (FindObjectOfType<GameController>().ship4Selected)
            currPlayer = Instantiate(player4, transform);

        currAsteroidSpawner = Instantiate(asteroidSpawnerRef, transform);
    }

    public void exitLevel()
    {
        Destroy(currPlayer.gameObject);
        Destroy(currAsteroidSpawner.gameObject);
    }

    public void onClickButton_PauseGame()
    {
        gameCanvas.goFromGameCanvasToAfterGameCanvas();

        afterLevelCanvas.activeBecauseGamePaused = true;

        gameCanvas.gameObject.SetActive(false);

        currPlayer.enabled = false;

        currAsteroidSpawner.gameObject.SetActive(false);
    }

    public void onClickButton_BackToMenue()
    {
        FindObjectOfType<AfterLevelCanvas>().addGoldNetooToGameGold();

        FindObjectOfType<GameController>().menue.gameObject.SetActive(true);

        exitLevel();

        afterLevelCanvas.gameObject.SetActive(false);

        gameObject.SetActive(false);

        initializeAllValues();

        resetAfterLevelCanvasBools();
    }

    public void onClickButton_newGame()
    {
        FindObjectOfType<AfterLevelCanvas>().addGoldNetooToGameGold();

        exitLevel();

        afterLevelCanvas.gameObject.SetActive(false);

        initializeAllValues();

        resetAfterLevelCanvasBools();

        FindObjectOfType<GameController>().menue.GetComponentInChildren<MenueCanvas>().onClickButtonMenuePanel_EnterGame();
    }

    public void onClickButton_resumeGame()
    {
        if (afterLevelCanvas.activeBecauseGameOver && FindObjectOfType<GameController>().extraLife >= 1)
        {
            FindObjectOfType<GameController>().extraLife--;

            gameOverLoose = false;
            gameOverWin = false;

            currPlayer.health = 5;

            resetAfterLevelCanvasBools();

            gameCanvas.gameObject.SetActive(true);

            afterLevelCanvas.gameObject.SetActive(false);
        }

        if (afterLevelCanvas.activeBecauseGamePaused)
        {
            afterLevelCanvas.gameObject.SetActive(false);

            gameCanvas.gameObject.SetActive(true);

            currPlayer.enabled = true;

            currAsteroidSpawner.gameObject.SetActive(true);
        }
    }

    private void initializeAllValues()
    {
        gameOverLoose = false;
        gameOverWin = false;

        hittetAsteroids = 0;
        shootetProjectilesForQuote = 0;

        if (gameOverWin)
        {
            collectedGold *= 3;
        }

        hitQuote = 0;

        collectedGold = 0;
    }

    private void resetAfterLevelCanvasBools()
    {
        afterLevelCanvas.activeBecauseGameOver = false;
        afterLevelCanvas.activeBecauseGameWon = false;
        afterLevelCanvas.activeBecauseGamePaused = false;
    }
}
