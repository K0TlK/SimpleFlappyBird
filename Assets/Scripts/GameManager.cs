using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : Singleton<GameManager>
{
    private readonly static string saveAttempts = "Attempts";

    [SerializeField] private PlayerTarget target;
    [SerializeField] private PlayerMovement playerPrefab;

    private PlayerMovement player;
    private int attempts = 0;

    public int Attempts => attempts;

    private void Awake()
    {
        player = Instantiate(playerPrefab);
    }

    public void StartGame()
    {
        attempts = PlayerPrefs.GetInt(saveAttempts, 0);
        player.transform.position = Vector3.zero;
        target.SetTarget(player.transform);
        LevelBuilder.Instance.StartGame();
        player.IsActive = true;
        GameTimer.Instance.StartTimer();
        SceneManager.Instance.StartGame();
    }

    public void EndGame()
    {
        GameTimer.Instance.StopTimer();
        player.IsActive = false;
        attempts++;
        PlayerPrefs.SetInt(saveAttempts, attempts);
        SceneManager.Instance.EndScreen();
    }
}
