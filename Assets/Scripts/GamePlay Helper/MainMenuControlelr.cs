using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControlelr : MonoBehaviour
{

    [SerializeField]
    private Canvas howToPlayCanvas;

    private string GAMEPLAY_SCEAN_NAME = "GamePlay";

    public void PlayGame() {

        SceneManager.LoadScene(GAMEPLAY_SCEAN_NAME);

    }

    public void HowToPlay() {

        howToPlayCanvas.enabled = true;

    }

    public void BackToMainMenu() {

        howToPlayCanvas.enabled = false;

    }

    public void BackToDesktop() {

        Application.Quit();

    }
}
