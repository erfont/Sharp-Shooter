using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text enemiesLeftText;
    [SerializeField] GameObject youWinText;

    int enemiesLeft = 0;

    const string ENEMIES_LEFT_STRING = "ENEMIES LEFT: ";

    void Start()
    {
        
        //AdjustEnemiesLeft(FindObjectsByType<Enemyhealth>().Length);

    }

    public void AdjustEnemiesLeft(int amount)
    {
        enemiesLeft += amount;
        enemiesLeftText.text = ENEMIES_LEFT_STRING + enemiesLeft.ToString();

        if (enemiesLeft <= 0)
        {
            youWinText.SetActive(true);
            enemiesLeftText.enabled = false;
        }
    }

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
