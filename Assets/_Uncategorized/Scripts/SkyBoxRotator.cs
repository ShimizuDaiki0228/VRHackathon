using UnityEngine;

public class SkyboxRotator : MonoBehaviour
{
    // SkyboxのMaterial
    [SerializeField] Material skyboxMaterial;

    // 回転の速度（度/秒）
    [SerializeField] [Range(0.01f, 0.1f)] float rotationSpeed = 10f;

    float rotationRepeatValue;

    void Update()
    {
        // nullチェック
        if (skyboxMaterial == null)
        {
            Debug.LogError("SkyboxMaterial is not assigned!");
            return;
        }

        rotationRepeatValue = Mathf.Repeat(skyboxMaterial.GetFloat("_Rotation") + rotationSpeed, 360f);

        skyboxMaterial.SetFloat("_Rotation", rotationRepeatValue);
    }
}