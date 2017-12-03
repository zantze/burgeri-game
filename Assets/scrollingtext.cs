using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollingtext : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    transform.Translate(transform.up * Time.deltaTime * 38);
	}
}
