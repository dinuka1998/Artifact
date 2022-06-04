using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtatck : MonoBehaviour
{
    

    [SerializeField]
    private GameObject slashPrefab;

    [SerializeField]
    private float attackCoolDown = 0.3f;

    private float attackTimer;

    private AudioSource audioSource;

    private Camera mainCamera;
    
    private Vector3 spawnPosition;

    private GameObject artifact;
    private string ARTIFACT_TAG = "Artifact";

    private void Awake() {

        audioSource = GetComponent<AudioSource>();
        mainCamera = Camera.main;

        artifact = GameObject.FindWithTag(ARTIFACT_TAG);

    }

    private void Update() {
        
        if(Input.GetKeyDown(KeyCode.Mouse0) && Time.time > attackTimer) {

            Slash();
            
            attackTimer = Time.time + attackCoolDown;

        }

    }

    void Slash() {

        if(!artifact)
            return; 

        audioSource.Play();

        spawnPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        spawnPosition.z = 0f;

        Instantiate(slashPrefab, spawnPosition, Quaternion.identity);

    }

} // calss
