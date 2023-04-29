using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Car : MonoBehaviour
{
    
    [SerializeField]
    public float speed = 1f;
    public float rotationSpeed = 90f;

    private bool uTurn = false;
    private Vector3 vecTurn;
    private Rigidbody rb;
    private float targetRotation;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        vecTurn = new Vector3(0, rotationSpeed, 0);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 direction = rb.rotation * new Vector3(1, 0, 0);
        
        rb.MovePosition(rb.position + direction * Time.deltaTime * speed);

        if (uTurn)
        {
            Quaternion deltaRotation = Quaternion.Euler(vecTurn * Time.fixedDeltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
            if (rb.rotation.y >= targetRotation)
            {
                uTurn = false;
                rb.rotation = Quaternion.Euler(0, 90, 0);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        uTurn = true;
        Debug.Log("collide turn point at "+ rb.rotation.y);
        targetRotation = rb.rotation.y + 0.75f;
    }
}
