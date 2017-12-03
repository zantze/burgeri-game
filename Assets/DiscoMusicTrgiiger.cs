using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoMusicTrgiiger : MonoBehaviour {

  public Collider2D player;

  public AudioSource music;
  AudioLowPassFilter lowp;

  public float smoothTime = 0.3F;
  private float yVelocity = 0.0F;

  // Use this for initialization
  void Start () {
    lowp = music.GetComponent<AudioLowPassFilter>();
    music.volume = 0.15f;
  }
	
	// Update is called once per frame
	void Update () {
		
	}

  void OnTriggerStay2D(Collider2D other) {
    if (other == player) {
      lowp.cutoffFrequency = Mathf.SmoothDamp(lowp.cutoffFrequency, 22000f, ref yVelocity, smoothTime);
      music.volume = 0.28f;
    }
  }

  void OnTriggerExit2D(Collider2D other) {
    if (other == player) {
      lowp.cutoffFrequency = 447f;
      music.volume = 0.15f;
    }
  }
}
