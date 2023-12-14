using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public int Score = 0;

    /// <summary>
    /// �n�C�X�R�A
    /// </summary>
    public int HighScore = 0;
    
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

    // �V�[�������[�h���ꂽ�Ƃ��ɌĂяo����郁�\�b�h��ǉ�
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // �V�����V�[���ŕK�v��UI�v�f��T��
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
