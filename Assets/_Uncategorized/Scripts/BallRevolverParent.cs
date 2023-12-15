using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRevolverParent : MonoBehaviour
{
    Vector3 initial_position;
    // Update is called once per frame

    private void Start()
    {
        initial_position = this.gameObject.transform.position;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || OVRInput.GetDown(OVRInput.Button.Two))
        {
            RotateAndReturn();
        }
    }

    public void RotateAndReturn()
    {
        StartCoroutine(MoveCoroutine());
    }

    private IEnumerator MoveCoroutine()
    {
        float time = 0;

        // 大きく回転
        while (time < 2.5f)
        {
            time += Time.deltaTime;
            transform.Translate(0f, 0.05f * Mathf.Sin(360*(time/5f)),0f);
            yield return null;
        }

        transform.position = initial_position;

        time = 0;
    }
}
