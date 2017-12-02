using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaiterControl : MonoBehaviour {

  Rigidbody2D rb;
  public float speed;
  bool moving;

  public float movementing = 0; 

  public GameObject movingLegs;
  public GameObject stationaryLegs;
  public GameObject body;

  public AudioClip[] footsteps; 

  // Use this for initialization
  private void Awake() {
    rb = GetComponent<Rigidbody2D>();
  }

  void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    float magnitude = GetComponent<Rigidbody2D>().velocity.magnitude;

    moving = false;
    bool flip = false;

    if (Input.GetKey(KeyCode.A)) {
      rb.AddForce(Vector2.left * speed);
      moving = true;
      flip = true;
    }

    else if (Input.GetKey(KeyCode.D)) {
      rb.AddForce(Vector2.right * speed);
      moving = true;
      flip = false;
    }

    if (moving) {
      ToggleLegs(true, flip);
      movementing += magnitude;
    }

    else {
      ToggleLegs(false, flip);
    }

    body.GetComponent<SpriteRenderer>().flipX = flip;


    if (movementing > 50) {
      GameObject sound = new GameObject();
      AudioSource aSource = sound.AddComponent<AudioSource>();
      aSource.volume = 0.5f;

      int random = Random.Range(0, footsteps.Length - 1);

      
      aSource.clip = footsteps[random];
      aSource.Play();

      Destroy(sound, aSource.clip.length);
      movementing = 0;
    }
  }

  void ToggleLegs(bool check, bool direction) {
    if (check) {
      movingLegs.GetComponent<SpriteRenderer>().enabled = true;
      movingLegs.GetComponent<SpriteRenderer>().flipX = direction;
      stationaryLegs.GetComponent<SpriteRenderer>().enabled = false;
    }

    else {
      movingLegs.GetComponent<SpriteRenderer>().enabled = false;
      stationaryLegs.GetComponent<SpriteRenderer>().enabled = true;
      stationaryLegs.GetComponent<SpriteRenderer>().flipX = direction;

    }
  }
}
