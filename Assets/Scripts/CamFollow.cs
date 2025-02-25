using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform ball;            // Reference to the ball
    public float followSpeed = 5f;    // Speed at which the camera follows the ball
    public Vector3 offset;            // Offset to maintain distance between the camera and the ball

    void LateUpdate()
    {
        // Target position with the offset
        Vector3 targetPosition = ball.position + offset;

        // Smoothly move the camera to the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }
}
