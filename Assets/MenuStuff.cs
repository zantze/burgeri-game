using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuStuff : MonoBehaviour {

	// Use this for initialization
	void Start () {
    Destroy(GameObject.Find("CreatedBurger"));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

  public void StartGame() {
    Application.LoadLevel("Main");
  }

  public void GoToCredits() {
    Application.LoadLevel("Ending");
  }

  public void CloseGame() {
    Application.Quit();
  }
}
