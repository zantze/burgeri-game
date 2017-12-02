using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour {

  public GameObject[] ingredients;


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
    }

    if (Input.GetKeyDown(KeyCode.A)) {
      index -= 1;
      Debug.Log(ingredients[index]);
    }

    if (Input.GetKeyDown(KeyCode.D)) {
      index += 1;
      Debug.Log(ingredients[index]);
    }


  }
}
