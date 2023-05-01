using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class ItsRainingTracts : MonoBehaviour
{
    public GameObject tract;
    public float delayBetweenSpawn;
    private void Awake()
    {
        StartCoroutine(nameof(ContinousSpawn));
    }

    IEnumerator ContinousSpawn()
    {
        var transformsSpawner = new List<Transform>(transform.GetComponentsInChildren<Transform>());
        var random = new Random();

        while (true)
        {
            GameObject tractGameObject = Instantiate(tract);

            var selectedTransform = transformsSpawner.OrderBy(_ => random.Next()).First();
            tractGameObject.transform.position = selectedTransform.position;

            Destroy(tractGameObject, 10f);

            yield return new WaitForSeconds(delayBetweenSpawn);
        }
    }
}
