using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerPlate : MonoBehaviour {

  bool createOnce = true;
  bool finishBurger = false;

  public Collider2D takeout;
  public BurgerPlateScanner scanner;
	// Use this for initialization
	void Start () {

    createOnce = true;
		
	}
	
	// Update is called once per frame
	void Update () {

	}

  void OnTriggerStay2D(Collider2D other) {


    if (other == takeout && createOnce && GetComponent<Rigidbody2D>().velocity.magnitude < 1f) {

      GameObject completeBurger = new GameObject("hello");

      foreach (Collider2D collider in scanner.ingredients) {
        collider.transform.SetParent(completeBurger.transform);

        Destroy(collider.gameObject.GetComponent<Rigidbody2D>());
      }

      completeBurger.AddComponent<Rigidbody2D>();

      createOnce = false;
    }
  }



}
