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
    Debug.Log("cancelled");
    shopMenu.SetActive(false);
  }

    public void open()
    {
        Debug.Log("clicked");
        if (shopMenu != null)
        {
            economyController.ReloadBaseResourceText();
            economyController.ReloadIncomeText();
            shopMenu.SetActive(true);
        }
    }

    public void close()
    {
        shopMenu.SetActive(false);
    }
}
