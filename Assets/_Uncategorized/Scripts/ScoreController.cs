using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// シングルトンパターン
/// </summary>
public class ScoreController : MonoBehaviour
{
    public static ScoreController Instance;

    /// <summary>
    /// スコア
    /// </summary>
    public int Score;

    /// <summary>
    /// ハイスコア
    /// </summary>
    public int HighScore;
    
    /// <summary>
    /// スコアのUI
    /// </summary>
    [SerializeField]
    private Text _scoreText;

    /// <summary>
    /// ハイスコアのUI
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
