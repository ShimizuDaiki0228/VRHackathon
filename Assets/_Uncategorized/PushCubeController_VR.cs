using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushCubeController_VR : MonoBehaviour
{
    [SerializeField]
    private InGameController_VR inGameController_VR;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Sphere")
        {
            inGameController_VR.IsPush = false;
        }
    }
}
