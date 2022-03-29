using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameOverScript : MonoBehaviour
{
    private Button[] buttons;

    void Awake()
    {
        buttons = GetComponentsInChildren<Button>();
        
        HideButtons();
    }

    private void Start()
    {
        buttons[0].onClick.AddListener(RestartGame);
        buttons[1].onClick.AddListener(ExitToMenu);
    }

    public void HideButtons()
    {
        foreach (var b in buttons)
        {
            b.gameObject.SetActive(false);
        }
    }

    public void ShowButtons()
    {
        foreach (var b in buttons)
        {
            b.gameObject.SetActive(true);
        }
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("RoadSceneEasy");
    }
}
