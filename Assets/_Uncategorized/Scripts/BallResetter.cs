using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallResetter : MonoBehaviour
{
    [SerializeField]
    private InGameController_VR inGameController_VR;
    private Vector3 _ballCachedTransformPosition;
    private Rigidbody _ballRigidbody;

    void Start()
    {
        _ballRigidbody = inGameController_VR._ball.GetComponent<Rigidbody>();
        _ballCachedTransformPosition = inGameController_VR._ball.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Quest2コントローラBボタンまたは左シフトキーでボールの位置をリセット
        if (OVRInput.GetDown(OVRInput.Button.Two) || Input.GetKeyDown(KeyCode.LeftShift))
        {
            inGameController_VR._ball.transform.position = _ballCachedTransformPosition;
            _ballRigidbody.velocity = new Vector3(0, 0, 0);

        }
    }
}
