using System.Collections.Generic;

public class Recipe {
  public string name;
  public Dictionary<Resources, int> ingredients;
  public int income;
  public Recipe(string name, Dictionary<Resources, int> ingredients, int income) {
    this.name = name;
    this.ingredients = ingredients;
    this.income = income;
  }
}