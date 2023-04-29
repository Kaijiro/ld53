using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody rb;
    private Ratatata spawner;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MailBox"))
        {
            Debug.Log("BINGO");
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        spawner.decreaseProjectileCount();   
    }

    public void setSpawner(Ratatata newSpawner)
    {
        spawner = newSpawner;
    }


}
