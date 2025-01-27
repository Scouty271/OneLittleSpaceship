using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Player : MonoBehaviour
{
    public GameObject gameOverExplositon;

    public List<GameObject> jetStreams = new List<GameObject>();

    public GameObject gameOverExplosion;

    public List<Projectile> projectiles = new List<Projectile>();

    public int health;

    public float beginSpeed;
    public float currSpeed;
    public float maxAcceleration;

    private void Update()
    {
        if (FindObjectOfType<Game>().gameOverLoose || FindObjectOfType<Game>().gameOverWin)
        {
            //Explosionen oder Sieges Effekte
        }
        else
        {
            transform.Translate(new Vector3(0, currSpeed * Time.deltaTime, 0));

            if(currSpeed < 30)
            {
                currSpeed = (transform.position.y / (5000 / (maxAcceleration - beginSpeed))) + beginSpeed;
            }
        }

        if (health <= 0)
        {
            FindObjectOfType<Game>().setGameOverLoose();

            gameOverExplositon.SetActive(true);

            foreach (GameObject item in jetStreams) 
            {
                item.gameObject.SetActive(false);
            }
        }
        else
        {
            FindObjectOfType<Game>().gameOverLoose = false;

            gameOverExplositon.SetActive(false);

            foreach (GameObject item in jetStreams)
            {
                item.gameObject.SetActive(true);
            }
        }

        //FindObjectOfType<Game>().score = (((int)transform.position.y + 50) + ((int)FindObjectOfType<Game>().hittetAsteroids * 10));

        //FindObjectOfType<Game>().scoreText.text ="Score: " + FindObjectOfType<Game>().score;

        berrechneUndSetzeScoreText();

        if (transform.position.y >= 10000)
        {
            FindObjectOfType<Game>().setGameOverWin();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Asteroid>() && other.GetComponent<Asteroid>().isHit == false)
        {
            other.GetComponent<Asteroid>().isHit = true;
            health -= 1;
        }
    }

    private void berrechneUndSetzeScoreText()
    {
        FindObjectOfType<Game>().score = (((int)transform.position.y + 50) + ((int)FindObjectOfType<Game>().hittetAsteroids * 10));
        FindObjectOfType<Game>().scoreText.text = "Score: " + FindObjectOfType<Game>().score;
    }
}
