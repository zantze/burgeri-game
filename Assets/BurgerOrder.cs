using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerOrder : MonoBehaviour {

  public float dirtiness;
  public Collider2D[] plates;

  Collider2D collider;

	// Use this for initialization
	void Start () {
    collider = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

  private void OnCollisionStay2D(Collision2D collision) {

    bool check = false;
    foreach (Collider2D thing in plates) {
      if (collision.collider == thing) {
        check = true;
      }
    }

    if (!check) {
      dirtiness += Time.deltaTime;
    }
  }
}
