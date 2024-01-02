using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    public GameObject panel;

    public void Clicked()
    {
        panel.SetActive(true);
        Debug.Log("Button Clicked");
    }
}
