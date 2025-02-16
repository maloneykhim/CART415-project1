using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharaController : MonoBehaviour
{
    Animator animator;
    AudioController audioController;

    private float minWaitTime = 2f;  // Minimum wait time before triggering
    private float maxWaitTime = 10f; // Maximum wait time before triggering
    private float minDuration = 1f;  // Minimum animation duration
    private float maxDuration = 5f;  // Maximum animation duration

    private float nextTriggerTime;
    private bool isSabotaging = false;
    private bool isSculpting = false;
    private bool isCaught = false;

    private void Awake()
    {
        audioController = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioController>();
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        SetNextTriggerTime();
        StartCoroutine(CheckCaughtCondition());
    }

    void Update()
    {

        // Check if the mouse is over a UI element
              if (EventSystem.current.IsPointerOverGameObject())
        {
            // If it is, don't perform the gameplay action
            return;
        }

        if (Input.GetMouseButton(0))
        {
            isSabotaging = true;
            animator.SetBool("isSabotaging", true);
            audioController.PlayPlayerSFX();
        }
        else
        {
            isSabotaging = false;
            animator.SetBool("isSabotaging", false);
        }

        if (Time.time >= nextTriggerTime)
        {
            TriggerAnimation();
            SetNextTriggerTime();
        }
    }

    void TriggerAnimation()
    {
        isSculpting = true;
        animator.SetBool("isSculpting", true);
        audioController.PlayRivalSFX();
        Invoke(nameof(StopAnimation), Random.Range(minDuration, maxDuration));
    }

    void StopAnimation()
    {
        isSculpting = false;
        animator.SetBool("isSculpting", false);
        audioController.StopSFX();
    }

    void SetNextTriggerTime()
    {
        nextTriggerTime = Time.time + Random.Range(minWaitTime, maxWaitTime);
    }

    IEnumerator CheckCaughtCondition()
    {
        while (true)
        {
            if (isSabotaging && isSculpting && !isCaught)
            {
                Debug.Log("Caught!");
                isCaught = true;
                animator.SetBool("isCaught", true);
                // You can add additional logic here for when the character is caught
            }
            yield return null;
        }
    }
}