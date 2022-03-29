using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLivesScript : MonoBehaviour
{
    public float pHealth = 100f;
    public GameObject[] hearts;
    public GameObject   healthBar;

    #region privates
    private int Lives = 3;
    private float Health = 0;
    private const float cHealthBarWidth = 0.3f;
    private const float cHealthBarLength = 3f;
    private const float cHealthBarYPosition = 4.4f;
    private const float cHealthBarXPosition = 8f;
    #endregion

    private void Start()
    {
        Health = pHealth;

        foreach(GameObject heart in hearts)
        {
            heart.gameObject.SetActive(true);
        }

        Lives = hearts.Length;

        updateHealthBar();
    }

    private void OnCollisionStay2D(Collision2D collision) {
        objectHitScript obj = collision.gameObject.GetComponent<objectHitScript>();

        if (obj != null)
        {
            if(obj.addsHealth)
            {
                addHealth(obj.Points);
            }
            else
            {
                removeHealth(obj.Points);
            }
        }

        //Whenever a living object (Like a grandma) is hit, your lives go down
        if (obj.tag == "Living")
        {
            removeALife();
        }

        //We do not want to remove the curbs as these are also the boundaries for the road
        if (obj.tag != "Curb")
        {
            //Destroy the player
            Destroy(obj.gameObject);
        }
        
        updateHealthBar();

        if (Health <= 0) {
            removeALife();
            Health = pHealth;
        }
    }

    public void removeALife()
    {
        Lives -= 1;
        hearts[Lives].gameObject.SetActive(false);

        if (Lives <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void addHealth(float pHealh)
    {
        Health += pHealh;
        Health = (Health > 100) ? 100 : Health;
    }

    public void removeHealth(float pHealh)
    {
        Health -= pHealh;
        Health = (Health < 0) ? 0 : Health;
    }

    private void updateHealthBar() {
        float transformer = (cHealthBarLength * (Health / 100f));
        healthBar.transform.localScale = new Vector3(transformer, cHealthBarWidth, 0);
        healthBar.transform.position = new Vector3(cHealthBarXPosition - ((cHealthBarLength - transformer) / 2), cHealthBarYPosition, -4);
    }
}
