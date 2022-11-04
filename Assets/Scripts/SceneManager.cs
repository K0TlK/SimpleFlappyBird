using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : Singleton<SceneManager>
{
    [SerializeField] private GameObject btStartGame;
    [SerializeField] private GameObject EndGame;

    public void StartGame()
    {
        btStartGame.SetActive(false);
        EndGame.SetActive(false);
    }

    public void EndScreen()
    {
        btStartGame.SetActive(false);
        EndGame.SetActive(true);
    }

    public void StartMenu()
    {
        btStartGame.SetActive(true);
        EndGame.SetActive(false);
    }
}
