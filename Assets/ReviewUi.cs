using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReviewUi : MonoBehaviour {

  public Text uiNotes;

	// Use this for initialization
	void Start () {
    foreach (string note in Helpers.notes) {
      uiNotes.text += "- " + note + "\n";
    }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
