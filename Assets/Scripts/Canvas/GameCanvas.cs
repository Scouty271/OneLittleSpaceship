using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCanvas : MonoBehaviour
{
    public Text healthText;
    public Text ammunitionText;
    public Text goldText;

    public Text addedGold;

    public Game game;

    public Canvas afterLevelCanvas;

    private void Update()
    {
        if (FindObjectOfType<Player>() != null)
        {
            healthText.text = FindObjectOfType<Player>().health.ToString();
            ammunitionText.text = FindObjectOfType<GameController>().ammunition.ToString();
            goldText.text = FindObjectOfType<Game>().collectedGold.ToString();
        }
    }

    public void goFromGameCanvasToAfterGameCanvas()
    {
        afterLevelCanvas.gameObject.SetActive(true);

        gameObject.SetActive(false);
    }
}
