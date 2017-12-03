using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class Helpers  {

  public static List<string> notes = new List<string>();
  public static Rank rank = new Rank();

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
