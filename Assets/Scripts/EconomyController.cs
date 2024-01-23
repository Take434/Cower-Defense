using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EconomyController : MonoBehaviour
{
    public int totalPorkYield;
    public int totalMilkYield;
    public int totalEggsYield;
    public int totalWheatYield;
    private int currentPorkYield;
    private int currentMilkYield;
    private int currentEggsYield;
    private int currentWheatYield;
    private int money;
    public GameObject moneyText;
    // Start is called before the first frame update
    void Start()
    {
        money = 25;
        moneyText.GetComponent<TextMeshProUGUI>().text = money.ToString() + " $";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetMoney() {
        return money;
    }

    public bool SpendMoney(int amount) {
        if(money >= amount) {
            money -= amount;
            moneyText.GetComponent<TextMeshProUGUI>().text = money.ToString() + " $";
            return true;
        }
        return false;
    }

    public void EndOfWave() {
        money += currentPorkYield;
        money += currentMilkYield;
        money += currentEggsYield;
        money += currentWheatYield;
    }
}
