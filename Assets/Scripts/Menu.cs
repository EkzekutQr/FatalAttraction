using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{

    bool pause;

    bool playerAlive = true;

    GameObject abilityBoard;

    GameObject menuBoard;

    GameObject player;

    private void Start()
    {
        abilityBoard = new GameObject();

        abilityBoard = GameObject.Find("AbilityBoard");

        menuBoard = GameObject.Find("MenuBoard");

        player = GameObject.Find("Player");

        menuBoard.SetActive(false);

        player.GetComponent<PlayerHP>().OnPlayerDeath += PlayerDeathMenu;
    }
    public void PlayerDeathMenu()
    {
        Pause();
        GameMenu();
        playerAlive = false;
    }
    public void Pause()
    {
        if (playerAlive)
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
