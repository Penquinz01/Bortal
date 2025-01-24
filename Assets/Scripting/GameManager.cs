using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private static int currentLevel = 0;

    public void Awake()
    {
        instance = this;
    }

    public void NextScene()
    {
        currentLevel++;
        SceneManager.LoadScene(currentLevel);
    }
}
