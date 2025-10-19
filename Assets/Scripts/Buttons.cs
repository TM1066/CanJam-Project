using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public static void Exit()
    {
        Application.Quit();
    }

    public static void SetDifficulty(int difficulty)
    {
        GameVariables.difficulty = difficulty;
        SceneManager.LoadScene("Brief Scene");
    }
}
