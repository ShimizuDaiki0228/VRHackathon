using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �V���O���g���p�^�[��
/// </summary>
public class ScoreController : MonoBehaviour
{
    public static ScoreController Instance;

    private int _score;
    private int _highScore;

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


}
