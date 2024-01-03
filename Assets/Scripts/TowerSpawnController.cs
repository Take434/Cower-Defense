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
    Button[] gridCells = GameObject.FindGameObjectsWithTag("GridCell").Select(x => x.GetComponent<Button>()).ToArray();

    Debug.Log(gridCells.Length);

    foreach (Button gridCell in gridCells) {
      gridCell.onClick.AddListener(() => {
        currentGridCell = gridCell.gameObject;
        towerSelect.SetActive(true);
      });
    }
  }

  public void SpawnTower(GameObject tower) {
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