using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenueCanvas : MonoBehaviour
{
    public GameController gameController;
    public GameCanvas gameCanvas;

    public RectTransform canvasMenue;
    public RectTransform canvasShop;

    public RectTransform panelShips;
    public RectTransform panelRockets;

    public GameObject playerMenueTexture;
    public GameObject onlyBackground;

    public Text gold;
    public Text extraLife;
    public Text ammunitionText;

    public Text ship1PriceText;
    public Text ship2PriceText;
    public Text ship3PriceText;
    public Text ship4PriceText;

    public Text rocket1PriceText;
    public Text rocket2PriceText;
    public Text rocket3PriceText;
    public Text rocket4PriceText;

    public Button buyButtonShip1;
    public Button buyButtonShip2;
    public Button buyButtonShip3;
    public Button buyButtonShip4;

    public Button buyButtonRocket1;
    public Button buyButtonRocket2;
    public Button buyButtonRocket3;
    public Button buyButtonRocket4;

    public GameObject menueShip1;
    public GameObject menueShip2;
    public GameObject menueShip3;
    public GameObject menueShip4;

    public List<GameObject> jetStreamsShip1 = new List<GameObject>();
    public List<GameObject> jetStreamsShip2 = new List<GameObject>();
    public List<GameObject> jetStreamsShip3 = new List<GameObject>();
    public List<GameObject> jetStreamsShip4 = new List<GameObject>();

    public Sprite haken;
    public Sprite flaeche;

    public Player playerRef;

    public Text highScoreInfo;

    public int ship1Costs;
    public int ship2Costs;
    public int ship3Costs;
    public int ship4Costs;

    public int rocket1Costs;
    public int rocket2Costs;
    public int rocket3Costs;
    public int rocket4Costs;

    public int munitionCost;

    private void Start()
    {
        ship1PriceText.text = ship1Costs.ToString();
        ship2PriceText.text = ship2Costs.ToString();
        ship3PriceText.text = ship3Costs.ToString();
        ship4PriceText.text = ship4Costs.ToString();

        rocket1PriceText.text = rocket1Costs.ToString();
        rocket2PriceText.text = rocket2Costs.ToString();
        rocket3PriceText.text = rocket3Costs.ToString();
        rocket4PriceText.text = rocket4Costs.ToString();

        if (gameController.ship1Selected)
        {
            setPlayerMenueTextureShipsDeaktivateAll();
            setPlayerMenueTextureShipsAktivate(menueShip1);

            setSelectedHakenSprite(gameController.ship1Selected, buyButtonShip1);
        }

        if (gameController.ship2Selected)
        {
            setPlayerMenueTextureShipsDeaktivateAll();
            setPlayerMenueTextureShipsAktivate(menueShip2);

            setSelectedHakenSprite(gameController.ship2Selected, buyButtonShip2);
        }
        if (gameController.ship3Selected)
        {
            setPlayerMenueTextureShipsDeaktivateAll();
            setPlayerMenueTextureShipsAktivate(menueShip3);

            setSelectedHakenSprite(gameController.ship3Selected, buyButtonShip3);
        }
        if (gameController.ship4Selected)
        {
            setPlayerMenueTextureShipsDeaktivateAll();
            setPlayerMenueTextureShipsAktivate(menueShip4);

            setSelectedHakenSprite(gameController.ship4Selected, buyButtonShip4);
        }

        if (gameController.rocket1Selected)
            setSelectedHakenSprite(gameController.rocket1Selected, buyButtonRocket1);
        if (gameController.rocket2Selected)
            setSelectedHakenSprite(gameController.rocket2Selected, buyButtonRocket2);
        if (gameController.rocket3Selected)
            setSelectedHakenSprite(gameController.rocket3Selected, buyButtonRocket3);
        if (gameController.rocket4Selected)
            setSelectedHakenSprite(gameController.rocket4Selected, buyButtonRocket4);

    }

    private void Update()
    {
        gold.text = gameController.goldAll.ToString();
        extraLife.text = gameController.extraLife.ToString();
        ammunitionText.text = gameController.ammunition.ToString();
        highScoreInfo.text = "High Score: " + gameController.highScoreMax.ToString();

        if (gameController.ammunition <= 50)
        {
            gameController.ammunition = 50;
        }
    }

    //MainMenue///////////////////////////////////////////////////////////////////////////////////////
    public void onClickButtonMenuePanel_ExitGame()
    {
        Application.Quit();
    }
    public void onClickButtonMenuePanel_EnterGame()
    {
        gameController.menue.gameObject.SetActive(false);

        gameController.game.gameObject.SetActive(true);
        gameController.game.gameCanvas.gameObject.SetActive(true);

        gameController.game.createLevel();
    }
    public void onClickButtonMenuePanel_EnterShop()
    {
        canvasMenue.gameObject.SetActive(false);

        canvasShop.gameObject.SetActive(true);
    }

    //ShopCanvas///////////////////////////////////////////////////////////////////////////////////////
    public void onClickButton_Ships()
    {
        enterRocketOrShipShop(panelShips);
    }
    public void onClickButton_Rockets()
    {
        enterRocketOrShipShop(panelRockets);
    }

    public void onClickButton_Munition()
    {
        if (gameController.goldAll >= munitionCost)
        {
            gameController.goldAll -= munitionCost;

            gameController.ammunition += 10;
        }
    }

    public void onClickButtonShopPanel_Back()
    {
        canvasShop.gameObject.SetActive(false);

        canvasMenue.gameObject.SetActive(true);
    }

    //ShipCanvas///////////////////////////////////////////////////////////////////////////////////////
    public void onClickButton_BuySelectShip1()
    {
        buySelectShipOrRocket(true, ref gameController.ship1Buyed, ref gameController.ship1Selected, ref buyButtonShip1, ship1Costs);

        //setPlayerMenueTextureShipsDeaktivateAll();
        //setPlayerMenueTextureShipsAktivate(menueShip1);
    }
    public void onClickButton_BuySelectShip2()
    {
        buySelectShipOrRocket(true, ref gameController.ship2Buyed, ref gameController.ship2Selected, ref buyButtonShip2, ship2Costs);

        //setPlayerMenueTextureShipsDeaktivateAll();
        //setPlayerMenueTextureShipsAktivate(menueShip2);
    }
    public void onClickButton_BuySelectShip3()
    {
        buySelectShipOrRocket(true, ref gameController.ship3Buyed, ref gameController.ship3Selected, ref buyButtonShip3, ship3Costs);

        //setPlayerMenueTextureShipsDeaktivateAll();
        //setPlayerMenueTextureShipsAktivate(menueShip3);
    }
    public void onClickButton_BuySelectShip4()
    {
        buySelectShipOrRocket(true, ref gameController.ship4Buyed, ref gameController.ship4Selected, ref buyButtonShip4, ship4Costs);

        //setPlayerMenueTextureShipsDeaktivateAll();
        //setPlayerMenueTextureShipsAktivate(menueShip4);
    }

    public void onClickButtonShipPanel_Back()
    {
        panelShips.gameObject.SetActive(false);

        if (gameController.ship1Selected)
            setPlayerMenueTextureShipEnableTrue(menueShip1, jetStreamsShip1);
        if (gameController.ship2Selected)
            setPlayerMenueTextureShipEnableTrue(menueShip2, jetStreamsShip2);
        if (gameController.ship3Selected)
            setPlayerMenueTextureShipEnableTrue(menueShip3, jetStreamsShip3);
        if (gameController.ship4Selected)
            setPlayerMenueTextureShipEnableTrue(menueShip4, jetStreamsShip4);

        canvasShop.gameObject.SetActive(true);
    }

    //RockedCanvas///////////////////////////////////////////////////////////////////////////////////////
    public void onClickButton_BuySelectRocket1()
    {
        buySelectShipOrRocket(false, ref gameController.rocket1Buyed, ref gameController.rocket1Selected, ref buyButtonRocket1, rocket1Costs);
    }
    public void onClickButton_BuySelectRocket2()
    {
        buySelectShipOrRocket(false, ref gameController.rocket2Buyed, ref gameController.rocket2Selected, ref buyButtonRocket2, rocket2Costs);
    }
    public void onClickButton_BuySelectRocket3()
    {
        buySelectShipOrRocket(false, ref gameController.rocket3Buyed, ref gameController.rocket3Selected, ref buyButtonRocket3, rocket3Costs);
    }
    public void onClickButton_BuySelectRocket4()
    {
        buySelectShipOrRocket(false, ref gameController.rocket4Buyed, ref gameController.rocket4Selected, ref buyButtonRocket4, rocket4Costs);
    }

    public void onClickButtonRocketPanel_Back()
    {
        panelRockets.gameObject.SetActive(false);

        canvasShop.gameObject.SetActive(true);
    }

    //Functions for Shorting///////////////////////////////////////////////////////////////////////////////////////

    private void buySelectShipOrRocket(bool isShip, ref bool buyed, ref bool selected, ref Button buyButton, int shipCosts)
    {
        if (buyed)
        {
            if (isShip)
                setAllSelectedShipsBoolsFalse();
            else
                setAllSelectedRocketsBoolsFalse();

            selected = true;

            buyButton.GetComponent<Image>().sprite = haken;
        }
        else
        {
            if (gameController.goldAll >= shipCosts)
            {
                buyed = true;

                if (isShip)
                    setAllSelectedShipsBoolsFalse();
                else
                    setAllSelectedRocketsBoolsFalse();

                gameController.goldAll -= shipCosts;

                selected = true;

                buyButton.GetComponent<Image>().sprite = haken;
            }
        }
    }
    private void enterRocketOrShipShop(RectTransform shop)
    {
        canvasShop.gameObject.SetActive(false);

        setPlayerMenueTextureShipsEnabledFalseAll();

        shop.gameObject.SetActive(true);
    }
    private void setAllSelectedShipsBoolsFalse()
    {
        gameController.ship1Selected = false;
        gameController.ship2Selected = false;
        gameController.ship3Selected = false;
        gameController.ship4Selected = false;

        setNotSelectedHakenSprite(gameController.ship1Buyed, buyButtonShip1);
        setNotSelectedHakenSprite(gameController.ship2Buyed, buyButtonShip2);
        setNotSelectedHakenSprite(gameController.ship3Buyed, buyButtonShip3);
        setNotSelectedHakenSprite(gameController.ship4Buyed, buyButtonShip4);
    }
    private void setAllSelectedRocketsBoolsFalse()
    {
        gameController.rocket1Selected = false;
        gameController.rocket2Selected = false;
        gameController.rocket3Selected = false;
        gameController.rocket4Selected = false;

        setNotSelectedHakenSprite(gameController.rocket1Buyed, buyButtonRocket1);
        setNotSelectedHakenSprite(gameController.rocket2Buyed, buyButtonRocket2);
        setNotSelectedHakenSprite(gameController.rocket3Buyed, buyButtonRocket3);
        setNotSelectedHakenSprite(gameController.rocket4Buyed, buyButtonRocket4);
    }
    private void setNotSelectedHakenSprite(bool buyed, Button buyButton)
    {
        if (buyed)
        {
            buyButton.GetComponent<Image>().sprite = flaeche;
        }
    }
    private void setSelectedHakenSprite(bool selected, Button buyButton)
    {
        if (selected)
        {
            buyButton.GetComponent<Image>().sprite = haken;
        }
    }

    private void setPlayerMenueTextureShipsDeaktivateAll()
    {
        menueShip1.gameObject.SetActive(false);
        menueShip2.gameObject.SetActive(false);
        menueShip3.gameObject.SetActive(false);
        menueShip4.gameObject.SetActive(false);
    }

    private void setPlayerMenueTextureShipsEnabledFalseAll()
    {
        menueShip1.GetComponent<SpriteRenderer>().enabled = false;
        menueShip2.GetComponent<SpriteRenderer>().enabled = false;
        menueShip3.GetComponent<SpriteRenderer>().enabled = false;
        menueShip4.GetComponent<SpriteRenderer>().enabled = false;

        foreach (var jetstream in jetStreamsShip1)
        {
            jetstream.GetComponent<SpriteRenderer>().enabled = false;
        }
        foreach (var jetstream in jetStreamsShip2)
        {
            jetstream.GetComponent<SpriteRenderer>().enabled = false;
        }
        foreach (var jetstream in jetStreamsShip3)
        {
            jetstream.GetComponent<SpriteRenderer>().enabled = false;
        }
        foreach (var jetstream in jetStreamsShip4)
        {
            jetstream.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void setPlayerMenueTextureShipEnableTrue(GameObject ship, List<GameObject> jetstream)
    {
        ship.gameObject.SetActive(true);

        foreach (var stream in jetstream)
        {
            stream.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
    private void setPlayerMenueTextureShipsAktivate(GameObject ship)
    {
        ship.gameObject.SetActive(true);
    }
}
