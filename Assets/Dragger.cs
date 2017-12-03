using UnityEngine;

public class Dragger : MonoBehaviour {
  public LayerMask layermask;

  public GameObject plate;
  bool lockPlate = false;

  public float damping = 1.0f;
  public float freq = 5.0f;

  private TargetJoint2D joint;

  void Start() {

  }

  void Update() { 
    var worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    if (Input.GetMouseButtonDown(0)) {

      var collider = Physics2D.OverlapPoint(worldPos, layermask);
      if (collider) {

        var body = collider.attachedRigidbody;
        if (body) {

          joint = body.gameObject.AddComponent<TargetJoint2D>();
          joint.dampingRatio = damping;
          joint.frequency = freq;

          joint.anchor = joint.transform.InverseTransformPoint(worldPos);

          if (body.gameObject == plate) {
            lockPlate = true;
          }

        }
      }


    }
    else if (Input.GetMouseButtonUp(0)) {
      Destroy(joint);
      joint = null;

      lockPlate = false;

    }

    if (joint) {
      joint.target = worldPos;
    }

    if (lockPlate) {
      plate.GetComponent<Collider2D>().transform.eulerAngles = new Vector3(plate.GetComponent<Collider2D>().transform.eulerAngles.x, plate.GetComponent<Collider2D>().transform.eulerAngles.y, 0);
      plate.GetComponent<Rigidbody2D>().freezeRotation = true;
    }

    else {
      plate.GetComponent<Rigidbody2D>().freezeRotation = false;
    }
  }
}