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
    public int PorkValue;
    public int MilkValue;
    public int EggsValue;
    public int WheatValue;
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
        money = 100;
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
        money += PorkYield * PorkValue;
        money += MilkYield * MilkValue;
        money += EggsYield * EggsValue;
        money += WheatYield * WheatValue;
        foreach(KeyValuePair<Recipe, int> recipe in craftedRecipes) {
            money += recipe.Key.income * recipe.Value;
        }
    }

    public void Setup() {
        Recipe Cake = new Recipe("Cake", new Dictionary<Resources, int> {
            {Resources.Wheat, 3},
            {Resources.Eggs, 3},
            {Resources.Milk, 2}
        }, 60);
        recipes.Add(Cake);

        Recipe Bread = new Recipe("Bread", new Dictionary<Resources, int> {
            {Resources.Wheat, 3}
        }, 15);
        recipes.Add(Bread);

        Recipe Cheese = new Recipe("Cheese", new Dictionary<Resources, int> {
            {Resources.Milk, 2}
        }, 10);
        recipes.Add(Cheese);

        Recipe Omelette = new Recipe("Omelette", new Dictionary<Resources, int> {
            {Resources.Eggs, 2}
        }, 20);
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
        incomeString += "Pork: " + PorkYield + " * " + PorkValue + " = " + PorkYield * PorkValue + "\n";
        incomeString += "Milk: " + MilkYield + " * " + MilkValue + " = " + MilkYield * MilkValue + "\n";
        incomeString += "Eggs: " + EggsYield + " * " + EggsValue + " = " + EggsYield * EggsValue + "\n";
        incomeString += "Wheat: " + WheatYield + " * " + WheatValue + " = " + WheatYield * WheatValue + "\n";
        foreach(KeyValuePair<Recipe, int> recipe in craftedRecipes) {
            incomeString += recipe.Key.name + ": " + recipe.Value + " * " + recipe.Key.income + " = " + recipe.Value * recipe.Key.income + "\n";
        }
        totalIncome = PorkYield * PorkValue + MilkYield * MilkValue + EggsYield * EggsValue + WheatYield * WheatValue + craftedRecipes.Sum(x => x.Key.income * x.Value);
        incomeString += "\n Total income: " + totalIncome;
    }

    public void ReloadIncomeText() {
        SummonTheMajesticIncomeTextOOOOOHHHH();
        incomeText.GetComponent<TextMeshProUGUI>().text = incomeString;
    }

    public void CraftCake() {
        Craft(recipes.First(x => x.name == "Cake"));
    }

    public void CraftBread() {
        Craft(recipes.First(x => x.name == "Bread"));
    }

    public void CraftCheese() {
        Craft(recipes.First(x => x.name == "Cheese"));
    }

    public void CraftOmelette() {
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
                    return;
                }
                newEggsYield -= ingredient.Value;
            }
            if(ingredient.Key.ToString() == "Milk") {
                if(MilkYield < ingredient.Value) {
                    return;
                }
                newMilkYield -= ingredient.Value;
            }
            if(ingredient.Key.ToString() == "Wheat") {
                if(WheatYield < ingredient.Value) {
                    return;
                }
                newWheatYield -= ingredient.Value;
            }
            if(ingredient.Key.ToString() == "Pork") {
                if(PorkYield < ingredient.Value) {
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
