using System.Collections;
using UnityEngine;

public class AlarmLight : MonoBehaviour
{
    public float intensity = 4f;
    public float timing = 0.5f;
    public Light Light;

    // D�marrage de la coroutine au d�but
    void Start()
    {
        StartCoroutine(ChangeLightIntensity());
    }

    // Coroutine qui alterne l'intensit� de la lumi�re
    IEnumerator ChangeLightIntensity()
    {
        while (true)
        {
            Light.intensity = Light.intensity == intensity ? 0f : intensity;

            yield return new WaitForSeconds(timing); 
        }
    }
}
