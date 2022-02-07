using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{

    bool pause;

    GameObject abilityBoard;

    GameObject menuBoard;

    private void Start()
    {
        abilityBoard = new GameObject();

        abilityBoard = GameObject.Find("AbilityBoard");

        menuBoard = GameObject.Find("MenuBoard");

        menuBoard.SetActive(false);
    }
    public void Pause()
    {
        pause = !pause;
        if (pause)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
    public void GameMenu()
    {
        if (pause)
        {
            abilityBoard.SetActive(false);

            menuBoard.SetActive(true);
        }
        else
        {
            abilityBoard.SetActive(true);

            menuBoard.SetActive(false);
        }
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
