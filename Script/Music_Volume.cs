using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Music_Volume : MonoBehaviour
{
    public AudioMixer mixer;
    //public AudioClip audio;
    public Slider slider;
    private float preference;

    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
    }
        public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
        //AudioSource.PlayClipAtPoint(audio, this.gameObject.transform.position, 10f);
        PlayerPrefs.SetFloat("MusicVolume", sliderValue);
    }
}

