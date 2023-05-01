using System.Collections;
using UnityEngine;

public class MenuMailGun : MonoBehaviour
{
    private Transform gunCanon;
    public float turningStep;
    public float rotationDuration;

    private bool isFirstRotationComplete = false;

    private void Awake()
    {
        gunCanon = transform.Find("Cylinder");
        StartCoroutine(nameof(RotateLeft));
    }

    // Update is called once per frame
    void Update()
    {
        gunCanon.Rotate(Vector3.up);
        Shoot();
    }

    private void Shoot()
    {

    }

    private IEnumerator RotateLeft()
    {
        var allowedRotationDuration = isFirstRotationComplete ? rotationDuration : rotationDuration / 2f;
        var t = 0f;

        while (t < allowedRotationDuration)
        {
            t += Time.deltaTime;
            transform.Rotate(Vector3.up * turningStep * Time.deltaTime);

            yield return null;
        }

        if (!isFirstRotationComplete)
        {
            isFirstRotationComplete = true;
        }

        StopCoroutine(nameof(RotateLeft));
        Debug.Log("Stopping RotateLeft and starting RotateRight");
        StartCoroutine(nameof(RotateRight));
    }

    private IEnumerator RotateRight()
    {
        var allowedRotationDuration = isFirstRotationComplete ? rotationDuration : rotationDuration / 2f;
        var t = 0f;

        while (t < allowedRotationDuration)
        {
            t += Time.deltaTime;
            transform.Rotate(Vector3.up * -turningStep * Time.deltaTime);

            yield return null;
        }

        if (!isFirstRotationComplete)
        {
            isFirstRotationComplete = true;
        }

        StopCoroutine(nameof(RotateRight));
        Debug.Log("Stopping RotateRight and starting RotateLeft");
        StartCoroutine(nameof(RotateLeft));
    }
}
