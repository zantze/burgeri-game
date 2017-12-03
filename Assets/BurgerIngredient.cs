using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerIngredient : MonoBehaviour {

  public Ingredient ingredient;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

  public Ingredient GetIngredient() {
    return ingredient;
  }

  private void OnCollisionEnter2D(Collision2D collision) {
    if (collision.relativeVelocity.magnitude >= 1) {
    }
  }

  private void OnCollisionStay2D(Collision2D collision) {
    if (collision.relativeVelocity.magnitude >= 1) {
      Helpers.PlayRandomSound(ingredient.collision);
    }
  }
}
