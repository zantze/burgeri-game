using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviewTrigger : MonoBehaviour {

  public GameObject burger;

  float ticker = 0f;

  float time;

  float dirtiness;

  int correctBurgerParts;
  int requiredBurgerParts;

  bool hasTop;
  bool hasBottom;

  int score = 300;

  public Rank rankS = new Rank();
  public Rank rankA = new Rank();
  public Rank rankB = new Rank();
  public Rank rankC = new Rank();
  public Rank rankD = new Rank();
  public Rank rankE = new Rank();
  public Rank rankF = new Rank();
  public Rank rankFMinus = new Rank();



  // Use this for initialization
  void Start () {
	}
	
	// Update is called once per frame
	void Update () {

    if (ticker > 1.5f) {
      ReviewBurger();
    }

    time += Time.deltaTime;
  }

  void ReviewBurger() {

    if (burger == null) {
      score -= 10000;
      AddNote("Where is my burger? I want my money back.");
      SetRank(rankFMinus);
      ChangeStage();

      return; 
    }

    var parts = GetParts();
    var recipe = GetRecipe();

    if (parts != null && recipe != null) {
      foreach (Ingredient burgerPart in parts) {
        foreach (Ingredient recipePart in recipe) {
          if (burgerPart.name == recipePart.name) {
            parts.Remove(burgerPart);
            recipe.Remove(recipePart);
          }
        }
      }

      var extraParts = parts.Count;
      var missingParts = recipe.Count;

      // If the player inserted extra stuff
      if (extraParts > 0) {
        AddNote("I didn't ask for these?");
        score -= extraParts * 10;
      }

      // if the played didnt put everything
      if (missingParts > 0) {
        AddNote("Seems like something is missing from here.");
        score -= missingParts * 10;
      }

      // If the parts were correct
      else {
        AddNote("The burger seems to be what I ordered.");
      }

      // Check if the top and bottom are missing
      foreach (Ingredient ing in recipe) {
        if (ing.name == "Bun top" || ing.name == "Bun bottom") {
          AddNote("If a burger is missing the bun, can you even consider it a burger?");
          score -= 25;
        }
      }

      // Time checks
      DoTimeThings();
      // Filthiness check
      CheckFilthiness();
      // Set the rank
      SetRank(GetRank(score));
      // Change level here.
      Debug.Log(score);
      ChangeStage();
    }

  }

  List<Ingredient> GetParts() {
    if (burger != null) {
      var parts = burger.GetComponent<BurgerOrder>().burger;

      return parts;
    }

    return null;
  }

  List<Ingredient> GetRecipe() {
    if (burger != null) {
      var recipe = burger.GetComponent<RecipeHolder>().recipe;

      return recipe;
    }

    return null;
  }

  void DoTimeThings() {
    if (time < 30) {
      AddNote("The service is really quick here!");
    }

    else if (time < 60) {
      score -= 15;
      AddNote("The burger is still warm.");
    }

    else if (time < 90) {
      score -= 30;
      AddNote("The service could be a bit quicker.");
    }

    else {
      score -= 75;
      AddNote("I was about to leave but the waiter got just in time to bring me my cold burger.");
    }
  }

  void CheckFilthiness() {
    if (dirtiness < 10) {

    }

    else if (dirtiness < 20) {
      score -= 30;
      AddNote("The burger looks fine, but tastes a bit like the floor.");
    }

    else if (dirtiness < 30) {
      score -= 75;
      AddNote("The burger looks rather dirty, like it has been used to mop the floors.");
    }

    else {
      score -= 100;
      AddNote("Where has this burger been? It's filthier than my browsing history.");
    }
  }

  void AddNote(string note) {
    Helpers.notes.Add(note);
  }

  Rank GetRank(int score) {
    if (score <= 0) {
      return rankF;
    }

    if (score <= 50) {
      return rankE;
    }

    if (score <= 100) {
      return rankD;
    }

    if (score <= 150) {
      return rankC;
    }

    if (score <= 200) {
      return rankB;
    }

    if (score <= 250) {
      return rankA;
    }

    if (score <= 300) {
      return rankS;
    }

    return rankF;
  }

  void SetRank(Rank rank) {
    Helpers.rank = rank;
  }

  void ChangeStage() {
    Application.LoadLevel("review");
  }

  private void OnTriggerStay2D(Collider2D collision) {

    if (collision.gameObject.GetComponent<Hand>() != null) {
      ticker += Time.deltaTime;
    }

    if (collision.gameObject.GetComponent<BurgerOrder>()) {
      burger = collision.gameObject;
    }

    else if (collision.transform.parent.GetComponent<BurgerOrder>()) {
      burger = collision.transform.parent.gameObject;
    }
  }

  private void OnTriggerExit2D(Collider2D collision) {
    if (collision.gameObject.GetComponent<Hand>() != null) {
      ticker = 0f;
    }

    if (collision.gameObject.GetComponent<BurgerOrder>() != null) {
      burger = null;
    }

    else if (collision.transform.parent.GetComponent<BurgerOrder>()) {
      burger = null;
    }
  }
}
