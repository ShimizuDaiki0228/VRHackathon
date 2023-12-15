using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class InGameController_VR : MonoBehaviour
{
    public static InGameController_VR Instance;

    [SerializeField] private GameObject _ballPrefab;
    [HideInInspector] public GameObject _ball;


    [SerializeField] private GameObject _pushCube;
    private float _pushCubeOffsetY = 0;
    private float _pushPower = 0;

    [SerializeField] OVRInput.Controller controllerType;

    /// <summary>
    /// pushCubeの上に載っているballを格納したリスト
    /// </summary>
    public List<GameObject> ReadyBallList = new List<GameObject>();

    public List<GameObject> ExistBallList = new List<GameObject>();

    private Vector3 _addBallPosition = new Vector3(-13.5f, -16, 31.78f);

    private bool _isPlaying = true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //void Start()
    //{
    //    _isPlaying = true;
    //}

    // Update is called once per frame
    void Update()
    {
        if (!_isPlaying)
            return;

        if (ExistBallList.Count <= 0 && _isPlaying)
        {
            _isPlaying = false;
            StartCoroutine(LoadResultScene());
            return;
        }


        //if (Input.GetKeyDown(KeyCode.LeftShift))
        //    AddBall();


        Vector3 currentPushCubePosition = _pushCube.transform.position;

#if UNITY_EDITOR

        //スペースキーを押した時（デバッグ用）
        if (Input.GetKey(KeyCode.Space) & _pushCubeOffsetY > -2)
        {
            _pushCubeOffsetY -= 0.01f;
            currentPushCubePosition.y -= 0.01f;

            _pushPower += 0.5f;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            foreach(var ball in ReadyBallList)
            {
                Rigidbody rb = ball.GetComponent<Rigidbody>();
                rb.AddForce(Vector3.up * _pushPower, ForceMode.Impulse);
            }
            ReadyBallList.Clear();

            StartCoroutine(PushCubeReturn());
            _pushPower = 0;
        }

#else
        float triggerStrength = OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger);

        //トリガーでボールを発射する
        //if (triggerStrength >= 0.1f & _pushCubeOffsetY > -2)
        //トリガーではなくAボタンでボールを発射する
        if (OVRInput.Get(OVRInput.Button.One) & _pushCubeOffsetY > -2)
        {
            _pushCubeOffsetY -= 0.01f;
            currentPushCubePosition.y -= 0.01f;

            OVRInput.SetControllerVibration(0.7f, _pushCubeOffsetY* -0.5f, controllerType);

            _pushPower += 0.5f;
        }


        //if (triggerStrength < 0.1f)
        if (OVRInput.GetUp(OVRInput.Button.One))
        {
            foreach(var ball in BallList)
            {
                Rigidbody rb = ball.GetComponent<Rigidbody>();
                rb.AddForce(Vector3.up * _pushPower, ForceMode.Impulse);
            }
            BallList.Clear();

            StartCoroutine(PushCubeReturn());

            OVRInput.SetControllerVibration(0, 0, controllerType);

            _pushPower = 0;
        }

        //下記はペンディング。トリガーがアナログ入力であるため0と1の値を正確に取得しない場合がある模様

        ////コントローラのトリガーを引いた時
        //if (triggerStrength > 0& _pushCubeOffsetY > -2)
        //{
        //    //中途半端に押すと下がり続ける。なんで？
        //    _pushCubeOffsetY = triggerStrength * -2f;
        //    currentPushCubePosition.y = _pushCubeCachedTransform.position.y +triggerStrength * -2f;

        //    OVRInput.SetControllerVibration(0.7f, triggerStrength, controllerType);

        //    _pushPower = triggerStrength * 100f;
        //}

        ////コントローラのトリガーを離した時
        //if (triggerStrength == 0 & _pushPower > 0)
        //{
        //    foreach(var ball in BallList)
            //{
            //    Rigidbody rb = ball.GetComponent<Rigidbody>();
            //    rb.AddForce(Vector3.up * _pushPower, ForceMode.Impulse);
            //}
            //BallList.Clear();

        //    StartCoroutine(PushCubeReturn_VR());

        //    OVRInput.SetControllerVibration(0, 0, controllerType);

        //    _pushPower = 0;
        //}
#endif

        _pushCube.transform.position = currentPushCubePosition;

    }

    IEnumerator PushCubeReturn()
    {
        Vector3 currentPushCubePosition = _pushCube.transform.position;

        while (_pushCubeOffsetY <= 0)
        {
            _pushCubeOffsetY += 0.2f;
            currentPushCubePosition.y += 0.2f;
            _pushCube.transform.position = currentPushCubePosition;

            yield return null;
        }
    }

    IEnumerator PushCubeReturn_VR()
    {
        Vector3 currentPushCubePosition = _pushCube.transform.position;

        while (_pushCubeOffsetY <= 0)
        {
            _pushCubeOffsetY += 0.2f;
            currentPushCubePosition.y += 0.2f;
            _pushCube.transform.position = currentPushCubePosition;

            yield return null;
        }
    }

    IEnumerator LoadResultScene()
    {
        yield return new WaitForSeconds(1);
        //現状2が終了画面だったため
        SceneManager.LoadScene(2);
    }

    public void AddBall()
    {
        Vector3 addBallPositionOffset = new Vector3(0, 0, 0);

        for(int i = 0; i < 10; i++)
        {
            _ball = Instantiate(_ballPrefab, _addBallPosition + addBallPositionOffset, Quaternion.identity);
            ExistBallList.Add(_ball);
            addBallPositionOffset += new Vector3(2, 0, 0);
        }
    }

    // シーンがロードされたときに呼び出されるメソッドを追加
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        _isPlaying = true;

        _ball = Instantiate(_ballPrefab, _ballPrefab.transform.position, Quaternion.identity);
        ExistBallList.Add(_ball);

        _pushCube = GameObject.Find("PushCube");

        ScoreController.Instance.Score = 0;
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

}
