using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoLight : MonoBehaviour {

  Light lite;
  List<Color> colors = new List<Color>();
  public float timer = 0;

	// Use this for initialization
	void Start () {
    lite = GetComponent<Light>();

    colors.Add(Color.red);
    colors.Add(Color.magenta);
    colors.Add(Color.blue);
    colors.Add(Color.cyan);
    colors.Add(Color.blue);
    colors.Add(Color.green);
    colors.Add(Color.yellow);
  }
	
	// Update is called once per frame
	void Update () {
    timer += Time.deltaTime;

    if (timer >= 0.5291666666) {
      Color currentColor = lite.color;
      Color newColor = lite.color;

      while (newColor == currentColor) {


        int rnd = Random.Range(0, colors.Count - 1);
        newColor = colors[rnd];
        lite.color = newColor;
        timer = 0;

      }
    }
	}
}
