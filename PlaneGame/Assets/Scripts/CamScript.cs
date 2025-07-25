using UnityEngine;

public class CamScript : MonoBehaviour
{
 

    public Transform target;      // Drag your player here
    public Vector3 offset = new Vector3(0, 0, -10); // Keep the camera behind the player
    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }
    }
}


