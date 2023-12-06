using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameController : MonoBehaviour
{
    /// <summary>
    /// 発射する玉のPrefab
    /// </summary>
    [SerializeField]
    private GameObject _ballPrefab;

    /// <summary>
    /// 発射する玉
    /// Prefabをインスタンス化したものを割り当てて使用
    /// </summary>
    private GameObject _ball;

    /// <summary>
    /// 発射する玉のRigidbody
    /// </summary>
    private Rigidbody _ballRigidbody;

    /// <summary>
    /// 弾を押し出すキューブ
    /// </summary>
    [SerializeField]
    private GameObject _pushCube;

    /// <summary>
    /// _pushCubeのTransformを保持する
    /// </summary>
    private Transform _pushCubeCachedTransform;

    /// <summary>
    /// 弾を押し出すキューブがどれだけ下に下がるか
    /// </summary>
    private float _pushCubeOffsetY = 0;


    /// <summary>
    /// 弾を押し出す強さ
    /// </summary>
    private float _pushPower = 0;

    /// <summary>
    /// 弾が押し出されている状態か否か
    /// </summary>
    public bool IsPush;

    void Start()
    {
        _ball = Instantiate(_ballPrefab, _ballPrefab.transform.position, Quaternion.identity);
        _ballRigidbody = _ball.GetComponent<Rigidbody>();
        _pushCubeCachedTransform = _pushCube.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPushCubePosition = _pushCube.transform.position;

        if (Input.GetKey(KeyCode.Space) & _pushCubeOffsetY > -2)
        {
            _pushCubeOffsetY -= 0.01f;
            currentPushCubePosition.y -= 0.01f;

            _pushPower += 0.5f;
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            if (!IsPush)
            {
                IsPush = true;
                _ballRigidbody.AddForce(Vector3.up * _pushPower, ForceMode.Impulse);
            }

            StartCoroutine(PushCubeReturn());
            _pushPower = 0;
        }
        
        _pushCube.transform.position = currentPushCubePosition;

    }

    IEnumerator PushCubeReturn()
    {
        Vector3 currentPushCubePosition = _pushCube.transform.position;

        while (_pushCubeOffsetY <= 0)
        {
            _pushCubeOffsetY += 0.01f;
            currentPushCubePosition.y += 0.01f;
            _pushCube.transform.position = currentPushCubePosition;

            yield return null;
        }
    }
}
