using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public int Score = 0;

    /// <summary>
    /// ハイスコア
    /// </summary>
    public int HighScore = 0;
    
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

    // シーンがロードされたときに呼び出されるメソッドを追加
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 新しいシーンで必要なUI要素を探す
        _scoreText = GameObject.Find("Score").GetComponent<Text>();
        _highScoreText = GameObject.Find("HighScore").GetComponent<Text>();
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
