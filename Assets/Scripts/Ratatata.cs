using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ratatata : MonoBehaviour
{
    public GameObject tract;
    public float launchVelocity = 1f;
    public int maxProjectile = 20;
    public float fireDelta = 0.5f;

    private int projectileCount = 0;
    private float nextFire = 0.2f;
    private float frameTime = 0.0f;

    public Transform cameraTransform;
    public Transform gunCanon;

    public AudioClip loopGun;
    public AudioClip endGun;
    private AudioSource audioSource;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        gunCanon.Rotate(Vector3.up * 15);
        frameTime = frameTime + Time.deltaTime;

        if (Input.GetButton("Fire1") && frameTime > nextFire)
        {
            if (projectileCount < maxProjectile)
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.clip = loopGun;
                    audioSource.loop = true;
                    audioSource.Play();
                } else
                {
                    if (audioSource.clip.name == "AssaultCanon_3p_tail")
                    {
                        audioSource.Stop();
                        audioSource.clip = loopGun;
                        audioSource.loop = true;
                        audioSource.Play();
                    }
                }
                nextFire = frameTime + fireDelta;

                GameObject projectile = Instantiate(tract);
                projectile.transform.position = transform.position + cameraTransform.forward;
                projectile.GetComponent<Rigidbody>().velocity = cameraTransform.forward * launchVelocity;
                projectile.GetComponent<Projectile>().setSpawner(this);

                //Destroy(projectile, 0.5f);

                projectileCount += 1;
                nextFire = nextFire - frameTime;
                frameTime = 0.0f;
            }
        }

        if (Input.GetButtonUp("Fire1") && audioSource.isPlaying)
        {
            audioSource.Stop();
            audioSource.loop = false;
            audioSource.clip = endGun;
            audioSource.Play();
        }


    }

    public void decreaseProjectileCount()
    {
        projectileCount = Mathf.Max(projectileCount - 1, 0);
    }
}
