using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    private GameObject TowerSelect;
    public GameObject CurrentGridCell;
    private TowerSelectController TowerSelectController;

    void Start()
    {
        // if(TowerSelect == null) {
        //     TowerSelect = GameObject.Find("towerSelect");
        //     TowerSelect.SetActive(false);
        // }

        // if(TowerSelect == null) {
        //     TowerSelectController towerSelectController = new TowerSelectController();
        //     TowerSelect = towerSelectController.TowerSelect;
        //     TowerSelect.SetActive(false);
        // }
        TowerSelectController = new TowerSelectController();
        TowerSelect = TowerSelectController.TowerSelect;
    }

    public void Clicked()
    {
        Debug.Log(TowerSelect);
        TowerSelect.SetActive(true);
        CreateTowerButton createTowerButton = TowerSelect.GetComponentInChildren<CreateTowerButton>();
        Debug.Log(createTowerButton);
        createTowerButton.CurrentGridCell = CurrentGridCell;
        createTowerButton.TowerSelect = TowerSelect;
    }
}
