using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushCubeController : MonoBehaviour
{
    [SerializeField]
    private InGameController inGameController;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Sphere")
        {
            inGameController.IsPush = false;
        }
    }
}
