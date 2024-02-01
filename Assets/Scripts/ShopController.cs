using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OpenShop : MonoBehaviour
{
    public GameObject shopMenu;
    
    public GameObject closeMenuButton;
    public EconomyController economyController;
    void Start()
    {
        economyController = GameObject.Find("Economy").GetComponent<EconomyController>();
        closeMenuButton.GetComponent<Button>().onClick.AddListener(Cancel);
        if (shopMenu != null)
        {
            shopMenu.SetActive(false);
            GameObject.Find("closeMenuButton");
        }
    }

    public void Cancel() {
    shopMenu.SetActive(false);
  }

    public void open()
    {
        if (shopMenu != null)
        {
            economyController.ReloadBaseResourceText();
            economyController.ReloadIncomeText();
            shopMenu.SetActive(true);
        }
    }

}
