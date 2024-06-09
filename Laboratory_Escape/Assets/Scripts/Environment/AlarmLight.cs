using System.Collections;
using UnityEngine;

public class AlarmLight : MonoBehaviour
{
    public float intensity = 4f;
    public float timing = 0.5f;
    public Light Light;

    // Démarrage de la coroutine au début
    void Start()
    {
        StartCoroutine(ChangeLightIntensity());
    }

    // Coroutine qui alterne l'intensité de la lumière
    IEnumerator ChangeLightIntensity()
    {
        while (true)
        {
            Light.intensity = Light.intensity == intensity ? 0f : intensity;

            yield return new WaitForSeconds(timing); 
        }
    }
}
