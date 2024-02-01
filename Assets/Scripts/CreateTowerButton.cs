using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTowerButton : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject TowerSelect;
    public GameObject ChickenTowerPrefab;
    public GameObject CurrentGridCell;
    public void CreateChickenTower() {
        Instantiate(ChickenTowerPrefab, CurrentGridCell.transform.position, Quaternion.Euler(90, 0, 0));
        TowerSelect.SetActive(false);

    }

    public void CreateCowTower() {
        TowerSelect = GameObject.Find("towerSelect");
        TowerSelect.SetActive(false);
    }

    public void CreatePigTower() {
        TowerSelect.SetActive(false);
        PigTower pigTower = new PigTower();
    }

    public void CreateScarecrowTower() {
        TowerSelect.SetActive(false);
        ScarecrowTower scarecrowTower = new ScarecrowTower();
    }
}
