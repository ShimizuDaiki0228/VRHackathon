using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition_forDebugPurpose : MonoBehaviour
{
    [SerializeField] int sceneNum;
    [SerializeField] AudioSource audioSource;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightShift) || OVRInput.GetDown(OVRInput.Button.Three)) {
            StartCoroutine(LoadGameScene());
        }
    }

    IEnumerator LoadGameScene()
    {
        audioSource.Play();
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(sceneNum);
    }
}
