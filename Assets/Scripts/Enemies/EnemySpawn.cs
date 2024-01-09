using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private List<GameObject> possibleEnemies;
    private GameState gameState;
    float a = 0.5f;
    void Start()
    {
        possibleEnemies = UnityEngine.Resources.LoadAll("prefabs/enemies").Cast<GameObject>().ToList();
        gameState = GameObject.Find("GameState").GetComponent<GameState>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= a) {
            a += UnityEngine.Random.Range(5f, 7f);

            if(GameStateEnum.PLAYING != gameState.state) {
                return;
            }

            GameObject enemyPrefab = possibleEnemies[UnityEngine.Random.Range(0, possibleEnemies.Count)];
            GameObject instance = Instantiate(enemyPrefab, transform.position, Quaternion.Euler(90, 0, 0));
        }
    }
}
