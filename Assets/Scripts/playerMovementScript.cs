using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovementScript : MonoBehaviour
{
    public Vector2 movementSpeed = new Vector2(1, 1);

    // Update is called once per frame
    void Update()
    {
        float Xin = Input.GetAxis("Horizontal");
        float Yin = -Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(movementSpeed.y * Yin, movementSpeed.x * Xin, 0);

        transform.Translate(movement * Time.deltaTime);
    }

    void OnDestroy()
    {
        //Application.LoadLevel("RoadSceneEasy");
        // Game Over.
        var gameOver = FindObjectOfType<gameOverScript>();
        if (gameOver != null)
        {
            gameOver.ShowButtons();
        }
    }
}
