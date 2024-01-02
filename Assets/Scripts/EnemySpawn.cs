using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private List<GameObject> possibleEnemies;
    float a = 0.5f;
    void Start()
    {
        possibleEnemies = GameObject.FindGameObjectsWithTag("enemy").ToList();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Time.time);
        if(Time.time >= a) {
            GameObject enemyPrefab = possibleEnemies[UnityEngine.Random.Range(0, possibleEnemies.Count)];
            GameObject instance = Instantiate(enemyPrefab, transform.position, Quaternion.Euler(90, 0, 0));
            instance.GetComponent<EnemyMovement>().moveSpeed = UnityEngine.Random.Range(1, 5);
            a += UnityEngine.Random.Range(2f, 5f);
        }
    }
}
