using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameController : MonoBehaviour
{
    /// <summary>
    /// ���˂���ʂ�Prefab
    /// </summary>
    [SerializeField]
    private GameObject _ballPrefab;

    /// <summary>
    /// ���˂����
    /// Prefab���C���X�^���X���������̂����蓖�ĂĎg�p
    /// </summary>
    private GameObject _ball;

    /// <summary>
    /// ���˂���ʂ�Rigidbody
    /// </summary>
    private Rigidbody _ballRigidbody;

    /// <summary>
    /// �e�������o���L���[�u
    /// </summary>
    [SerializeField]
    private GameObject _pushCube;

    /// <summary>
    /// _pushCube��Transform��ێ�����
    /// </summary>
    private Transform _pushCubeCachedTransform;

    /// <summary>
    /// �e�������o���L���[�u���ǂꂾ�����ɉ����邩
    /// </summary>
    private float _pushCubeOffsetY = 0;


    /// <summary>
    /// �e�������o������
    /// </summary>
    private float _pushPower = 0;

    /// <summary>
    /// �e�������o����Ă����Ԃ��ۂ�
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
