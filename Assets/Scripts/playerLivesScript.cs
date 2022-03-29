using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLivesScript : MonoBehaviour
{
    public float Health = 100f;
    public GameObject[] hearts;

    private int Lives = 3;

    private void Start()
    {
        foreach(GameObject heart in hearts)
        {
            heart.gameObject.SetActive(true);
        }

        Lives = hearts.Length;
        //Debug.Log("Hello: " + Lives);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
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

        //Whenever a living object (Like a woman) is hit, your lives go down
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

    public void addHealth(int pHealh)
    {
        Health += pHealh;
        Debug.Log(Health);
    }

    public void removeHealth(int pHealh)
    {
        Health -= pHealh;
        Debug.Log(Health);

        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
