using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaosSpawner : MonoBehaviour
{
    public GameObject tract;
    public int maxProjectile = 50;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject projectile = Instantiate(tract);

        projectile.GetComponent<Rigidbody>().useGravity = true;
        projectile.GetComponent<Rigidbody>().mass = 0.2f;

    }


}
