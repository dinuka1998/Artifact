using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact : MonoBehaviour
{

    public int helath;
    public int maxhelth = 150;

    public int bleed = 2;

    private AudioSource artifactAudio;
    private float bleedTimer;

    private PlayerBackPack playerBackPack;

    private string PALYER_TAG = "Player";

    private void Awake() {

        playerBackPack = GameObject.FindWithTag(PALYER_TAG).GetComponent<PlayerBackPack>();
        artifactAudio = GetComponent<AudioSource>();
        helath = maxhelth;

        bleedTimer = Time.time + 1f;
        
    }

    private void Update() {
        
        if (Time.time > bleedTimer) {

            helath -= bleed;
            bleedTimer = Time.time + 1f;

        } 

        CheckHelth();

    }

    public void TakeDamage(int damgeAmount) {

        helath -= damgeAmount;

        CheckHelth();

    }

    void CheckHelth() {

        if(helath <= 0) {

            helath = 0;

            //Show game over UI

            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        
        if(collision.CompareTag(PALYER_TAG)) {

            if(playerBackPack.currentNumberOfFruits != 0)
                artifactAudio.Play();

            helath += playerBackPack.TakeFruits();

            if( helath > maxhelth)
                helath = maxhelth;


            
        }

    }

} // class
