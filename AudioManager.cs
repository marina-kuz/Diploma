using UnityEngine;
using UnityEngine.UI;
public class AudioManager : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string AudioPref = "AudioPref";
    private int firstPlay;
    public Slider slider;
    private float _audio;
    public AudioSource audioEffect;
    void Start()
    {
        firstPlay=PlayerPrefs.GetInt(FirstPlay);
        if(firstPlay==0)
        {
            _audio= .125f;
            slider.value=_audio;
            PlayerPrefs.SetFloat(AudioPref,_audio);
            PlayerPrefs.SetInt(FirstPlay,-1);
        }
        else
        {
            _audio=PlayerPrefs.GetFloat(AudioPref);
            slider.value=_audio;
        }
    }
    public void SaveSound()
    {
        PlayerPrefs.SetFloat(AudioPref,slider.value);
    }
    void OnApllicationFocus(bool inFocus)
    {
        if(!inFocus)
        {
            SaveSound();
        }
    }
    public void UpdateSound()
    {
        audioEffect.volume=slider.value;
    }
}
