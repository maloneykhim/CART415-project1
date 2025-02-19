using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameController : MonoBehaviour
{


    float currentProgress = 0;
    float maxProgress = 20;
    [SerializeField] Image progressBar;
    float decrement = 0.0005f;
    float increment = 0.002f;

    // not paused
    public bool timeIsRunning = true;
    [SerializeField] float timeRemaining;
    [SerializeField] TMP_Text timeText;



    void Start()
    {
        timeIsRunning = true;
    }
    

    void Update(){

        // Check if the mouse is over a UI element
         if (EventSystem.current.IsPointerOverGameObject())
        {
            // If it is, don't perform the gameplay action
            return;
        }

        if(Input.GetMouseButton(0))
        {

            currentProgress += increment;
            
           

            
        } else {

            currentProgress -= decrement;
           
        }

        // **Clamp progress between 0 and maxProgress**
        currentProgress = Mathf.Clamp(currentProgress, 0, maxProgress);
        UpdateProgressAmount();

       // Debug.Log($"Current Progress: {currentProgress}");

        // Game is not paused
        if(timeIsRunning)
        {



            if(timeRemaining >= 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
             } 
             //else if 
            // {

            //     // GameOver();
            //     timeText.color = Color.red;
            // }
        }
       
    }

    public void DisplayTime (float timeToDisplay)
    {
        timeToDisplay++;
        float minutes = Mathf.FloorToInt (timeToDisplay / 60);
        float seconds = Mathf.FloorToInt (timeToDisplay % 60);
        timeText.text = string.Format ("{0:00}:{1:00}", minutes, seconds);
    }

    
    // this needs more tuning there is something wrong
    public void UpdateProgressAmount (){

        // if (currentProgress >= 0 && currentProgress <= maxProgress)
        // {
            
            progressBar.fillAmount = currentProgress / maxProgress;
      //  }

        if (currentProgress == maxProgress) {
         
          // Debug.Log($"you win!");
             SceneManager.LoadScene("Win01");
           // win condition
        }

        if (currentProgress == 0)
        {
           // Debug.Log($"you lose!");
            // lose condition
        }
    }





}
