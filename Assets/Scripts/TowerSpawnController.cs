using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TowerSpawnController : MonoBehaviour {
  private GameObject currentGridCell;
  private GridController gridController;
  public GameObject towerSelect;
  public GameObject chickenTowerPrefab;
  public GameObject CowTowerPrefab;
  public GameObject pigTowerPrefab;
  public GameObject scarecrowTowerPrefab;

  void Start() {
    gridController = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<GridController>();
    Button[] gridCells = gridController.GridCells
      .Select(x => x.GridCell.GetComponent<Button>()).ToArray();
  }

  public void SpawnTower(GameObject tower, BaseTower towerModel) {
    currentGridCell = gridController.currentGridCell;
    if (currentGridCell != null) {
      GridCellObject currentGridCellObject = gridController.GetGridCellObject(currentGridCell);
      GameObject newTower = Instantiate(tower, currentGridCell.transform.position, Quaternion.Euler(90, 0, 0));
      currentGridCellObject.IsOccupied = true;
      currentGridCellObject.Tower = towerModel;
      currentGridCell = null;
      towerSelect.SetActive(false);
    }
  }

  public void Cancel() {
    Debug.Log("cancelled");
    currentGridCell = null;
    towerSelect.SetActive(false);
  }

  public void SpawnChickenTower() {
    ChickenTower tower = new ChickenTower();
    SpawnTower(chickenTowerPrefab, tower);
  }

  public void SpawnCowTower() {
    Cancel(); 
    // SpawnTower(CowTowerPrefab);
  }

  public void SpawnPigTower() {
    PigTower tower = new PigTower();
    SpawnTower(pigTowerPrefab, tower);
  }

  public void SpawnScarecrowTower() {
    ScarecrowTower tower = new ScarecrowTower();
    SpawnTower(scarecrowTowerPrefab, tower);
  }
}