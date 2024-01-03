using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTowerButton : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject TowerSelect;
    public GameObject ChickenTowerPrefab;
    public GameObject CurrentGridCell;

    void Start()
    {
        // CurrentGridCell = new GameObject();
        // TowerSelect = new GameObject();
    }
    public void CreateChickenTower() {
        // ChickenTower chickenTower = new ChickenTower();
        // Debug.Log("created chicken tower");
        // CurrentGridCell =


        //Debug.Log(CurrentGridCell.transform.position);
        Instantiate(ChickenTowerPrefab, CurrentGridCell.transform.position, Quaternion.Euler(90, 0, 0));
        //newGameObject.transform.position = currentGridCell.transform.position;
        TowerSelect.SetActive(false);

    }

    public void CreateCowTower() {
        TowerSelect = GameObject.Find("towerSelect");
        TowerSelect.SetActive(false);
        // CowTower cowTower = new CowTower();
        // Debug.Log("created cow tower");
    }

    public void CreatePigTower() {
        TowerSelect.SetActive(false);
        PigTower pigTower = new PigTower();
        Debug.Log("created pig tower");
    }

    public void CreateScarecrowTower() {
        TowerSelect.SetActive(false);
        ScarecrowTower scarecrowTower = new ScarecrowTower();
        Debug.Log("created scarecrow tower");
    }
}
