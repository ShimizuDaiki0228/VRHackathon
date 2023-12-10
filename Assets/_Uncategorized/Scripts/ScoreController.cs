using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �V���O���g���p�^�[��
/// </summary>
public class ScoreController : MonoBehaviour
{
    public static ScoreController Instance;

    /// <summary>
    /// �X�R�A
    /// </summary>
    public int Score;

    /// <summary>
    /// �n�C�X�R�A
    /// </summary>
    public int HighScore;
    
    /// <summary>
    /// �X�R�A��UI
    /// </summary>
    [SerializeField]
    private Text _scoreText;

    /// <summary>
    /// �n�C�X�R�A��UI
    /// </summary>
    [SerializeField]
    private Text _highScoreText;

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

    private void Start()
    {
        HighScore = 0;
        Reset();
    }

    private void Reset()
    {
        Score = 0;
    }

    private void Update()
    {
        _scoreText.text = Score.ToString();
        _highScoreText.text = HighScore.ToString();


    }
}
