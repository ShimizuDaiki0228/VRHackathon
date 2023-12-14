using UnityEngine;

public class ButterflyWings : MonoBehaviour
{
    [SerializeField]
    private float rotationRange = 30f; // 回転の範囲
    [SerializeField]
    private float rotationSpeed = 45f; // 回転の速さ
    [SerializeField]
    private Vector3 rotationDirection = new Vector3(0f, 1f, 0f); // 回転の向き

    private void Update()
    {
        // Y軸回転を繰り返す
        float angle = rotationRange * Mathf.Sin(Time.time * rotationSpeed);
        transform.localRotation = Quaternion.Euler(rotationDirection * angle);
    }
}
