using UnityEngine;

public class CitySceneRotater : MonoBehaviour
{
    // 1秒間に回転させる度数
    [SerializeField]
    private float rotationSpeed = -5f;

    void Update()
    {
        // 1秒間に指定の度数だけy軸回転させる
        float rotationAmount = rotationSpeed * Time.deltaTime;
        this.gameObject.transform.Rotate(0f, rotationAmount, 0f);
    }
}
