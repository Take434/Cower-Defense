using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OpenShop : MonoBehaviour
{
    public GameObject shopMenu;
    
    public GameObject closeMenuButton;
    void Start()
    {
        GameObject.Find("shopMenu");
        if (shopMenu != null)
        {
            shopMenu.SetActive(false);
            GameObject.Find("closeMenuButton");
        }
    }

    public void open()
    {
        Debug.Log("clicked");
        if (shopMenu != null)
        {
           shopMenu.SetActive(true);
        }
    }

    public void close()
    {
        shopMenu.SetActive(false);
    }
}
