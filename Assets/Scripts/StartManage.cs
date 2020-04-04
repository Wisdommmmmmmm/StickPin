using UnityEngine;
using UnityEngine.SceneManagement;
public class StartManage : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void endGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Screen.fullScreen = false;  //退出全屏         
        }
    }
}