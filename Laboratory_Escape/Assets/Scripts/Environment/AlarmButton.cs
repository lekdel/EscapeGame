using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmButton : MonoBehaviour, IInteractable
{
    public GameObject alarm;
    public AudioClip audioClip;
    public Light lighting;
    public void Interact()
    {
        alarm.SetActive(false);
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.Play();
        Destroy(audioSource, audioClip.length);
        lighting.intensity = 1;
    }
}
