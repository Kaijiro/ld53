using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class ValerieDamidot : MonoBehaviour
{
    private Color[] availableColors =
    {
        new(0.325f, 0.604f, 1f),
        new(0.286f, 0.784f, 0.647f),
        new(0.953f, 0.553f, 0.357f),
        new(0.953f, 0.839f, 0.4f),
        new(0.286f, 0.729f, 0.812f),
        new(0.447f, 0.475f, 0.812f),
        new(0.725f, 0.341f, 0.459f),
        new(0.812f, 0.667f, 0.549f),
        new(0.698f, 0.643f, 0.616f)
    };


    private void Awake()
    {
        var bodyMaterial = transform.Find("Cube").GetComponent<MeshRenderer>();
        var doorMaterial = transform.Find("Cube.002").GetComponent<MeshRenderer>();
        var woodMaterial = transform.Find("Cube.003").GetComponent<MeshRenderer>();
        var roofMaterial = transform.Find("Cube.004").GetComponent<MeshRenderer>();

        var colorList = new List<Color>(availableColors);
        var random = new Random();

        var selectedColors = colorList.OrderBy(x => random.Next()).Take(3).ToList();

        bodyMaterial.material.color = selectedColors[0];
        doorMaterial.material.color = selectedColors[1];
        woodMaterial.material.color = selectedColors[2];
        roofMaterial.material.color = new Color(0.376f, 0.322f, 0.31f);
    }
}
