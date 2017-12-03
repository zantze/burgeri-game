using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingRules : MonoBehaviour {

  public List<Ingredient> currentBurger = new List<Ingredient>();
  public List<Ingredient> currentRecipe = new List<Ingredient>();
  public BurgerPlateScanner plate;

	// Use this for initialization
	void Start () {

    // Placeholder recipe
    // We shall generate the recipes in the future
    List<Ingredient> recipe = new List<Ingredient> {
      new Ingredient("Bun bottom"),
      new Ingredient("Bun top"),
      new Ingredient("Steak"),
      new Ingredient("Steak"),
      new Ingredient("Salad"),
      new Ingredient("Salad"),
      new Ingredient("Pickle"),
      new Ingredient("Pickle"),
      new Ingredient("Pickle")
    };
    // TODO: get the recipe from external resource
    LoadRecipe(recipe);
	}
	
	// Update is called once per frame
	void Update () {
    currentBurger = GenerateList();
  }

  List<Ingredient> GenerateList() {
    List<Ingredient> list = new List<Ingredient>();
 
    foreach (Collider2D ingredient in plate.ingredients ) {
      list.Add(ingredient.GetComponent<BurgerIngredient>().GetIngredient());
    }

    return list;
  }

  void LoadRecipe(List<Ingredient> recipe) {
    currentRecipe = recipe;
  }
}
