using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [Header("References")]

    [SerializeField] private float sensX;
    [SerializeField] private float sensY;

    [SerializeField] Transform cam;
    [SerializeField] private float maxDown = 15f;
    [SerializeField] private float maxUp = -5f;
    [SerializeField] private float maxLeft = -45f;
    [SerializeField] private float maxRight = -145f;



    float mouseX;
    float mouseY;

    float multiplier = 0.01f;

    float xRotation;
    float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        myInput();
        cam.transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0);
    }

    void myInput()
    {
        mouseX = Input.GetAxisRaw("Mouse X");
        mouseY = Input.GetAxisRaw("Mouse Y");

        // TODO : we may limit the xRotation as it may not be useful ( all mailBox on the same level, or similar)
        yRotation += mouseX * sensX * multiplier;
        xRotation -= mouseY * sensY * multiplier;

        xRotation = Mathf.Clamp(xRotation, maxDown, maxUp);
        yRotation = Mathf.Clamp(yRotation, maxRight, maxLeft);

        cam.transform.rotation = Quaternion.Euler(xRotation, yRotation,1);
    }
}
