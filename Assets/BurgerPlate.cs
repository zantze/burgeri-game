using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerPlate : MonoBehaviour {

  public Collider2D takeout;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

  void OnTriggerEnter2D(Collider2D other) {

    if (other == takeout) {
      Debug.Log("finish");
    }
  }


}
