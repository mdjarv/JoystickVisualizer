using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraControls : MonoBehaviour {
    public Transform target;
    public float distance = 35.0f;
    public float xSpeed = 1.0f;
    public float ySpeed = 6.0f;
    public float yMinLimit = -90f;
    public float yMaxLimit = 90f;
    public float distanceMin = 20f;
    public float distanceMax = 120f;
    public float smoothTime = 10f;
    float rotationYAxis = 0.0f;
    float rotationXAxis = 0.0f;
    float velocityX = 0.0f;
    float velocityY = 0.0f;

    // Use this for initialization
    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        rotationYAxis = angles.y;
        rotationXAxis = angles.x;
        // Make the rigid body not change rotation
        if (GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().freezeRotation = true;
        }

        Color color;
        if(ColorUtility.TryParseHtmlString(PlayerPrefs.GetString("Color", "#1F3E5D"), out color)) {
            Camera cam = GetComponent<Camera>();
            cam.backgroundColor = color;
        }
    }

    void Update()
    {
        if (target)
        {
            if (Mouse.current.rightButton.isPressed)
            {
                var dx = Mouse.current.delta.x.ReadValue();
                var dy = Mouse.current.delta.y.ReadValue();

                velocityX += xSpeed * dx * 35f * 0.02f;
                velocityY += ySpeed * dy * 0.5f * 0.02f;
            }
            rotationYAxis += velocityX;
            rotationXAxis -= velocityY;

            if (Keyboard.current.digit1Key.wasPressedThisFrame)
            {
                rotationYAxis = 0;
                rotationXAxis = 15;
            }

            if (Keyboard.current.digit2Key.wasPressedThisFrame)
            {
                rotationYAxis = 0;
                rotationXAxis = 90;
            }

            if (Keyboard.current.digit3Key.isPressed)
            {
                rotationYAxis = 90;
                rotationXAxis = 0;
            }

            rotationXAxis = ClampAngle(rotationXAxis, yMinLimit, yMaxLimit);
            //Quaternion fromRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
            Quaternion toRotation = Quaternion.Euler(rotationXAxis, rotationYAxis, 0);
            Quaternion rotation = toRotation;

            distance = Mathf.Clamp(distance - Mouse.current.scroll.y.ReadValue() * 0.1f, distanceMin, distanceMax);
            RaycastHit hit;
            if (Physics.Linecast(target.position, transform.position, out hit))
            {
            distance -= hit.distance;
            }
            Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
            Vector3 position = rotation * negDistance + target.position;

            transform.rotation = rotation;
            transform.position = position;
            velocityX = Mathf.Lerp(velocityX, 0, Time.deltaTime * smoothTime);
            velocityY = Mathf.Lerp(velocityY, 0, Time.deltaTime * smoothTime);
        }
    }
    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}
