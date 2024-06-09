using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SheetLook : MonoBehaviour, IInteractable
{
    public AudioClip audioClip;
    public GameObject itemView;
    public GameObject laboSheet;
    public bool isViewMode = false;

    public void Interact()
    {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.Play();
        Destroy(audioSource, audioClip.length);
        itemView.SetActive(true);
        laboSheet.SetActive(true);
        isViewMode = false;
    }
}
