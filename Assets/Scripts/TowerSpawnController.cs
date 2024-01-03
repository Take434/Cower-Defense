using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TowerSpawnController : MonoBehaviour {
  private GameObject currentGridCell;
  public GameObject towerSelect;
  public GameObject chickenTowerPrefab;
  public GameObject CowTowerPrefab;
  public GameObject pigTowerPrefab;
  public GameObject scarecrowTowerPrefab;

  void Start() {
    Button[] gridCells = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<GridController>().GridCells
      .Select(x => x.GridCell.GetComponent<Button>()).ToArray();
  }

  public void SpawnTower(GameObject tower) {
    currentGridCell = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<GridController>().currentGridCell;
    if (currentGridCell != null) {
      GameObject newTower = Instantiate(tower, currentGridCell.transform.position, Quaternion.Euler(90, 0, 0));
      currentGridCell = null;
      towerSelect.SetActive(false);
    }
  }

  public void Cancel() {
    currentGridCell = null;
    towerSelect.SetActive(false);
  }

  public void SpawnChickenTower() {
    SpawnTower(chickenTowerPrefab);
  }

  public void SpawnCowTower() {
    Cancel(); 
    // SpawnTower(CowTowerPrefab);
  }

  public void SpawnPigTower() {
    SpawnTower(pigTowerPrefab);
  }

  public void SpawnScarecrowTower() {
    SpawnTower(scarecrowTowerPrefab);
  }
}