using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public void RestartLevelButton()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);

    }

    public void QuitButton()
    {
        Debug.Log("Doesn't work in Unity Editor");
        Application.Quit();
    }
}
