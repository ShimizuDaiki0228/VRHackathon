using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public enum SFX
{
    Point,
    Wall,
    Nail,
    DestroyWithoutPoint,
    LuckyPocket,
}

public enum BGM
{

}


public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

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

    /// <summary>
    /// SFX��炷
    /// </summary>
    /// <param name="sfxIndex"></param>
    public void PlaySFX(int sfxIndex)
    {
        if (sfxIndex < _sfx.Length)
        {
            StopSFX();
            _sfx[sfxIndex].PlayOneShot(_sfx[sfxIndex].clip);
            _currentSFXIndex = sfxIndex;
        }
    }

    /// <summary>
    /// SFX���~�߂�
    /// </summary>
    public void StopSFX()
    {
        _sfx[_currentSFXIndex].Stop();
    }

    /// <summary>
    /// BGM�𗬂�
    /// </summary>
    /// <param name="bgmIndex"></param>
    public void PlayBGM(int bgmIndex)
    {
        _currentBGMIndex = bgmIndex;

        if (bgmIndex < _bgm.Length)
        {
            _bgm[bgmIndex].Play();
        }
    }

    /// <summary>
    /// BGM�������Ɏ~�߂�
    /// </summary>
    public void StopBGM()
    {
        _bgm[_currentBGMIndex].Stop();
    }
}
