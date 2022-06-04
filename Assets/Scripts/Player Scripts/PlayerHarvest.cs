using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHarvest : MonoBehaviour
{
   
    [SerializeField]
    private float harvestTime = 0.4f;

    private PlayerMovement playerMovement;
    private PlayerBackPack playerBackPack;

    private AudioSource audioSource;

    private Collider2D collidedBush;
    private BushFruits hitBush;

    private bool canHarvestFruits;

    private string BUSH_TAG = "Bush";

    private void Awake() {

        playerMovement = GetComponent<PlayerMovement>();
        playerBackPack = GetComponent<PlayerBackPack>();
        audioSource = GetComponent<AudioSource>();
        
    }

    private void Update() {
        
        if(Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.E) ) {

            TryHarvestFruit();

        }

    }

    void TryHarvestFruit() {

        if(!canHarvestFruits)
            return;

        if(collidedBush != null) {

            hitBush = collidedBush.GetComponent<BushFruits>();

            if(hitBush.HasFruits()) {

                audioSource.Play();
                playerMovement.HarvestStopMovement(harvestTime);
                playerBackPack.AddFruits(hitBush.HarvestFruit());

            }

        }

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        
        if(collision.CompareTag(BUSH_TAG)) {

            canHarvestFruits = true;
            collidedBush = collision;

        }

    }

    private void OnTriggerExit2D(Collider2D collision) {
        
        if(collision.CompareTag(BUSH_TAG)) {

            canHarvestFruits = false;
            collidedBush = null;

        }

    }

}  //class
