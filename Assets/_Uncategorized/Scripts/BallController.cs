using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallController : MonoBehaviour
{
    /// <summary>
    /// ポケットに入って点が入るまでの時間
    /// </summary>
    private const int GET_POINT_TIME = 2;

    private float _inPocketTime = 0;


    /// <summary>
    /// ポケットに入った時の処理
    /// ポケットオブジェクトのタグを"Pocket"にしてください。（新しく作成して）
    /// ポケットオブジェクトにPocketControllerをアタッチしてインスペクター上からそのポケットで何点入るようにするか設定
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Pocket")
        {
            _inPocketTime += Time.deltaTime;

            if(_inPocketTime > GET_POINT_TIME)
            {
                Destroy(this.gameObject);
                ScoreController.Instance.Score += collision.gameObject.GetComponent<PocketController>().PocketScoreValue;
            }
        }
    }


    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Pocket")
        {
            _inPocketTime = 0;
        }
    }
}
