using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AfterLevelCanvas : MonoBehaviour
{
    public GameObject menue;

    public Text collectedGoldText;
    public Text calculatedGoldText;

    public Text extraLifeText;
    public Text hittedAsteroidText;
    public Text scoreText;

    public bool activeBecauseGameOver;
    public bool activeBecauseGameWon;
    public bool activeBecauseGamePaused;

    public int goldNetto;

    // On Click Button Back To Menue in Game Class

    private void Update()
    {
        if(FindObjectOfType<Player>().projectiles.Count != 0)
        {
            foreach(Projectile item in FindObjectOfType<Player>().projectiles)
            {
                FindObjectOfType<Player>().projectiles.Remove(item);
                Destroy(item.gameObject);
            }
        }
        else
        {
            setAndCalculateGoldNetto();

            hittedAsteroidText.text = "Hitted Asteroids: " + FindObjectOfType<Game>().hittetAsteroids.ToString();

            setAndCalculateHightScore();
        }
    }

    private void setAndCalculateGoldNetto()
    {
        goldNetto = (int)(FindObjectOfType<Game>().collectedGold * (MathF.Round(FindObjectOfType<Game>().hitQuote * 2, 2)));

        calculatedGoldText.text = "Gold: " + FindObjectOfType<Game>().collectedGold.ToString() + " + " + "Hit Quote * " + (MathF.Round(FindObjectOfType<Game>().hitQuote * 2, 2)) + " = " + goldNetto;        

        collectedGoldText.text = FindObjectOfType<Game>().collectedGold.ToString();
    }

    public void addGoldNetooToGameGold()
    {
        FindObjectOfType<GameController>().goldAll += goldNetto;
    }

    private void setAndCalculateHightScore()
    {
        var highscore = (int)(FindObjectOfType<Game>().score * (MathF.Round(FindObjectOfType<Game>().hitQuote * 2, 2)));

        if (highscore > FindObjectOfType<GameController>().highScoreMax)
        {
            FindObjectOfType<GameController>().highScoreMax = highscore;
        }

        scoreText.text = "Score: " + FindObjectOfType<Game>().score.ToString() + " + " + "Hit Quote * " + (MathF.Round(FindObjectOfType<Game>().hitQuote * 2, 2)) + " = " + highscore;
    }
}
