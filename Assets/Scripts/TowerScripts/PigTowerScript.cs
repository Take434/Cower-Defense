using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigTowerScript : MonoBehaviour
{
  private List<GameObject> enemies;
  private double a;
  private PigTower tower;
  // Start is called before the first frame update
  void Start()
  {
    enemies = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<GridController>().enemies;
    tower = new PigTower();
    a = tower.AttackSpeed;
  }

  // Update is called once per frame
  void Update()
  {
    if (Time.time >= a)
    {
      tower.Attack(enemies, gameObject);
      a += tower.AttackSpeed;
    }
  }
}