using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 2f;

    private void Update()
    {
        // Capture mouse movement
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // Rotate the player's view horizontally
        transform.Rotate(Vector3.up * mouseX);

        // Rotate the camera vertically
        float currentRotationX = transform.eulerAngles.x;
        float newRotationX = currentRotationX - mouseY;

        // Clamp vertical rotation to avoid flipping the camera
        newRotationX = Mathf.Clamp(newRotationX, 0f, 80f); // Adjust the angle limits as needed

        transform.rotation = Quaternion.Euler(newRotationX, transform.eulerAngles.y, 0f);
    }
}
