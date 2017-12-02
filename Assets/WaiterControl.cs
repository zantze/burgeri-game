using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaiterControl : MonoBehaviour {

  Rigidbody2D rb;
  public float speed;

  // Use this for initialization
  private void Awake() {
    rb = GetComponent<Rigidbody2D>();
  }

  void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    if (Input.GetKey(KeyCode.A)) {
      rb.AddForce(Vector2.left * speed);
    }

    if (Input.GetKey(KeyCode.D)) {
      rb.AddForce(Vector2.right * speed);
    }

  }
}
