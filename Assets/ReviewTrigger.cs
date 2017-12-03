using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviewTrigger : MonoBehaviour {

  float time;

  float dirtiness;

  int correctBurgerParts;
  int requiredBurgerParts;

  bool hasTop;
  bool hasBottom;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

  void ReviewBurger() {

    GetParts();
    GetRecipe();

  }

  void GetParts() {

  }

  void GetRecipe() {

  }

  private void OnCollisionStay2D(Collision2D collision) {
    
  }

  private void OnCollisionExit2D(Collision2D collision) {
  }
}
