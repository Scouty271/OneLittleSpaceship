using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public Asteroid asteroid;
    public Asteroid goldAsteroid;

    public Sprite asteroidSprite1;
    public Sprite asteroidSprite2;
    public Sprite asteroidSprite3;

    private void Start()
    {
        for (int i = 0; i < 1000; i++)
        {
            var randomX = Random.Range(-10, 10);
            var randomY = Random.Range(-2, 2);

            asteroid.rotationSpeed = Random.Range(0, 50);

            var asteroidValue = Random.Range(0, 3);
            var goldAsteroidValue = Random.Range(0, 3);

            if (asteroidValue == 0)
                asteroid.GetComponent<SpriteRenderer>().sprite = asteroidSprite1;
            if (asteroidValue == 1)
                asteroid.GetComponent<SpriteRenderer>().sprite = asteroidSprite2;
            if (asteroidValue == 2)
                asteroid.GetComponent<SpriteRenderer>().sprite = asteroidSprite3;

            if (goldAsteroidValue == 0)
                goldAsteroid.GetComponent<SpriteRenderer>().sprite = asteroidSprite1;
            if (goldAsteroidValue == 1)
                goldAsteroid.GetComponent<SpriteRenderer>().sprite = asteroidSprite2;
            if (goldAsteroidValue == 2)
                goldAsteroid.GetComponent<SpriteRenderer>().sprite = asteroidSprite3;

            var randomValue = Random.Range(0, 2);

            if (randomValue == 1)
            {
                Instantiate(goldAsteroid, new Vector3(randomX, randomY + i * 10, -0.1f), Quaternion.identity, transform);
            }
            else
            {
                Instantiate(asteroid, new Vector3(randomX, randomY + i * 10, -0.1f), Quaternion.identity, transform);
            }


        }
    }
}
