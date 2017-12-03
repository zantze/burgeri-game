using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReviewUi : MonoBehaviour {

  public Text uiNotes;
  public RawImage rank;
  public GameObject face;


  int textIndex = 0;
  int notesIndex = 0;

  float imageInitialHeight;
  float imageInitialWidth;

  RectTransform rawImageBounds;

  Vector2 Initialbounds;

  private float velocity = 0.0F;


  // Use this for initialization
  void Start () {

    rank.texture = Helpers.rank.image;

    uiNotes.text += "\n -";

    rawImageBounds = rank.GetComponent<RectTransform>();
    Initialbounds = rawImageBounds.sizeDelta;
    rawImageBounds.sizeDelta = Vector2.zero;
  }
	
	// Update is called once per frame
	void Update () {

    var totalNotes = Helpers.notes.Count ;

    if (notesIndex < totalNotes) {
      if (textIndex < Helpers.notes[notesIndex].Length) {

        string note = Helpers.notes[notesIndex];
        uiNotes.text += note[textIndex];
        textIndex += 1;

      }

      else {
        notesIndex += 1;
        textIndex = 0;

        if (notesIndex < totalNotes) {
          uiNotes.text += "\n -";
        }

        else {
          Helpers.notes.Clear();
        }

      }

    }

    rawImageBounds.sizeDelta = new Vector3(Mathf.SmoothDamp(rawImageBounds.sizeDelta.x, Initialbounds.x, ref velocity, 1.2f), Mathf.SmoothDamp(rawImageBounds.sizeDelta.y, Initialbounds.y, ref velocity, 1.2f));
		
	}

  public void GotoNextLevel() {

    if (Helpers.currentRecipe == Helpers.recipe2) {

      Helpers.currentRecipe = Helpers.recipe3;
      Helpers.currentRecipeString = Helpers.recipe3string;

    }

    else if (Helpers.currentRecipe == Helpers.recipe3) {
      Application.LoadLevel("Ending");
      return;
    }

    else {
      Helpers.currentRecipe = Helpers.recipe2;
      Helpers.currentRecipeString = Helpers.recipe2string;
    }

    Destroy(GameObject.Find("CreatedBurger"));

    Application.LoadLevel("Main");
  }
}
