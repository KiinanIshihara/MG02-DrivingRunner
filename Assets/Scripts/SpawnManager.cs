using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public static SpawnManager Instance;
    [SerializeField] private bool canSpawn;
    [SerializeField] private GameObject[] entitiesPrefabs;
    [SerializeField] private Vector3 spawnPosition;
    [SerializeField] private float spawnTimer;
    private float spawnTimerMax = 1.5f;

    private float spawnIncreaseTimerMax = 10f;
    private float spawnIncreaseTimer;
    
    [SerializeField] private float entitiesSpeed = 1;

    private void Awake() {
        Instance = this;
    }

    private void Update() {
        TrySpawn();
        
    }

    private void TrySpawn() {
        if (!canSpawn) {
            return;
        }
        if (spawnTimer > 0 ) {
            spawnTimer -= Time.deltaTime;
        } else {
            spawnTimer = spawnTimerMax;
            SpawnEntity();
        }

        //every determined amount of seconds (spawnIncreaseTimerMax), the spawn interval becomes shorter (the spawn rate basically increases, making difficulty higher)
        if (spawnIncreaseTimer > 0) {
            spawnIncreaseTimer -= Time.deltaTime;
        } else {
            spawnIncreaseTimer = spawnIncreaseTimerMax;
            if (spawnTimerMax >= 0.7f) {
            spawnTimerMax -= 0.1f;
            }
        }
    }

    public void StartScript() {
        canSpawn = true;
        spawnTimer = spawnTimerMax;
    }

    private void SpawnEntity() {
        GameObject entityToSpawn = entitiesPrefabs[UnityEngine.Random.Range(0, entitiesPrefabs.Length)];
        float side = (float)(UnityEngine.Random.value > 0.5f ? 1 : 0);
        
        if (side == 1) {
            //right
            spawnPosition.x = (float)(UnityEngine.Random.value > 0.5f ? 1.7 : 0.4);
        } else {
            spawnPosition.x = (float)(UnityEngine.Random.value > 0.5f ? -2.25 : -0.95);
        }
        

        GameObject spawnedEntity = Instantiate(entityToSpawn, spawnPosition, Quaternion.identity);  
        spawnedEntity.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -entitiesSpeed);
    }
}
