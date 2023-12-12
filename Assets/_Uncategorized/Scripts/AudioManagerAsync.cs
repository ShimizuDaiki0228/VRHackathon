using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerAsync : MonoBehaviour
{
    public static AudioManagerAsync Instance;

    [SerializeField]
    private AudioSource[] _sfx;
    [SerializeField]
    private AudioSource[] _bgm;

    private int _currentSFXIndex;
    private int _currentBGMIndex;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySFX(int sfxIndex)
    {
        if (sfxIndex < _sfx.Length)
        {
            StopSFX();
            StartCoroutine(PlayOneShotAsync(_sfx[sfxIndex].clip));
            _currentSFXIndex = sfxIndex;
        }
    }

    private IEnumerator PlayOneShotAsync(AudioClip clip)
    {
        // AudioClipのロードなど、必要な非同期処理を実行
        // この例では非同期処理が不要なのでそのままPlayOneShotを使用
        _sfx[_currentSFXIndex].PlayOneShot(clip);


        yield return null;
    }

    public void StopSFX()
    {
        _sfx[_currentSFXIndex].Stop();
    }

    public void PlayBGM(int bgmIndex)
    {
        _currentBGMIndex = bgmIndex;

        if (bgmIndex < _bgm.Length)
        {
            _bgm[bgmIndex].Play();
        }
    }

    public void StopBGM()
    {
        _bgm[_currentBGMIndex].Stop();
    }
}
