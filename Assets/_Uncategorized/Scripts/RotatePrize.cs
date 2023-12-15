using UnityEngine;

public class RotatePrize : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 30f;

    void Update()
    {
        // Y軸中心で回転する
        transform.Rotate(0f, -1* rotationSpeed * Time.deltaTime, 0f);
    }
}