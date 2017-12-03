using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeHolder : MonoBehaviour {
  public List<Ingredient> recipe = new List<Ingredient>();

  public List<Ingredient> GetRecipe() {
    return recipe;
  }

}
