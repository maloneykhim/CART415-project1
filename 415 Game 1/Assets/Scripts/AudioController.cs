using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{


  
    public AudioSource SFXSource;
    
    public AudioClip[] audioClipsPlayer;
    public AudioClip audioClipRival;


    public AudioSource musicSource;

    public AudioClip theme;

    public AudioClip button;

   
    
        public void Start(){

        musicSource.clip = theme;
        musicSource.volume = 0.1f;
        musicSource.Play();
    }

    public void PauseMusic(){

     if (musicSource.isPlaying)
    {
        musicSource.Pause();
    }
    else
    {
        musicSource.Play();
    }
        
    }


    public void PlayPlayerSFX()
    {

        // to ensure no overlapping of the audio
        if (!SFXSource.isPlaying){
       // SFXSource.PlayOneShot(clip);

        SFXSource.clip = audioClipsPlayer[Random.Range(0, audioClipsPlayer.Length)];
        SFXSource.Play();

        }
    }

    public void PlayRivalSFX(){

      if (!SFXSource.isPlaying){
            SFXSource.clip = audioClipRival;
            SFXSource.Play();
      }
        
    }


    public void StopSFX(){
        SFXSource.Pause();
    }

   public void ButtonSFX(){
        SFXSource.clip = button;
        SFXSource.Play();
   }



}
