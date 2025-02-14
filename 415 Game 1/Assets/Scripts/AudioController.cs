using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{


    //[SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;



    public AudioClip[] audioClips;

    // Update is called once per frame
    // void Update()
    // {
        
    //     if(Input.GetMouseButton(0))
    //     {


    //     // audioData = GetComponent<AudioSource>();
    //     // audioData.Play(0);
    //     // Debug.Log("hammer");
            

            
    //     } 




    //}


    public void PlaySFX()
    {

        // to ensure no overlapping of the audio
        if (!SFXSource.isPlaying){
       // SFXSource.PlayOneShot(clip);

        SFXSource.clip = audioClips[Random.Range(0, audioClips.Length)];
        SFXSource.Play();

        }
    }
}
