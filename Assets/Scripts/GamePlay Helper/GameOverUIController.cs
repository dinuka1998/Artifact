using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUIController : MonoBehaviour
{

    public static GameOverUIController instance;

    [SerializeField]
    private Canvas gameOverCanvas;

    [SerializeField]
    private Text gameOverText;

    [SerializeField]
    private GameObject enemySpawner;

    private string MAIN_MENU_SCEAN_NAME = "MainMenu";

    private void Awake() {
        
        if(instance == null)
            instance = this;

    }

    public void GameOver(string gameOverInfo) {

        gameOverText.text = gameOverInfo;
        gameOverCanvas.enabled = true;

        Destroy(enemySpawner);

    }

    public void RestartGame() {

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void MainMenu() {

        SceneManager.LoadScene(MAIN_MENU_SCEAN_NAME);

    }
    
}// calss
