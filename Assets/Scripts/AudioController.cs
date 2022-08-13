using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    public static AudioController instance;
    private void Awake()
    {
        instance = this;
    }

    public AudioSource levelMusic, mainMenuMusic, doorUnlockSound, doorOpenSound, doorCloseSound, doorClosedSound;

    public void PlayLevelMusic()
    {
        levelMusic.Stop();
        levelMusic.Play();
    }

    public void PlayMainMenuMusic()
    {
        mainMenuMusic.Stop();
        mainMenuMusic.Play();
    }

    public void PlayDoorUnlockSound()
    {
        doorUnlockSound.Stop();
        doorUnlockSound.Play();
    }

    public void PlayDoorOpenSound()
    {
        doorOpenSound.Stop();
        doorOpenSound.Play();
    }

    public void PlayDoorCloseSound()
    {
        doorCloseSound.Stop();
        doorCloseSound.Play();
    }

    public void PlayDoorClosedSound()
    {
        doorClosedSound.Stop();
        doorClosedSound.Play();
    }
}
