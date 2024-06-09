using System.Collections;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    public float intensity = 0.3f;
    public Light Light;

    public bool isFlickering = false;
    public float timeDelay;

    // D�marrage de la coroutine au d�but
    void Start()
    {
    }

    // Coroutine qui alterne l'intensit� de la lumi�re
    

    private void Update()
    {
        if(!isFlickering)
        {
            StartCoroutine(FlickerLight());
        }
    }
    IEnumerator FlickerLight()
    {
        isFlickering = true;
        this.gameObject.GetComponent<Light>().enabled = false;
        timeDelay = Random.Range(0.01f, 0.2f);
        yield return new WaitForSeconds(timeDelay);
        this.gameObject.GetComponent<Light>().enabled = true;
        timeDelay = Random.Range(0.01f, 0.2f);
        yield return new WaitForSeconds(timeDelay);
        isFlickering = false;
    }
}

