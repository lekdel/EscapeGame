using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    public Transform zombie;
    public Animator animator;
    public Rigidbody rb;
    private Vector3 moveDirection = new Vector3(-1, 0, 0);
    private bool isAgonizing = false;
    private bool endAgonizing = false;
    public AudioSource scream;
    public AudioSource breath;

    void Start()
    {
        rb.velocity = moveDirection.normalized * 0.2f;
        animator.SetTrigger("walk");
        scream.Stop();
        breath.Play();
    }

    void Update()
    {
        if (isAgonizing)
        {
            return;
        }

        if (zombie.position.x < 1.5f)
        {
            ChangeDirection(new Vector3(1, 0, 0), 90);
            endAgonizing = false;
        }
        else if (zombie.position.x > 5.5f)
        {
            ChangeDirection(new Vector3(-1, 0, 0), 270);
        }
        if (Mathf.Abs(zombie.position.x - 3f) < 0.1f && !endAgonizing && moveDirection.x < 0)
        {
            StartAgonizing();
        }
    }

    private void ChangeDirection(Vector3 newDirection, float targetYRotation)
    {
        rb.velocity = Vector3.zero;
        Quaternion targetRotation = Quaternion.Euler(0, targetYRotation, 0);
        zombie.rotation = Quaternion.Slerp(zombie.rotation, targetRotation, Time.deltaTime * 5f);

        if (Quaternion.Angle(zombie.rotation, targetRotation) < 1f)
        {
            zombie.rotation = targetRotation;
            moveDirection = newDirection;
            rb.velocity = moveDirection.normalized * 0.2f;
            animator.SetTrigger("walk");
        }
    }

    private void StartAgonizing()
    {
        rb.velocity = Vector3.zero;
        animator.ResetTrigger("walk");
        animator.SetTrigger("agonize");
        isAgonizing = true;
        breath.Stop();
        scream.Play();
    }

    public void OnAgonizingAnimationEnd()
    {
        isAgonizing = false;
        endAgonizing = true;
        rb.velocity = moveDirection.normalized * 0.2f;
        animator.ResetTrigger("agonize");
        animator.SetTrigger("walk");
        scream.Stop();
        breath.Play();
    }
}
