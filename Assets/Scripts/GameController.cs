using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int goldAll;
    public int extraLife;
    public int ammunition;
    public int highScoreMax;

    public int hittetAsteroidsAll;

    public bool ship1Buyed;
    public bool ship2Buyed;
    public bool ship3Buyed;
    public bool ship4Buyed;

    public bool rocket1Buyed;
    public bool rocket2Buyed;
    public bool rocket3Buyed;
    public bool rocket4Buyed;

    public bool ship1Selected;
    public bool ship2Selected;
    public bool ship3Selected;
    public bool ship4Selected;

    public bool rocket1Selected;
    public bool rocket2Selected;
    public bool rocket3Selected;
    public bool rocket4Selected;

    public Game game;
    public Menue menue;

    private void Start()
    {
        // Ladefunktionen aufrufen
        ship1Buyed = true;
        rocket1Buyed = true;

        ship1Selected = true;
        rocket1Selected = true;
    }
}
