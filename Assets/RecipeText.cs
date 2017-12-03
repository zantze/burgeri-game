using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeText : MonoBehaviour {

  Text recipeText;

	// Use this for initialization
	void Start () {
    recipeText = GetComponent<Text>();
    recipeText.text = Helpers.currentRecipeString;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
