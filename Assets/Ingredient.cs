using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ingredient  {

  public string name;
  public Texture icon;

  public AudioClip spawnSound;
  public AudioClip[] collision;

  public Ingredient(string _name) {
    name = _name;
  }

  public Ingredient(string _name, Texture _sprite) {
    name = _name;
    icon = _sprite;
  }

}
