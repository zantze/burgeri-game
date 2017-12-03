using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burgerSpawn : MonoBehaviour {

  GameObject burger;
  public Material spriteMaterial;
  public GameObject player;

  void Awake() {
    burger = GameObject.Find("CreatedBurger");

    burger.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);

    foreach (Transform child in burger.transform) {
      child.GetComponent<SpriteRenderer>().material = spriteMaterial;
    }

    burger.GetComponent<Rigidbody2D>().gravityScale = 0.4f;

    IgnoreCollisions ic = burger.AddComponent<IgnoreCollisions>();
    ic.colliders.Add(player.GetComponent<Collider2D>());

    burger.transform.position = transform.position;
  }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
