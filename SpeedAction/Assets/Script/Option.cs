using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Option : MonoBehaviour
{
    [SerializeField] private Slider bgmSilder = null;
    [SerializeField] private Slider effectSilder = null;

    private void Start()
    {
        bgmSilder.onValueChanged.AddListener(BGMSlider);
        effectSilder.onValueChanged.AddListener(EffectSlider);
    }

    public void Open()
    {
        bgmSilder.value = GameController.instance._audioBGMVolume;        
        effectSilder.value = GameController.instance._audioEffectVolume;
    }

    private void BGMSlider(float value)
    {
        AudioManager.instance.SetVolume(AudioKind.BGM, value);
    }
    
    private void EffectSlider(float value)
    {
        AudioManager.instance.SetVolume(AudioKind.EFFECT, value);
    }
}
