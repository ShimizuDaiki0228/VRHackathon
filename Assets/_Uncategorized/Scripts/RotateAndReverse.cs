using System.Collections;
using UnityEngine;

public class RotateAndReverse : MonoBehaviour
{
    [SerializeField] AudioSource audio;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || OVRInput.GetDown(OVRInput.Button.Two)) {
            RotateAndReturn();
        }
    }

    public void RotateAndReturn()
    {
        // コルーチンを開始
        audio.Play();
        StartCoroutine(RotateCoroutine());
    }

    private IEnumerator RotateCoroutine()
    {
        // 回転の速さや角度は必要に応じて調整
        float rotationSpeed = 20f; // 1秒間に180度回転
        float maxRotation = 105f;   // 最大回転角度
        float returnRotation = 90f; // 戻る角度

        float currentRotation = transform.rotation.eulerAngles.z;
        float targetRotation = currentRotation + maxRotation;

        // 大きく回転
        while (currentRotation < targetRotation)
        {
            currentRotation += rotationSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0f, 0f, currentRotation);
            yield return null;
        }

        yield return new WaitForSeconds(.1f);

        // 少し過ぎてから戻す（わずかな遊びを設ける）
        float overshootRotation = currentRotation - returnRotation;
        while (overshootRotation < 0f)
        {
            currentRotation += rotationSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0f, 0f, currentRotation);
            overshootRotation = currentRotation - returnRotation;
            yield return null;
        }

        // 最終的に-90度まで戻す
        transform.rotation = Quaternion.Euler(0f, 0f, returnRotation);
    }
}
