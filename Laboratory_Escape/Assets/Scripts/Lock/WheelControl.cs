using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WheelControl : MonoBehaviour, IInteractable
{
    public AudioClip audioClip;
    public GameObject wheel;
    public int wheelNumber;
    private float wheelAngle;
    private LockControl lockControl;

    private void Start()
    {
        wheelAngle = wheel.transform.localRotation.y;
        lockControl = GameObject.FindObjectOfType<LockControl>();
    }

    public void Interact()
    {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.volume = 0.1f;
        audioSource.pitch = 2f;
        audioSource.clip = audioClip;
        audioSource.Play();
        Destroy(audioSource, audioClip.length);

        Quaternion newRotation = wheel.transform.localRotation * Quaternion.Euler(0, 0, 36);
        wheel.transform.localRotation = newRotation;
        wheelAngle = wheel.transform.localRotation.y;
        lockControl.UpdateLock(Mathf.RoundToInt(wheel.transform.localEulerAngles.y) % 360, wheelNumber);
    }
}
