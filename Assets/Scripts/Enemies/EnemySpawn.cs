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
        possibleEnemies = UnityEngine.Resources.LoadAll("prefabs/enemies").Cast<GameObject>().ToList();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= a) {
            GameObject enemyPrefab = possibleEnemies[UnityEngine.Random.Range(0, possibleEnemies.Count)];
            GameObject instance = Instantiate(enemyPrefab, transform.position, Quaternion.Euler(90, 0, 0));
            // create health bar from cube
            



            GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<GridController>().enemies.Add(instance);
            //a += UnityEngine.Random.Range(10f, 15f);
            a += 1f;
        }
    }
}
