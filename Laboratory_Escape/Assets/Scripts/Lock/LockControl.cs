using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LockNumber
{
    Zero = 144,
    One = 180,
    Two = 216,
    Three = 252,
    Four = 288,
    Five = 324,
    Six = 0,
    Seven = 36,
    Eight = 72,
    Nine = 108,
}


public class LockControl : MonoBehaviour
{
    private List<LockNumber> lockCombination;
    public List<LockNumber> lockPassword;
    public AudioClip audioClip;
    AudioSource audioSource;
    public Animator deskDoor;
    public string doorOpening = "DeskDoor";
    private bool deskOpened = false;

    // Start is called before the first frame update
    void Start()
    {
        lockCombination = new List<LockNumber> { LockNumber.Three, LockNumber.One, LockNumber.Eight, LockNumber.Six };
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    public void UpdateLock(float rotation, int index)
    {
        lockCombination[index] = getLockNumber(rotation);
        if (ValidCombination(lockCombination, lockPassword) && !deskOpened)
        {
            audioSource.volume = 0.5f;
            audioSource.clip = audioClip;
            audioSource.Play();
            deskDoor.Play(doorOpening, 0, 0.0f);
            deskOpened = true;
        } 
    }

    private LockNumber getLockNumber(float rotation)
    {
        switch(rotation)
        {
            case 144f:
                return LockNumber.Zero;
            case 180f:
                return LockNumber.One;
            case 216f:
                return LockNumber.Two;
            case 252f:
                return LockNumber.Three;
            case 288f:
                return LockNumber.Four;
            case 324f:
                return LockNumber.Five;
            case 0f:
                return LockNumber.Six;
            case 36f:
                return LockNumber.Seven;
            case 72f:
                return LockNumber.Eight;
            case 108f:
                return LockNumber.Nine;
            default:
                return LockNumber.Zero;
        }
    }

    private bool ValidCombination(List<LockNumber> list1, List<LockNumber> list2)
    {
        if (list1.Count != list2.Count)
        {
            return false;
        }

        for (int i = 0; i < list1.Count; i++)
        {
            if (list1[i] != list2[i])
            {
                return false;
            }
        }

        return true;
    }
}
