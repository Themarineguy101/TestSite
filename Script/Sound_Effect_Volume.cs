using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Sound_Effect_Volume : MonoBehaviour
{
    public AudioMixer mixer;
    //public AudioClip audio;
    public Slider slider;

    void Start()
    {
    }
    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("SoundVol", Mathf.Log10(sliderValue) * 20);
        //AudioSource.PlayClipAtPoint(audio, this.gameObject.transform.position, 10f);
        PlayerPrefs.SetFloat("SoundVol", sliderValue);
    }
}

