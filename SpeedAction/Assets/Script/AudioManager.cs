using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AudioKind { EFFECT, BGM }

public class AudioManager : MonoBehaviour
{
    private static AudioManager audioManager;
    public static AudioManager instance
    {
        get
        {
            if (audioManager == null)
                audioManager = FindObjectOfType<AudioManager>();
            return audioManager;
        }
    }

    [SerializeField] private AudioSource bgm;
    [SerializeField] private AudioSource effect;

    [SerializeField] private AudioClip hittedClip = null;
    [SerializeField] private AudioClip jumpClip = null;
    [SerializeField] private AudioClip itemCollectClip = null;
    [SerializeField] private AudioClip feverClip = null;

    void Start()
    {
        bgm.volume = GameController.instance._audioBGMVolume;
        effect.volume = GameController.instance._audioEffectVolume;
    }

    public void SetVolume(AudioKind kind, float value)
    {
        switch (kind)
        {
            case AudioKind.BGM:
                bgm.volume = value;
                GameController.instance.SetBGMVolume(value);
                break;

            case AudioKind.EFFECT:
                effect.volume = value;
                GameController.instance.SetEffectVolume(value);
                break;
        }
    }

    public void PlayHittedSound() { effect.PlayOneShot(hittedClip); }
    public void PlayJumpSound() { effect.PlayOneShot(jumpClip); }
    public void PlayItemCollectSound() { effect.PlayOneShot(itemCollectClip); }
    public void PlayFeverSound() { effect.PlayOneShot(feverClip); }
}
