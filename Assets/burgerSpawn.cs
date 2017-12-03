using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burgerSpawn : MonoBehaviour {

  public List<Ingredient> recipe;
  public List<Ingredient> ingredients;

  GameObject burger;
  public Material spriteMaterial;
  public GameObject player;

  public Collider2D[] colliderIgnores;

  void Awake() {
    // Find the burger from the previous scene
    burger = GameObject.Find("CreatedBurger");

    // Scale down the burger
    burger.transform.localScale = new Vector3(0.55f, 0.55f, 0.55f);

    // Get list with player's collider so we can ignore collision between player and burger part
    var lista = new List<Collider2D>() {
        player.GetComponent<Collider2D>()
      };

    foreach (Transform child in burger.transform) {

      // Remove sound and add material to burger part
      child.GetComponent<BurgerIngredient>().PlaySounds = false;
      child.GetComponent<SpriteRenderer>().material = spriteMaterial;

      // Add IgnoreCollision script to our burger part
      IgnoreCollisions script = child.gameObject.AddComponent<IgnoreCollisions>();

      // Remove player and burger part collision
      script.RemoveCollisions(lista);

      // Add the ingredients into this burgers recipe
      ingredients.Add(child.GetComponent<BurgerIngredient>().GetIngredient());
    }

    // Change burger gravity
    burger.GetComponent<Rigidbody2D>().gravityScale = 0.4f;

    // Lets create a component for the burger, that carries the data over to 'review' scene
    BurgerOrder bo = burger.AddComponent<BurgerOrder>();
    // We need to get some ignores so we can exclude plate and the initial table from dirtiness meter
    bo.plates = colliderIgnores;

    bo.burger = ingredients;

    // Not sure what these are
    IgnoreCollisions ic = burger.AddComponent<IgnoreCollisions>();
    ic.colliders.Add(player.GetComponent<Collider2D>());

    // Move the burger to the spawn location
    burger.transform.position = transform.position;
  }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
