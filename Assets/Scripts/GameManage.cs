using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManage : MonoBehaviour
{
    private Transform StartPoint;
    private Transform SpawnPoint;
    private PinManage nowPinManage;
    private bool isGameOver = false;
    private int score = 0;
    private Camera mainCamera;

    public GameObject pinPrefab;
    public Text scoreText;
    public float speed = 5;
  
    // Start is called before the first frame update
    void Start()
    {
        StartPoint = GameObject.Find("StartPoint").transform;
        SpawnPoint = GameObject.Find("SpawnPoint").transform;
        mainCamera = Camera.main;
        producePin();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Screen.fullScreen = false;  //退出全屏         
        }
        if (isGameOver)
        {
            if (Mathf.Abs(mainCamera.orthographicSize - 4) < 0.001f)
            {
                SceneManager.LoadScene("EndScene");
            }
            mainCamera.backgroundColor = Color.Lerp(mainCamera.backgroundColor, Color.red, speed * Time.deltaTime);
            mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, 4, speed * Time.deltaTime);
            return;
        }
        if(Input.GetMouseButtonDown(0))
        {
            ++score;
            scoreText.text = score.ToString();
            nowPinManage.Go();
            producePin();
        }
    }
    void producePin()
    {
        nowPinManage = GameObject.Instantiate(pinPrefab,SpawnPoint.position,pinPrefab.transform.rotation).GetComponent<PinManage>();
    }
    public void GameOver()
    {
        if (isGameOver) return;
        GameObject.Find("Circle").GetComponent<Rotate>().enabled = false;
        isGameOver = true;
    }
}
