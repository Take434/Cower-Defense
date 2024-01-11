using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenTowerScript : MonoBehaviour
{
    private List<GameObject> enemies;
    private double a;
    private ChickenTower tower;
    // Start is called before the first frame update
    void Start()
    {
        enemies = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<GridController>().enemies;
        tower = new ChickenTower();
        a = tower.AttackSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= a)
        {
            if(tower.Attack(enemies, gameObject)) {
                a += tower.AttackSpeed;
            }
            a += 0.05;
        }
    }
}