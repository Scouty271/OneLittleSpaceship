using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchController : MonoBehaviour
{
    public Vector2 touchpos;

    public float rotationProjectile;

    public Projectile rocket1;
    public Projectile rocket2;
    public Projectile rocket3;
    public Projectile rocket4;

    private void Update()
    {
        if (!IsPointerOverUIObject())
        {
            // Überprüfen, ob es eine Touch-Eingabe gibt
            if (Input.touchCount > 0)
            {
                if(FindObjectOfType<Player>() != null && FindObjectOfType<GameController>().ammunition > 0 && !FindObjectOfType<Game>().gameOverLoose && !FindObjectOfType<Game>().gameOverWin)
                {
                    // Überprüfen, ob die erste Touch-Eingabe den Zustand "began" hat (also den Bildschirm berührt)
                    if (Input.GetTouch(0).phase == TouchPhase.Began)
                    {
                        touchpos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

                        projectileDirection();

                        if (FindObjectOfType<GameController>().rocket1Selected)                        
                            instantiateRocket(rocket1);
                        
                        if (FindObjectOfType<GameController>().rocket2Selected)                        
                            instantiateRocket(rocket2);
                        
                        if (FindObjectOfType<GameController>().rocket3Selected)                        
                            instantiateRocket(rocket3);
                        
                        if (FindObjectOfType<GameController>().rocket4Selected)                        
                            instantiateRocket(rocket4);                        

                        FindObjectOfType<GameController>().ammunition -= 1;
                    }
                }
            }
        }
    }

    private void projectileDirection()
    {
        if ((touchpos.x - transform.position.x) > 0)
        {
            rotationProjectile = Mathf.Atan((touchpos.y - FindObjectOfType<Player>().transform.position.y) / (touchpos.x - FindObjectOfType<Player>().transform.position.x)) * Mathf.Rad2Deg;
        }
        else if ((touchpos.x - transform.position.x) < 0)
        {
            rotationProjectile = Mathf.Atan((touchpos.y - FindObjectOfType<Player>().transform.position.y) / (touchpos.x - FindObjectOfType<Player>().transform.position.x)) * Mathf.Rad2Deg + 180f;
        }
    }

    private void instantiateRocket(Projectile projectile)
    {
        FindObjectOfType<Player>().projectiles.Add(Instantiate(projectile, new Vector3(FindObjectOfType<Player>().transform.position.x, FindObjectOfType<Player>().transform.position.y, -0.1f), Quaternion.Euler(0, 0, rotationProjectile), FindObjectOfType<Player>().transform));
    }

    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 1;
    }
}
