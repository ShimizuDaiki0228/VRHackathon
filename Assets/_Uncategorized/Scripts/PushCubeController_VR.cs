using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushCubeController_VR : MonoBehaviour
{
    [SerializeField]
    private InGameController_VR inGameController_VR;

    private void OnCollisionStay(Collision collision)
    {
        if (!inGameController_VR.ReadyBallList.Contains(collision.gameObject))
            inGameController_VR.ReadyBallList.Add(collision.gameObject);
    }
}
