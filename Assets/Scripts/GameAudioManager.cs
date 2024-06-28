using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudioManager : Singleton<GameAudioManager>
{
    [SerializeField] AudioData audioData;
    [SerializeField] EventData buttonSoundEvent;
    [SerializeField] AudioSource audioSource;


    private void OnEnable()
    {
        buttonSoundEvent.action += PlayButtonSound;
    }

    private void PlayButtonSound()
    {
        if (!SettingsPanel.soundFlag)
            return;
        audioSource.clip = audioData.audioDataList[0];
        audioSource.Play();
    }
}
