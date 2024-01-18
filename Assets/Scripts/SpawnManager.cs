using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject BombPrefab;

    private float spawnDelay = 2;
    private float spawnInterval = 1.5f;

    private PlayerController playerControllerScript;
    void Start()
    {
        InvokeRepeating("SpawnObjects",spawnDelay,spawnInterval);
        playerControllerScript = GameObject.Find("Player").GetComponent< PlayerController>();
    }

    

    void SpawnObjects(){
        Vector3 spawnLocation = new Vector3(Random.Range(0,11),10,Random.Range(-1,11));
        if(playerControllerScript.gameOver == false)
        {
            Instantiate(BombPrefab,spawnLocation,BombPrefab.transform.rotation);

        }
    }
}
