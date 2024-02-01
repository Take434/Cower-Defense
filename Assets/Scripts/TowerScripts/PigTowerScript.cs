using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigTowerScript : MonoBehaviour
{
  private List<GameObject> enemies;
  private double a;
  public BaseTower tower;

  PigTowerScript()
  {
    tower = new PigTower();
  }
  // Start is called before the first frame update
  void Start()
  {
    enemies = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<GridController>().enemies;
    a = tower.AttackSpeed;
    tower.attackPrefab = (GameObject)UnityEngine.Resources.Load("Prefabs/Fireball");
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
