
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DisplayPrize : MonoBehaviour
{
    public GameObject firstPrize, secondPrize, thirdPrize, fourthPrize, fifthPrize;
    public Transform transform;
    private Text prizeText, nextPrizeText, prizeDetailText;
    private float rotationSpeed = 30f;


    // Start is called before the first frame update
    void Start()
    {
        GameObject prize;
        prizeText = GameObject.Find("Prize").GetComponent<Text>();
        nextPrizeText = GameObject.Find("NextPrize").GetComponent<Text>();
        prizeDetailText = GameObject.Find("PrizeDetail").GetComponent<Text>();


        switch (ScoreController.Instance.Score) {
            case var n when n >= 3000:
                prize = firstPrize;
                prizeText.text = "1等賞 / 1st Prize";
                nextPrizeText.text = "最高の景品を獲得! / You Won Ultimate Prize!";
                prizeDetailText.text = "携帯ゲーム機 / Handheld Game Console";
                break;
            case var n when n >= 2000:
                prize = secondPrize;
                prizeText.text = "2等賞 / 2nd Prize";
                nextPrizeText.text = "次の景品まで " +  (3000 - n) + "pt to get Next Grade Prize";
                prizeDetailText.text = "おもちゃの銃 / Toy Gun";
                break;
            case var n when n >= 1000:
                prize = thirdPrize;
                prizeText.text = "3等賞 / 3rd Prize";
                nextPrizeText.text = "次の景品まで " + (2000 - n) + "pt to get Next Grade Prize";
                prizeDetailText.text = "おもちゃの車 / Toy Car";
                break;
            case var n when n >= 500:
                prize = fourthPrize;
                prizeText.text = "参加賞 / 4th Prize";
                nextPrizeText.text = "次の景品まで " + (1000 - n) + "pt to get Next Grade Prize";
                prizeDetailText.text = "ピコピコハンマー / Toy Hammer";
                break;
            case var n when n >= 0:
                prize = fifthPrize;
                prizeText.text = "残念賞 / 5th Prize";
                nextPrizeText.text = "次の景品まで " + (500 - n) + "pt to get Next Grade Prize";
                prizeDetailText.text = "ラバーダック / Rubber Duck";
                break;
            default:
                prize = fifthPrize;
                break;
        }

        GameObject obj = Instantiate(prize, transform);

    }

}
