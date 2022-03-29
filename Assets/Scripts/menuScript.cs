using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour
{
    public Button bDifficulty, bStart, bOptions;
    private int Difficulty = 0;

    private void Start()
    {
        bDifficulty.onClick.AddListener(chooseDificulty);
        bStart.onClick.AddListener(startGame);
        bOptions.onClick.AddListener(options);
    }

    public void chooseDificulty()
    {
        Difficulty += 1;

        if (Difficulty > 2) {
            Difficulty = 0;
        }
    }

    public void startGame()
    {
        switch (Difficulty)
        {
            case 0:
                SceneManager.LoadScene("RoadSceneEasy");
            break;
            case 1:
                SceneManager.LoadScene("RoadSceneMedium");
            break;
            case 2:
                SceneManager.LoadScene("RoadSceneHard");
            break;
            default:
                //Nope
            break;
        }
    }

    public void options()
    {
        Debug.Log("Options hihi");
    }
}
