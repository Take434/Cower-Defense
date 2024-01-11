using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GridController : MonoBehaviour {

  public List<GridCellObject> GridCells;
  public GameObject currentGridCell;
  public GameObject towerSelect;
  public List<GameObject> enemies;

  void Start() {
    Button[] gridCellGameObjects = GameObject.FindGameObjectsWithTag("GridCell").Select(x => x.GetComponent<Button>()).ToArray();

    foreach (Button gridCell in gridCellGameObjects) {
      gridCell.onClick.AddListener(() => {
        currentGridCell = gridCell.gameObject;
        GridCellObject currentGridCellObject = GetGridCellObject(currentGridCell);
        if(currentGridCellObject.IsOccupied) {
          return;
        }
        towerSelect.SetActive(true);
      });
    }

    GridCells = gridCellGameObjects.Select(x => new GridCellObject {
      GridCell = x.gameObject,
      IsOccupied = false,
      Tower = null
    }).ToList();

    
  }

  public GridCellObject GetGridCellObject(GameObject gridCell) {
    return GridCells.Where(x => x.GridCell == gridCell).FirstOrDefault();
  }
}