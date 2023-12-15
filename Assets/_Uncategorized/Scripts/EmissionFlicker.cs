using UnityEngine;

public class EmissionFlicker : MonoBehaviour
{
    public float flickerSpeed = 1f;  // 点滅の速さ
    public float minEmission = 0.5f;  // 最小 Emission
    public float maxEmission = 1f;   // 最大 Emission

    private Renderer _renderer;
    private Material _material;
    private float _startTime;

    void Start()
    {
        _renderer = GetComponent<Renderer>();

        if (_renderer != null)
        {
            _material = _renderer.material;
            _startTime = Time.time;
        }
        else
        {
            Debug.LogError("Renderer component not found on the object.");
        }
    }

    void Update()
    {
        if (_renderer == null)
            return;

        // 点滅処理
        float emission = Mathf.PingPong((Time.time - _startTime) * flickerSpeed, maxEmission - minEmission) + minEmission;
        Color finalColor = _material.color * Mathf.LinearToGammaSpace(emission);

        // Emission の更新
        _material.SetColor("_EmissionColor", finalColor);

        // Standard Shader の場合、Emission を更新するときに Material を再設定する
        if (_material.shader.name.Contains("Standard"))
        {
            _renderer.material = _material;
        }
    }
}
