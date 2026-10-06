using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    public float mouseSensitivity = 100f;

    private float rotationY = 0f;
    private float rotationX = 20f;

    void LateUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            rotationY += mouseX;
            rotationX -= mouseY;

            player.rotation = Quaternion.Euler(0f, rotationY, 0f);

            rotationX = Mathf.Clamp(rotationX, -20f, 60f);
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        Quaternion rotation = Quaternion.Euler(rotationX, rotationY, 0f);

        transform.position = player.position + rotation * offset;

        transform.LookAt(player);
    }
}