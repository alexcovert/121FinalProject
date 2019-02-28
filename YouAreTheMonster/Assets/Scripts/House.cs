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
    }
}
