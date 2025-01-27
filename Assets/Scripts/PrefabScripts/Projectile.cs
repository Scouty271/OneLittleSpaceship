using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;

    public float lifetime;
    public float lifetimeCurr;

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);

        lifetimeCurr += Time.deltaTime;

        if (lifetimeCurr >= lifetime)
        {
            FindObjectOfType<Game>().shootetProjectilesForQuote++;

            FindObjectOfType<Player>().projectiles.Remove(this);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Asteroid>() && other.GetComponent<Asteroid>().isHit == false)
        {
            FindObjectOfType<Game>().shootetProjectilesForQuote++;
            FindObjectOfType<Game>().hittetAsteroids++;
            other.GetComponent<Asteroid>().isHit = true;

            if(other.GetComponent<Gold>())
            {
                FindObjectOfType<Game>().collectedGold++;
            }

            FindObjectOfType<Player>().projectiles.Remove(this);
            Destroy(gameObject);
        }
    }
}
