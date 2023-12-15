using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyBallListResetter : MonoBehaviour
{
    [SerializeField] InGameController_VR inGameController_VR;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Sphere")
        {
                inGameController_VR.ReadyBallList.Clear();
        }
    }
}
