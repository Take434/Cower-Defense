using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EconomyController : MonoBehaviour
{
    private int totalPorkYield;
    private int totalMilkYield;
    private int totalEggsYield;
    private int totalWheatYield;
    private int currentPorkYield;
    private int currentMilkYield;
    private int currentEggsYield;
    private int currentWheatYield;
    private int money;
    // Start is called before the first frame update
    void Start()
    {
        money = 25;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetMoney() {
        return money;
    }

    public void EndOfWave() {
        money += currentPorkYield;
        money += currentMilkYield;
        money += currentEggsYield;
        money += currentWheatYield;
    }

    public void CraftCake() {
        if (currentMilkYield >= 5 && currentEggsYield >= 1 && currentWheatYield >= 1) {
            currentPorkYield -= 1;
            currentMilkYield -= 1;
            currentEggsYield -= 1;
            currentWheatYield -= 1;
            money += 10;
        }
    }
}
