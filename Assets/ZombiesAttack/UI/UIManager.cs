using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject gameOver;

    [SerializeField] private EnemySpawner enemySpawner;

    private void Start()
    {
        MainMenuButton();
    }

    private void Pause(bool pause)
    {
        Time.timeScale = pause ? 0 : 1;
    }

    public void StartGameButton()
    {
        Pause(false);
        mainMenu.SetActive(false);
    }

    public void MainMenuButton()
    {
        Pause(true);
        mainMenu.SetActive(true);
        gameOver.SetActive(false);

        ObjectPooler.instance.DisableObjects();
        Score.instance.ResetScore();
        enemySpawner.ResetSpawnTime();
    }

    public void GameOver()
    {
        Pause(true);
        gameOver.SetActive(true);
        gameOver.GetComponent<Animator>().Play("GameOverPopUp");
    }
}
