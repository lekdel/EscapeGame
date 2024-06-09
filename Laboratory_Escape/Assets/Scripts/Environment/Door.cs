using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public AudioClip audioClip;
    public AudioClip unlocking;
    public AudioClip open;
    public Animator myDoor;
    public bool closeTrigger = false;
    public bool openTrigger = true;
    public string doorOpening = "DoorOpening";
    public string doorClosing = "DoorClosing";
    public bool locked = true;
    public GameObject alarm;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.volume = 1f;
        audioSource.spatialBlend = 1;
    }
    private void Update()
    {
        string animatorName = myDoor.runtimeAnimatorController.name;
        if (animatorName == "Door1" && !alarm.activeSelf && locked)
        {
            audioSource.clip = unlocking;
            audioSource.Play();
            locked = false;
        }
    }

    public void Interact()
    {
        string animatorName = myDoor.runtimeAnimatorController.name;
        if (animatorName == "Door1" && !alarm.activeSelf)
        {
            if (openTrigger)
            {
                myDoor.Play(doorOpening, 0, 0.0f);
                Debug.Log("Opening");
                closeTrigger = true;
                openTrigger = false;
                audioSource.volume = 0.3f;
                audioSource.clip = open;
            }
            else if (closeTrigger)
            {
                myDoor.Play(doorClosing, 0, 0.0f);
                Debug.Log("Closing");
                openTrigger = true;
                closeTrigger = false;
            }
            audioSource.Play();
        }
        else
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = audioClip;
            audioSource.Play();
            Destroy(audioSource, audioClip.length);
        }
    }
}
