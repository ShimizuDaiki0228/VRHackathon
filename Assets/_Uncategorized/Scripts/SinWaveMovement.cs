using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinWaveMovement : MonoBehaviour
{
    [SerializeField]
    private float period = 2f;      // 三角関数の周期
    [SerializeField]
    private float amplitude = 1f;   // 振幅
    [SerializeField]
    private float phase = 0f;       // 変位角
    [SerializeField]
    private float speed = 1f;       // 移動速度

    private Vector3 initialPosition; // 初期位置

    private void Start()
    {
        // 初期位置を保存
        initialPosition = transform.position;
    }

    private void Update()
    {
        // 時間に依存した三角関数の値を取得
        float time = Time.time * speed;
        float yPosition = Mathf.Sin((time + phase) * (2 * Mathf.PI) / period) * amplitude;

        // 初期位置にオフセットを加えて現在の座標を更新
        transform.position = new Vector3(initialPosition.x, initialPosition.y + yPosition, initialPosition.z);
    }
}