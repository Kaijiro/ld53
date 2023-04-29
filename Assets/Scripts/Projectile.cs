using System;
using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody rb;
    private Ratatata spawner;


    private void Awake()
    {
        StartCoroutine(SelfDestruct());
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MailBox"))
        {
            Debug.Log("[PROJECTILE] Tract went to Nirvana");
            Destroy(gameObject);

            var mailbox = other.gameObject.GetComponent<Mailbox>();
            mailbox.OnProjectileHit();
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

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(3);
        StopCoroutine(nameof(SelfDestruct));
        Debug.Log("[PROJECTILE] Tract died of old age");
        EventSystem.Instance.TractMissed();
        Destroy(gameObject);
    }
}
