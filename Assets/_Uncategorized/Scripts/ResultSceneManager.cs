using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultSceneManager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;

    [SerializeField]
    private Text _highScoreText;

    private void Start()
    {
        _scoreText.text = "Score : " + ScoreController.Instance.Score;
        _highScoreText.text = "HighScore : " + ScoreController.Instance.HighScore;
    }
}
