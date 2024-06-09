using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementVisible : MonoBehaviour
{
    public Light light;
    public GameObject elements;
    private void Start()
    {
        elements.SetActive(false);
    }
    private void Update()
    { 
        Debug.Log("PASSS");
        if (light.intensity > 0)
        { 
            elements.SetActive(true);
        } else
        {
            elements.SetActive(false);
        }
    }
}
