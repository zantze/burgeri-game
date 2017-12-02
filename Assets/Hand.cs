using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {

  public Transform character;
  public Transform parent;

  Vector3 origin;
  Vector3 target;
  public float armLength;
  public float smoothTime; 

  private Vector3 velocity = Vector3.zero;

  Rigidbody2D rb;

	// Use this for initialization
	void Start () {
    rb = GetComponent<Rigidbody2D>();
    Physics2D.IgnoreCollision(character.GetComponent<Collider2D>(), GetComponent<Collider2D>());
  }
	
	// Update is called once per frame
	void Update () {
    origin = parent.transform.position;
    Vector2 mousePos = Input.mousePosition;

    target = Camera.main.ScreenToWorldPoint(mousePos);
    target.z = 0;

    Vector3 direction = -(origin - target).normalized;

    // Debug.DrawLine(origin, origin + direction * 10, Color.red, Mathf.Infinity);

    rb.MovePosition(Vector3.SmoothDamp(transform.position, origin + direction * Mathf.Clamp(Vector3.Distance(origin, target), 0f, armLength), ref velocity, smoothTime));
  }
}
