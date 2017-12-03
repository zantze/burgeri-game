using UnityEngine;

/// <summary>
/// Drag a Rigidbody2D by selecting one of its colliders by pressing the mouse down.
/// When the collider is selected, add a TargetJoint2D.
/// While the mouse is moving, continually set the target to the mouse position.
/// When the mouse is released, the TargetJoint2D is deleted.`
/// </summary>
public class Dragger : MonoBehaviour {
  public LayerMask m_DragLayers;

  public GameObject plate;
  bool lockPlate = false;
  [Range(0.0f, 100.0f)]
  public float m_Damping = 1.0f;

  [Range(0.0f, 100.0f)]
  public float m_Frequency = 5.0f;

  public bool m_DrawDragLine = true;
  public Color m_Color = Color.cyan;

  private TargetJoint2D m_TargetJoint;

  void Update() { 

    // Calculate the world position for the mouse.
    var worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    if (Input.GetMouseButtonDown(0)) {
      // Fetch the first collider.
      // NOTE: We could do this for multiple colliders.
      var collider = Physics2D.OverlapPoint(worldPos, m_DragLayers);
      if (!collider)
        return;

      // Fetch the collider body.
      var body = collider.attachedRigidbody;
      if (!body)
        return;

      // Add a target joint to the Rigidbody2D GameObject.
      m_TargetJoint = body.gameObject.AddComponent<TargetJoint2D>();
      m_TargetJoint.dampingRatio = m_Damping;
      m_TargetJoint.frequency = m_Frequency;

      // Attach the anchor to the local-point where we clicked.
      m_TargetJoint.anchor = m_TargetJoint.transform.InverseTransformPoint(worldPos);

      if (body.gameObject == plate) {
        lockPlate = true;
      }
    }
    else if (Input.GetMouseButtonUp(0)) {
      Destroy(m_TargetJoint);
      m_TargetJoint = null;

      lockPlate = false;

      return;
    }

    // Update the joint target.
    if (m_TargetJoint) {
      m_TargetJoint.target = worldPos;

      // Draw the line between the target and the joint anchor.
      if (m_DrawDragLine)
        Debug.DrawLine(m_TargetJoint.transform.TransformPoint(m_TargetJoint.anchor), worldPos, m_Color);
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