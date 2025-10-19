using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

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
    public IEnumerator bla()
    {
        while (true) ;
    }

    public static void SetDifficulty(int difficulty)
    {
        GameVariables.difficulty = difficulty;
        SceneManager.LoadScene("Brief Scene");
    }
}
