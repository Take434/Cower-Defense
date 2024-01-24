using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    private Dictionary<Recipe, int> craftedRecipes = new Dictionary<Recipe, int>();
    private List<Recipe> recipes = new List<Recipe>();
    // Start is called before the first frame update
    void Start()
    {
        Setup();
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

    public void CraftRecipe() {

    }

    public void Setup() {
        Recipe Cake = new Recipe("Cake", new Dictionary<Resources, int> {
            {Resources.Wheat, 2},
            {Resources.Eggs, 2},
            {Resources.Milk, 1}
        }, 20);
        recipes.Add(Cake);

        Recipe Bread = new Recipe("Bread", new Dictionary<Resources, int> {
            {Resources.Wheat, 3}
        }, 10);
        recipes.Add(Bread);

        Recipe Cheese = new Recipe("Cheese", new Dictionary<Resources, int> {
            {Resources.Milk, 2}
        }, 5);
        recipes.Add(Cheese);

        Recipe Omelette = new Recipe("Omelette", new Dictionary<Resources, int> {
            {Resources.Eggs, 2}
        }, 5);

        foreach(Recipe recipe in recipes) {
            craftedRecipes.Add(recipe, 4);
        }
        Debug.Log(craftedRecipes.First(x => x.Key.name == "Cake").Value);
        Craft(Cake);
        Debug.Log(craftedRecipes.First(x => x.Key.name == "Cake").Value);
    }

    public void Craft(Recipe recipe) {
        int newPorkYield = currentPorkYield;
        int newMilkYield = currentMilkYield;
        int newEggsYield = currentEggsYield;
        int newWheatYield = currentWheatYield;

        foreach(KeyValuePair<Resources, int> ingredient in recipe.ingredients) {
            if(ingredient.Key.ToString() == "Eggs") {
                if(currentEggsYield < ingredient.Value) {
                    Debug.Log("Not enough eggs");
                    return;
                }
                newEggsYield -= ingredient.Value;
            }
            if(ingredient.Key.ToString() == "Milk") {
                if(currentMilkYield < ingredient.Value) {
                    Debug.Log("Not enough milk");
                    return;
                }
                newMilkYield -= ingredient.Value;
            }
            if(ingredient.Key.ToString() == "Wheat") {
                if(currentWheatYield < ingredient.Value) {
                    Debug.Log("Not enough wheat");
                    return;
                }
                newWheatYield -= ingredient.Value;
            }
            if(ingredient.Key.ToString() == "Pork") {
                if(currentPorkYield < ingredient.Value) {
                    Debug.Log("Not enough pork");
                    return;
                }
                newPorkYield -= ingredient.Value;
            }
        }
        currentPorkYield = newPorkYield;
        currentMilkYield = newMilkYield;
        currentEggsYield = newEggsYield;
        currentWheatYield = newWheatYield;
        KeyValuePair<Recipe, int> currentRecipe = craftedRecipes.First(x => x.Key.name == "Cake");
        craftedRecipes.Remove(recipe);
        craftedRecipes.Add(currentRecipe.Key, currentRecipe.Value + 1);
        money += recipe.income;
    }
}
