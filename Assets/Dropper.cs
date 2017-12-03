using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dropper : MonoBehaviour {

  public GameObject[] ingredients;
  public RawImage uiSelector; 


  public int index = 0;

	// Use this for initialization
	void Start () {

  }
	
	// Update is called once per frame
	void Update () {
    if (Input.GetKeyDown(KeyCode.Space)) {
      Vector3 v3 = Input.mousePosition;
      v3.z = 10f;
      v3 = Camera.main.ScreenToWorldPoint(v3);

      Instantiate(ingredients[index], v3, Quaternion.identity);
      Helpers.PlaySound(ingredients[index].GetComponent<BurgerIngredient>().GetIngredient().spawnSound);
    }

    if (Input.GetKeyDown(KeyCode.A) && index > 0) {
      index -= 1;
      Debug.Log(ingredients[index]);
      ChangeIcon();
    }

    if (Input.GetKeyDown(KeyCode.D) && index < ingredients.Length - 1) {
      index += 1;
      Debug.Log(ingredients[index]);
      ChangeIcon();
    }


  }

  void ChangeIcon() {
    uiSelector.texture = ingredients[index].GetComponent<BurgerIngredient>().GetIngredient().icon;
  }
}
