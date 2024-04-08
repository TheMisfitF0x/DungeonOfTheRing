using UnityEngine;

public class CustomGizmoDrawer : MonoBehaviour
{
    private void OnDrawGizmosSelected()
    {
        // Store the game object's rotation
        Quaternion rotation = transform.rotation;

        // Set the gizmo color
        Gizmos.color = Color.yellow;

        // Draw the main body of the arrow
        Vector3 startPos = transform.position;
        Vector3 endPos = startPos + rotation * Vector3.up * 1.0f; // Use the rotation to calculate the direction of the arrow
        Gizmos.DrawLine(startPos, endPos);

        // Draw the arrowhead
        float arrowSize = 0.1f; // Adjust the size of the arrowhead as needed
        Vector3 arrowTip = endPos + rotation * Vector3.up * arrowSize;
        Vector3 arrowLeft = endPos + rotation * (Quaternion.Euler(0, 0, 135) * Vector3.right * arrowSize);
        Vector3 arrowRight = endPos + rotation * (Quaternion.Euler(0, 0, -135) * Vector3.right * arrowSize);
        Gizmos.DrawLine(endPos, arrowTip);
        Gizmos.DrawLine(endPos, arrowLeft);
        Gizmos.DrawLine(endPos, arrowRight);
    }
}
