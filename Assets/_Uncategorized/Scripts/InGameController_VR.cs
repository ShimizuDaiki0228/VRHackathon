using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameController_VR : MonoBehaviour
{
    [SerializeField] private GameObject _ballPrefab;
    [HideInInspector] public GameObject _ball;
    private Rigidbody _ballRigidbody;


    [SerializeField] private GameObject _pushCube;
    private Transform _pushCubeCachedTransform;
    private float _pushCubeOffsetY = 0;
    private float _pushPower = 0;
    public bool IsPush;

    [SerializeField] OVRInput.Controller controllerType;

    void Awake()
    {
        _ball = Instantiate(_ballPrefab, _ballPrefab.transform.position, Quaternion.identity);
        _ballRigidbody = _ball.GetComponent<Rigidbody>();
        _pushCubeCachedTransform = _pushCube.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPushCubePosition = _pushCube.transform.position;

#if UNITY_EDITOR

        //スペースキーを押した時（デバッグ用）
        if (Input.GetKey(KeyCode.Space) & _pushCubeOffsetY > -2)
        {
            _pushCubeOffsetY -= 0.01f;
            currentPushCubePosition.y -= 0.01f;

            _pushPower += 0.5f;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (!IsPush)
            {
                IsPush = true;
                _ballRigidbody.AddForce(Vector3.up * _pushPower, ForceMode.Impulse);
            }

            StartCoroutine(PushCubeReturn());
            _pushPower = 0;
        }

#else
        float triggerStrength = OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger);

        //トリガーでボールを発射する
        //if (triggerStrength >= 0.1f & _pushCubeOffsetY > -2)
        //トリガーではなくAボタンでボールを発射する
        if (OVRInput.Get(OVRInput.Button.One) & _pushCubeOffsetY > -2)
        {
            _pushCubeOffsetY -= 0.01f;
            currentPushCubePosition.y -= 0.01f;

            OVRInput.SetControllerVibration(0.7f, _pushCubeOffsetY* -0.5f, controllerType);

            _pushPower += 0.5f;
        }


        //if (triggerStrength < 0.1f)
        if (OVRInput.GetUp(OVRInput.Button.One))
        {
            if (!IsPush)
            {
                IsPush = true;
                _ballRigidbody.AddForce(Vector3.up * _pushPower, ForceMode.Impulse);
            }

            StartCoroutine(PushCubeReturn());

            OVRInput.SetControllerVibration(0, 0, controllerType);

            _pushPower = 0;
        }

        //下記はペンディング。トリガーがアナログ入力であるため0と1の値を正確に取得しない場合がある模様

        ////コントローラのトリガーを引いた時
        //if (triggerStrength > 0& _pushCubeOffsetY > -2)
        //{
        //    //中途半端に押すと下がり続ける。なんで？
        //    _pushCubeOffsetY = triggerStrength * -2f;
        //    currentPushCubePosition.y = _pushCubeCachedTransform.position.y +triggerStrength * -2f;

        //    OVRInput.SetControllerVibration(0.7f, triggerStrength, controllerType);

        //    _pushPower = triggerStrength * 100f;
        //}

        ////コントローラのトリガーを離した時
        //if (triggerStrength == 0 & _pushPower > 0)
        //{
        //    if (!IsPush)
        //    {
        //        IsPush = true;
        //        _ballRigidbody.AddForce(Vector3.up * _pushPower, ForceMode.Impulse);
        //    }

        //    StartCoroutine(PushCubeReturn_VR());

        //    OVRInput.SetControllerVibration(0, 0, controllerType);

        //    _pushPower = 0;
        //}
#endif

        _pushCube.transform.position = currentPushCubePosition;

    }

    IEnumerator PushCubeReturn()
    {
        Vector3 currentPushCubePosition = _pushCube.transform.position;

        while (_pushCubeOffsetY <= 0)
        {
            _pushCubeOffsetY += 0.2f;
            currentPushCubePosition.y += 0.2f;
            _pushCube.transform.position = currentPushCubePosition;

            yield return null;
        }
    }

    IEnumerator PushCubeReturn_VR()
    {
        Vector3 currentPushCubePosition = _pushCube.transform.position;

        while (_pushCubeOffsetY <= 0)
        {
            _pushCubeOffsetY += 0.2f;
            currentPushCubePosition.y += 0.2f;
            _pushCube.transform.position = currentPushCubePosition;

            yield return null;
        }
    }
}
