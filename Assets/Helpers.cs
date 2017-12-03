using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class Helpers  {

  public static List<string> notes = new List<string>();
  public static Rank rank = new Rank();
  public static Sprite face;

  public static string recipe1string = " 2x salad\n 2x steak\n 3x pickles";
  public static string recipe2string = " 2x salad\n 2x steak\n 18x pickles";
  public static string recipe3string = " 16x steak";

  public static List<Ingredient> recipe1 = new List<Ingredient> {
      new Ingredient("Bun bottom"),
      new Ingredient("Bun top"),
      new Ingredient("Steak"),
      new Ingredient("Steak"),
      new Ingredient("Salad"),
      new Ingredient("Salad"),
      new Ingredient("Pickle"),
      new Ingredient("Pickle"),
      new Ingredient("Pickle")
    };

  public static List<Ingredient> recipe2 = new List<Ingredient> {
      new Ingredient("Bun bottom"),
      new Ingredient("Bun top"),
      new Ingredient("Steak"),
      new Ingredient("Steak"),
      new Ingredient("Salad"),
      new Ingredient("Salad"),
      new Ingredient("Pickle"),
      new Ingredient("Pickle"),
      new Ingredient("Pickle"),
      new Ingredient("Pickle"),
      new Ingredient("Pickle"),
      new Ingredient("Pickle"),
      new Ingredient("Pickle"),
      new Ingredient("Pickle"),
      new Ingredient("Pickle"),
      new Ingredient("Pickle"),
      new Ingredient("Pickle"),
      new Ingredient("Pickle"),
      new Ingredient("Pickle"),
      new Ingredient("Pickle"),
      new Ingredient("Pickle"),
      new Ingredient("Pickle"),
      new Ingredient("Pickle"),
      new Ingredient("Pickle"),
    };

  public static List<Ingredient> recipe3 = new List<Ingredient> {
      new Ingredient("Bun bottom"),
      new Ingredient("Bun top"),
      new Ingredient("Steak"),
      new Ingredient("Steak"),
      new Ingredient("Steak"),
      new Ingredient("Steak"),
      new Ingredient("Steak"),
      new Ingredient("Steak"),
      new Ingredient("Steak"),
      new Ingredient("Steak"),
      new Ingredient("Steak"),
      new Ingredient("Steak"),
      new Ingredient("Steak"),
      new Ingredient("Steak"),
      new Ingredient("Steak"),
      new Ingredient("Steak"),
      new Ingredient("Steak"),
      new Ingredient("Steak"),
    };

  public static List<Ingredient> currentRecipe = recipe1;
  public static string currentRecipeString = recipe1string;

  static public GameObject PlayRandomSound(AudioClip[] sounds, float volume = 0.3f) {

    GameObject sound = new GameObject();
    AudioSource aSource = sound.AddComponent<AudioSource>();
    aSource.volume = volume;

    int random = Random.Range(0, sounds.Length - 1);

    aSource.clip = sounds[random];
    aSource.Play();

    return sound;
  }

  static public GameObject PlaySound(AudioClip clip, float volume = 0.4f) {

    GameObject sound = new GameObject();
    AudioSource aSource = sound.AddComponent<AudioSource>();
    aSource.volume = volume;

    aSource.clip = clip;
    aSource.Play();

    return sound;
  }
}
