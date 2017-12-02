using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoMusicTrgiiger : MonoBehaviour {

  public Collider2D player;

  public AudioSource music;
  AudioLowPassFilter lowp;

	// Use this for initialization
	void Start () {
    lowp = music.GetComponent<AudioLowPassFilter>();
    music.volume = 0.15f;
  }
	
	// Update is called once per frame
	void Update () {
		
	}

  void OnTriggerEnter2D(Collider2D other) {
    if (other == player) {
      lowp.cutoffFrequency = 22000;
      music.volume = 0.28f;
    }
  }

  void OnTriggerExit2D(Collider2D other) {
    if (other == player) {
      lowp.cutoffFrequency = 447;
      music.volume = 0.15f;
    }
  }
}
