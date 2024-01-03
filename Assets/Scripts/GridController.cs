using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GridController : MonoBehaviour {

  public List<GridCellObject> GridCells;
  public GameObject currentGridCell;
  public GameObject towerSelect;

  void Start() {
    Button[] gridCellGameObjects = GameObject.FindGameObjectsWithTag("GridCell").Select(x => x.GetComponent<Button>()).ToArray();

    foreach (Button gridCell in gridCellGameObjects) {
      gridCell.onClick.AddListener(() => {
        currentGridCell = gridCell.gameObject;
        towerSelect.SetActive(true);
      });
    }

    GridCells = gridCellGameObjects.Select(x => new GridCellObject {
      GridCell = x.gameObject,
      IsOccupied = false,
      Tower = null
    }).ToList();

    
  }
}