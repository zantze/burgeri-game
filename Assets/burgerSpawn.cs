using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burgerSpawn : MonoBehaviour {

  GameObject burger;

  void Awake() {
    burger = GameObject.Find("CreatedBurger");
    burger.transform.position = transform.position;
  }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
