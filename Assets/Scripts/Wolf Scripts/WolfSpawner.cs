using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfSpawner : MonoBehaviour
{
    
    [SerializeField]
    private GameObject wolfPrefab, wolfEaterPrefab;

    [SerializeField]
    private Transform[] spawnerPoints;

    [SerializeField]
    private int eaterChance = 3; //chance out of 10 top spawn a eater wolf
    
    [SerializeField]
    private float spawnTime = 12f; // initail spawn delay per wolf

    [SerializeField]
    private float spawnReductionPerWolf = 1f; // reduction in spawn delay per each wolf

    [SerializeField]
    private float minimumSpawnDelay = 3.5f;

    private float currentSpawnTime;
    private float timer;


    private void Start() {
        
        currentSpawnTime = spawnTime;
        timer = Time.time;

    }

    private void Update() {
        
        if(Time.time > timer) {

            Spawn();

            currentSpawnTime -= spawnReductionPerWolf;

            if(currentSpawnTime <= minimumSpawnDelay)
                currentSpawnTime = minimumSpawnDelay;

            timer = Time.time + currentSpawnTime;

        }

    }

    void Spawn() {

        if(Random.Range(0, 11) > eaterChance) {

            Instantiate(wolfPrefab, spawnerPoints[Random.Range(0, spawnerPoints.Length)].position, Quaternion.identity);

        }
        else {

            Instantiate(wolfEaterPrefab, spawnerPoints[Random.Range(0, spawnerPoints.Length)].position, Quaternion.identity);

        }

    }

} //calss
