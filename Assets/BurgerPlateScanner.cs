using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerPlateScanner: MonoBehaviour {

  public List<Collider2D> ingredients = new List<Collider2D>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {  
	}
 
 void OnTriggerEnter2D(Collider2D other) {

    if (!ingredients.Contains(other)) {


      Ingredient ingredient = other.GetComponent<BurgerIngredient>().GetIngredient();

      if (ingredient is Ingredient) {
        ingredients.Add(other);
      }
    }
  }

  void OnTriggerExit2D(Collider2D other) {

    if (ingredients.Contains(other)) {

      ingredients.Remove(other);
    }
  }
}
