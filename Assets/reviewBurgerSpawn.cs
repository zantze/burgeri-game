using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reviewBurgerSpawn : MonoBehaviour {

  public GameObject testObject;
  GameObject burger;

	// Use this for initialization
	void Start () {


    burger = GameObject.Find("CreatedBurger");
    burger.transform.position = transform.position;
    burger.transform.localScale = new Vector3(2f, 2f, 2f);


  }
	
	// Update is called once per frame
	void Update () {
		
	}
}
