using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float rotationSpeed;

    public bool isHit;

    public float explosionTime;
    public float explosionTimeCurr;

    public Animator animator;

    private void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);

        if (isHit )
        {
            animator.gameObject.SetActive(true);

            explosionTimeCurr += Time.deltaTime;

            if ( explosionTimeCurr > explosionTime )
            {
                    Destroy(gameObject);
            }
        }
    }
}
