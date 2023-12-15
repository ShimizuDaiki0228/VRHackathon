using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallController : MonoBehaviour
{
    /// <summary>
    /// �|�P�b�g�ɓ����ē_������܂ł̎���
    /// </summary>
    private const int GET_POINT_TIME = 2;

    private float _inPocketTime = 0;


    /// <summary>
    /// �|�P�b�g�ɓ��������̏���
    /// �|�P�b�g�I�u�W�F�N�g�̃^�O��"Pocket"�ɂ��Ă��������B�i�V�����쐬���āj
    /// �|�P�b�g�I�u�W�F�N�g��PocketController���A�^�b�`���ăC���X�y�N�^�[�ォ�炻�̃|�P�b�g�ŉ��_����悤�ɂ��邩�ݒ�
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
                
                if(ScoreController.Instance.Score > ScoreController.Instance.HighScore)
                    ScoreController.Instance.HighScore = ScoreController.Instance.Score;
                
                if(collision.gameObject.GetComponent<PocketController>().IsLuckyPocket)
                {
                    InGameController_VR.Instance.AddBall();
                }


                InGameController_VR.Instance.ExistBallList.Remove(this.gameObject);

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
    /// �ǂɓ��������Ƃ��ƓB�ɓ��������Ƃ��ɉ����o��
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

        if(collision.gameObject.tag == "DestroyBall")
        {
            AudioManager.Instance.PlaySFX((int)SFX.DestroyWithoutPoint);
            Destroy(this.gameObject);
            InGameController_VR.Instance.ExistBallList.Remove(this.gameObject);
        }
    }
}
