using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Settings : MonoBehaviour
{

    public Canvas canvas;
    AudioController audioController;

    public Image buttonImage;


    private Color musicEnabledColor; 
    private Color musicDisabledColor; 



    void Start()
    {
        ColorUtility.TryParseHtmlString("#FFFFFF", out musicEnabledColor); 
        ColorUtility.TryParseHtmlString("#989898", out musicDisabledColor); 
    }




    private void Awake()
    {
        audioController = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioController>();
    }



    public void PauseMusic(){

    audioController.PauseMusic();

    if (audioController.musicSource.isPlaying)
        {
            buttonImage.color = musicEnabledColor;
        
        }
        else
        {
        buttonImage.color = musicDisabledColor;

        }


    }

    public void PauseGame(){

                canvas.enabled = true;
                
                Time.timeScale=0;




    }


    public void ResumeGame(){

    canvas.enabled = false;

                Time.timeScale=1;
            

    }


    public void RetryGame(){

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        Time.timeScale=1;

    }


    public void HomePage(){

    SceneManager.LoadScene("HomePage");

    Time.timeScale=1;

    }

}
