using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using UnityEngine;

public class SwitchBlackLight : MonoBehaviour, IInteractable
{
    public GameObject lights;
    public AudioClip audioClip;

    public void Interact()
    {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.Play();
        Destroy(audioSource, audioClip.length);
        lights.SetActive(!lights.activeSelf);
    }
}
