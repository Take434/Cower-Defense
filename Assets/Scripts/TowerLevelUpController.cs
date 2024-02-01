using TMPro;
using UnityEngine;

public class TowerLevelUpController: MonoBehaviour {
    public GameObject TowerLevelUpMenu;
    public GameObject OffenseLevelUpPreviewText;
    public GameObject OffenseLevelUpCostText;
    public GameObject ResourceLevelUpPreviewText;
    public GameObject ResourceLevelUpCostText;
    private BaseTower CurrentTower;
    public GameObject Economy;
    private EconomyController EconomyController;

    public void Open(BaseTower tower) {
        EconomyController = Economy.GetComponent<EconomyController>();

        CurrentTower = tower;
        string offenseLevelUpPreviewString = tower.GetOffenseLevelUpPreview();
        OffenseLevelUpPreviewText.GetComponent<TextMeshProUGUI>().text = offenseLevelUpPreviewString;
        string offenseLevelUpCostString = tower.GetOffenseLevelUpCost();
        OffenseLevelUpCostText.GetComponent<TextMeshProUGUI>().text = offenseLevelUpCostString;

        string resourceLevelUpPreviewString = tower.GetResourceLevelUpPreview();
        ResourceLevelUpPreviewText.GetComponent<TextMeshProUGUI>().text = resourceLevelUpPreviewString;
        string resourceLevelUpCostString = tower.GetResourceLevelUpCost();
        ResourceLevelUpCostText.GetComponent<TextMeshProUGUI>().text = resourceLevelUpCostString;
        TowerLevelUpMenu.SetActive(true);
    }

    public void Cancel() {
        TowerLevelUpMenu.SetActive(false);
    }

    public void UpgradeOffense() {
        if(EconomyController.GetMoney() >= CurrentTower.OffenseUpgradeCost) {
            EconomyController.SpendMoney(CurrentTower.OffenseUpgradeCost);
            CurrentTower.UpgradeOffenseLevel();
            string offenseLevelUpPreviewString = CurrentTower.GetOffenseLevelUpPreview();
            OffenseLevelUpPreviewText.GetComponent<TextMeshProUGUI>().text = offenseLevelUpPreviewString;
            string offenseLevelUpCostString = CurrentTower.GetOffenseLevelUpCost();
            OffenseLevelUpCostText.GetComponent<TextMeshProUGUI>().text = offenseLevelUpCostString;
        }
    }

    public void UpgradeResource() {
        if(EconomyController.GetMoney() >= CurrentTower.ResourceUpgradeCost) {
            EconomyController.SpendMoney(CurrentTower.ResourceUpgradeCost);
            CurrentTower.UpgradeResourceLevel();
            string resourceLevelUpPreviewString = CurrentTower.GetResourceLevelUpPreview();
            ResourceLevelUpPreviewText.GetComponent<TextMeshProUGUI>().text = resourceLevelUpPreviewString;
            string resourceLevelUpCostString = CurrentTower.GetResourceLevelUpCost();
            ResourceLevelUpCostText.GetComponent<TextMeshProUGUI>().text = resourceLevelUpCostString;

            if(CurrentTower.Resource == Resources.Eggs) {
                EconomyController.EggsYield += 1;
            } else if(CurrentTower.Resource == Resources.Milk) {
                EconomyController.MilkYield += 1;
            } else if(CurrentTower.Resource == Resources.Pork) {
                EconomyController.PorkYield += 1;
            } else if(CurrentTower.Resource == Resources.Wheat) {
                EconomyController.WheatYield += 1;
            }
        }
    }
}
