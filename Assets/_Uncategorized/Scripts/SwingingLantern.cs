using UnityEngine;

public class SwingingLantern : MonoBehaviour
{
    public float swingSpeed = 1f;  // 振り子の速度
    public float swingAmount = 30f;  // 振り子の振れ幅
    public float rotationCenterOffset = 20f;  // 回転の中心を上にずらすオフセット

    private float offset = 4f;

    private float rand = 0;

    void Start()
    {
        //rand = Random.value * 10;
    }

    void Update()
    {
        // オフセットを更新
        offset += Time.deltaTime * swingSpeed;

        // Y軸のオフセットを加えて、Z軸を回転させる
        float newY = Mathf.Sin(offset + rand) * swingAmount;

        // 回転の中心を上にずらすオフセットを加える
        Quaternion rotation = Quaternion.Euler(90f + newY, 0f, 0) * Quaternion.Euler(rotationCenterOffset, 0f, 0f);

        // 回転を適用
        transform.localRotation = rotation;
    }
}
