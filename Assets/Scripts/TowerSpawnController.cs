using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
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
  private GameObject closeMenuButton;
  private EconomyController economyController;
  private GameObject NewTower;
  private GridCellObject currentGridCellObject;

  void Start() {
    gridController = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<GridController>();
    Button[] gridCells = gridController.GridCells
      .Select(x => x.GridCell.GetComponent<Button>()).ToArray();
    closeMenuButton = GameObject.Find("closeTowerSelectButton");
    closeMenuButton.GetComponent<Button>().onClick.AddListener(Cancel);
    economyController = GameObject.Find("Economy").GetComponent<EconomyController>();
  }

  public bool SpawnTower(GameObject tower, BaseTower towerModel) {
    currentGridCell = gridController.currentGridCell;
    if (currentGridCell != null) {
      if(!economyController.SpendMoney(towerModel.Cost)){
        return false;
      }
      currentGridCellObject = gridController.GetGridCellObject(currentGridCell);
      NewTower = Instantiate(tower, currentGridCell.transform.position, Quaternion.Euler(0, 0, 0));
      currentGridCellObject.IsOccupied = true;
      currentGridCell = null;
      towerSelect.SetActive(false);
      return true;
    }
    return false;
  }

  public void Cancel() {
    Debug.Log("cancelled");
    currentGridCell = null;
    towerSelect.SetActive(false);
  }

  public void SpawnChickenTower() {
    ChickenTower tower = new ChickenTower();
    bool result = SpawnTower(chickenTowerPrefab, tower);
    if(result) {
      currentGridCellObject.Tower = NewTower.GetComponent<ChickenTowerScript>().tower;
      economyController.EggsYield += tower.ResourceYield;
      economyController.ReloadBaseResourceText();
      economyController.ReloadIncomeText();
    }
  }

  public void SpawnCowTower() {
    CowTower tower = new CowTower();
    bool result = SpawnTower(CowTowerPrefab, tower);
    if(result) {
      currentGridCellObject.Tower = NewTower.GetComponent<CowTowerScript>().tower;
      economyController.MilkYield += tower.ResourceYield;
      economyController.ReloadBaseResourceText();
      economyController.ReloadIncomeText();
    }
  }

  public void SpawnPigTower() {
    PigTower tower = new PigTower();
    bool result = SpawnTower(pigTowerPrefab, tower);
    if(result) {
      currentGridCellObject.Tower = NewTower.GetComponent<PigTowerScript>().tower;
      economyController.PorkYield += tower.ResourceYield;
      economyController.ReloadBaseResourceText();
      economyController.ReloadIncomeText();
    }
  }

  public void SpawnScarecrowTower() {
    ScarecrowTower tower = new ScarecrowTower();
    bool result = SpawnTower(scarecrowTowerPrefab, tower);
    if(result) {
      currentGridCellObject.Tower = NewTower.GetComponent<ScarecrowTowerScript>().tower;
      economyController.WheatYield += tower.ResourceYield;
      economyController.ReloadBaseResourceText();
      economyController.ReloadIncomeText();
    }
  }
}