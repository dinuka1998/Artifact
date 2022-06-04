using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    private Text timerText;

    public float timeToWin = 300f;

    private bool gameOver;

    private GameObject artifact;
    private string ARTIFACT_TAG = "Artifact";

    private StringBuilder stringBuilder;
 
    private void Awake() {
        
        artifact = GameObject.FindWithTag(ARTIFACT_TAG);
        stringBuilder = new StringBuilder();

    }

    private void Update() {
        
        if(gameOver || !artifact)
            return;

        timeToWin -= Time.deltaTime;

        if(timeToWin <= 0f) {

            timeToWin = 0f;
            gameOver = true;

            Destroy(artifact);

            GameOverUIController.instance.GameOver("You Win !");

        }

        DisplayTime((int)timeToWin);

        // timerText.text = "Time Remaining : " + (int)timeToWin;

    }

    void DisplayTime(int time){

        stringBuilder.Length = 0;

        stringBuilder.Append("Time Remaining : ");
        stringBuilder.Append(time);
        timerText.text = stringBuilder.ToString();

    }


    
}
