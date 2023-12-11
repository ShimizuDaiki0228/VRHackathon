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
    private void OnTriggerStay(Collider collision)
    {
        if(collision.gameObject.tag == "Pocket")
        {
            _inPocketTime += Time.deltaTime;

            if(_inPocketTime > GET_POINT_TIME)
            {
                AudioManager.Instance.PlaySFX((int)SFX.Point);
                Destroy(this.gameObject);
                ScoreController.Instance.Score += collision.gameObject.GetComponent<PocketController>().PocketScoreValue;
            }
        }
    }


    private void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.tag == "Pocket")
        {
            _inPocketTime = 0;
        }
    }

    /// <summary>
    /// 壁に当たったときと釘に当たったときに音を出す
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            AudioManager.Instance.PlaySFX((int)SFX.Wall);
        }

        if(collision.gameObject.tag == "Nail")
        {
            AudioManager.Instance.PlaySFX((int)SFX.Nail);
        }
    }
}
