using UnityEngine;

public class CrossRotater : MonoBehaviour
{
    // 1秒間に回転させる度数
    [SerializeField]
    private float rotationSpeed = -20f;

    void Update()
    {
        // 1秒間に指定の度数だけZ軸回転させる
        float rotationAmount = rotationSpeed * Time.deltaTime;
        this.gameObject.transform.Rotate(0f, 0f, rotationAmount);
    }
}
