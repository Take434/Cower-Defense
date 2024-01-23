using System.Collections.Generic;

public class Recipe {
  public string name;
  public KeyValuePair<string, int> ingredients;
  public int income;
  public Recipe(string name, KeyValuePair<string, int> ingredients, int income) {
    this.name = name;
    this.ingredients = ingredients;
    this.income = income;
  }
}