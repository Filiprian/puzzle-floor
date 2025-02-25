using UnityEngine;

public class PlatformRotation : MonoBehaviour
{
    public GameObject platform;  // Assign platform GameObject in the Inspector
    public float rotationSpeed = 50f;  // Rotation speed in degrees per second

    void Update()
    {
        // Get player input and calculate rotation
        float horizontalInput = Input.GetAxis("Horizontal");  // A/D or Arrow keys
        float verticalInput = Input.GetAxis("Vertical");  // W/S or Arrow keys

        // Apply rotation based on input
        platform.transform.Rotate(Vector3.right * verticalInput * rotationSpeed * Time.deltaTime);
        platform.transform.Rotate(Vector3.forward * -horizontalInput * rotationSpeed * Time.deltaTime);
    }
}
