using UnityEngine;

public class RestrictMovement : MonoBehaviour
{
    public Vector3 minBounds; // Giới hạn dưới (vị trí tối thiểu)
    public Vector3 maxBounds; // Giới hạn trên (vị trí tối đa)

    void Update()
    {
        // Giới hạn vị trí nhân vật trong khu vực
        Vector3 currentPosition = transform.position;
        currentPosition.x = Mathf.Clamp(currentPosition.x, minBounds.x, maxBounds.x);
        currentPosition.y = Mathf.Clamp(currentPosition.y, minBounds.y, maxBounds.y);
        currentPosition.z = Mathf.Clamp(currentPosition.z, minBounds.z, maxBounds.z);

        transform.position = currentPosition;
    }
}
