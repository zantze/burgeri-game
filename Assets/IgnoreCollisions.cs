using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollisions : MonoBehaviour {

  public List<Collider2D> colliders = new List<Collider2D>();

  public IgnoreCollisions() {

  }

  public IgnoreCollisions(List<Collider2D> _colliders) {
    colliders = _colliders;
  }

  // Use this for initialization
  void Start () {
    foreach (Collider2D asdfasdf in colliders) {
      Physics2D.IgnoreCollision(GetComponent<Collider2D>(), asdfasdf);
    }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

  public void RemoveCollisions(List<Collider2D> colliders) {
    foreach (Collider2D asdfasdf in colliders) {
      Physics2D.IgnoreCollision(GetComponent<Collider2D>(), asdfasdf);
    }
  }
}
