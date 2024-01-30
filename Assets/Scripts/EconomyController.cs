using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class EconomyController : MonoBehaviour
{
    public int PorkYield;
    public int MilkYield;
    public int EggsYield;
    public int WheatYield;
    private int money;
    public GameObject moneyText;
    private Dictionary<Recipe, int> craftedRecipes = new Dictionary<Recipe, int>();
    private List<Recipe> recipes = new List<Recipe>();
    public GameObject baseResourcesText;
    public GameObject recipesText;
    public GameObject incomeText;
    private string recipesString;
    private string incomeString;
    // Start is called before the first frame update
    void Start()
    {
        Setup();
        money = 250;
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
        money += PorkYield;
        money += MilkYield;
        money += EggsYield;
        money += WheatYield;
        foreach(KeyValuePair<Recipe, int> recipe in craftedRecipes) {
            money += recipe.Key.income * recipe.Value;
        }
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
        recipes.Add(Omelette);

        foreach(Recipe recipe in recipes) {
            craftedRecipes.Add(recipe, 0);
        }
        foreach(Recipe recipe in recipes) {
            recipesString += "   " + recipe.name + " \n";
            foreach (KeyValuePair<Resources, int> ingredient in recipe.ingredients)
            {
                recipesString += "<size=15>" + ingredient.Key.ToString() + ": " + ingredient.Value + "</size> ";
            }
            recipesString += "\n";
        }


        // Debug.Log(craftedRecipes.First(x => x.Key.name == "Cake").Value);
        // Craft(Cake);
        // Debug.Log(craftedRecipes.First(x => x.Key.name == "Cake").Value);
    }

    public void ReloadMoneyText() {
        moneyText.GetComponent<TextMeshProUGUI>().text = money.ToString() + " $";
    }
    
    public void ReloadBaseResourceText() {
        baseResourcesText.GetComponent<TextMeshProUGUI>().text =
            "Pork: " + PorkYield + "\n \n" +
            "Milk: " + MilkYield + "\n \n" +
            "Eggs: " + EggsYield + "\n \n" +
            "Wheat: " + WheatYield + "\n \n";

        recipesText.GetComponent<TextMeshProUGUI>().text = recipesString;
    }

    private void SummonTheMajesticIncomeTextOOOOOHHHH() {
        int totalIncome = 0;
        incomeString = "";
        incomeString += "Pork: " + PorkYield + " * 1 = " + PorkYield * 1 + "\n";
        incomeString += "Milk: " + MilkYield + " * 1 = " + MilkYield * 1 + "\n";
        incomeString += "Eggs: " + EggsYield + " * 1 = " + EggsYield * 1 + "\n";
        incomeString += "Wheat: " + WheatYield + " * 1 = " + WheatYield * 1 + "\n";
        foreach(KeyValuePair<Recipe, int> recipe in craftedRecipes) {
            incomeString += recipe.Key.name + ": " + recipe.Value + " * " + recipe.Key.income + " = " + recipe.Value * recipe.Key.income + "\n";
        }
        totalIncome = PorkYield + MilkYield + EggsYield + WheatYield + craftedRecipes.Sum(x => x.Key.income * x.Value);
        incomeString += "\n Total income: " + totalIncome;
    }

    public void ReloadIncomeText() {
        SummonTheMajesticIncomeTextOOOOOHHHH();
        incomeText.GetComponent<TextMeshProUGUI>().text = incomeString;
    }

    public void CraftCake() {
        Debug.Log("Crafting cake");
        Craft(recipes.First(x => x.name == "Cake"));
    }

    public void CraftBread() {
        Debug.Log("Crafting bread");
        Craft(recipes.First(x => x.name == "Bread"));
    }

    public void CraftCheese() {
        Debug.Log("Crafting cheese");
        Craft(recipes.First(x => x.name == "Cheese"));
    }

    public void CraftOmelette() {
        Debug.Log("Crafting omelette");
        Craft(recipes.First(x => x.name == "Omelette"));
    }

    private void Craft(Recipe recipe) {

        int newPorkYield = PorkYield;
        int newMilkYield = MilkYield;
        int newEggsYield = EggsYield;
        int newWheatYield = WheatYield;

        foreach(KeyValuePair<Resources, int> ingredient in recipe.ingredients) {
            if(ingredient.Key.ToString() == "Eggs") {
                if(EggsYield < ingredient.Value) {
                    Debug.Log("Not enough eggs");
                    return;
                }
                newEggsYield -= ingredient.Value;
            }
            if(ingredient.Key.ToString() == "Milk") {
                if(MilkYield < ingredient.Value) {
                    Debug.Log("Not enough milk");
                    return;
                }
                newMilkYield -= ingredient.Value;
            }
            if(ingredient.Key.ToString() == "Wheat") {
                if(WheatYield < ingredient.Value) {
                    Debug.Log("Not enough wheat");
                    return;
                }
                newWheatYield -= ingredient.Value;
            }
            if(ingredient.Key.ToString() == "Pork") {
                if(PorkYield < ingredient.Value) {
                    Debug.Log("Not enough pork");
                    return;
                }
                newPorkYield -= ingredient.Value;
            }
        }
        PorkYield = newPorkYield;
        MilkYield = newMilkYield;
        EggsYield = newEggsYield;
        WheatYield = newWheatYield;
        
        craftedRecipes[recipe] += 1;
        ReloadBaseResourceText();
        ReloadIncomeText();
    }

    public void RemoveRecipe(Recipe recipe) {
        if(craftedRecipes[recipe] <= 0) {
            return;
        }
        craftedRecipes[recipe] -= 1;
        ReloadBaseResourceText();
        ReloadIncomeText();
    }
}
