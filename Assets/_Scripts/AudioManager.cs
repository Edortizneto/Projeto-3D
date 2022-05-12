using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    public AudioSource sfxSource = default;
    [SerializeField]
    public AudioSource ambienceSource = default;
    [SerializeField]
    public AudioClip music = default;
    private static AudioManager _instance;

    public static AudioManager GetInstance(){
       if(_instance == null){
           _instance = new AudioManager();
       }
       return _instance;
    }

    void Awake(){
       _instance = this;
       if (music) {
           ambienceSource.loop = true;
           ambienceSource.clip = music;
           ambienceSource.Play();
       }
   }

   public static void PlaySFX(AudioClip audioClip){
       _instance.sfxSource.PlayOneShot(audioClip);
   }

   public static void SetAmbience(AudioClip audioClip){
       _instance.ambienceSource.Stop();
       _instance.ambienceSource.clip = audioClip;
       _instance.ambienceSource.Play();
   }
}
