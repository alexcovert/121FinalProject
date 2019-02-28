using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    public bool Collected { get; private set; }

    private void Awake()
    {
        Collected = false;
    }

    public void Collect()
    {
        Collected = true;

        //Turn off lights
        Light[] lights = GetComponentsInChildren<Light>();

        foreach (Light light in lights)
        {
            light.gameObject.SetActive(false);
        }

        //Turn off emission materiasl
        MeshRenderer[] mrs = GetComponentsInChildren<MeshRenderer>();
        List<Material> mats = new List<Material>();
        foreach (MeshRenderer mr in mrs)
        {
            mr.GetMaterials(mats);
            foreach(Material mat in mats)
            {
                mat.SetColor("_EmissionColor", new Color(0, 0, 0, 1));
            }
        }
    }
}
