using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSelectController
{
    public GameObject TowerSelect;
    public GameObject currentGridCell;
    public TowerSelectController() {
        TowerSelect = GameObject.Find("towerSelect");
    }
}
