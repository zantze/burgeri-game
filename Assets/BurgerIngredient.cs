using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerIngredient : MonoBehaviour {

  public Ingredient ingredient;
  public bool PlaySounds = true;
  float collisiounSoundCooldown = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    collisiounSoundCooldown += Time.deltaTime;

  }

  public Ingredient GetIngredient() {
    return ingredient;
  }

  private void OnCollisionEnter2D(Collision2D collision) {
    if (collision.relativeVelocity.magnitude >= 1) {
      PlayCollisionSound();
    }
  }

  private void OnCollisionStay2D(Collision2D collision) {
    if (collision.relativeVelocity.magnitude >= 1) {
      PlayCollisionSound();
    }
  }

  void PlayCollisionSound() {
    if (collisiounSoundCooldown > 0.1f && PlaySounds) {
      Helpers.PlayRandomSound(ingredient.collision);
      collisiounSoundCooldown = 0f;
    }
  }
}
