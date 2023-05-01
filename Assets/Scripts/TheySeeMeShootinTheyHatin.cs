using System.Collections;
using UnityEngine;

public class TheySeeMeShootinTheyHatin : MonoBehaviour
{
    public GameObject projectile;
    public float launchVelocity;
    public float waitTimeBetweenShots;
    public Transform originTransform;

    private void Awake()
    {
        StartCoroutine(nameof(JeTue));
    }

    // Update is called once per frame
    IEnumerator JeTue()
    {
        while (true)
        {
            GameObject projectileGameObject = Instantiate(projectile);
            projectileGameObject.transform.position = originTransform.position;
            projectileGameObject.GetComponent<Rigidbody>().velocity = transform.forward * launchVelocity;

            Destroy(projectileGameObject, 2f);

            yield return new WaitForSeconds(waitTimeBetweenShots);
        }
    }
}
