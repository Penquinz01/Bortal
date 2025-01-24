using System;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static int currentLevel = 0;
    public event Action<int> Trigger;

    public void Awake()
    {
        instance = this;
    }

    public void NextScene()
    {
        currentLevel++;
        SceneManager.LoadScene(currentLevel);
    }
    public void ButtonTrigger(int id)
    {
        Trigger.Invoke(id);
    }
}
