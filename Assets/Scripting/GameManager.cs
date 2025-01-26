using System;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static int currentLevel;
    public event Action<int> Trigger;
    private CameraShake cameraShake;
    [SerializeField] float time = 0.5f;
    [SerializeField] float magnitude = 2f;
    public void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        cameraShake = Camera.main.GetComponent<CameraShake>();
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
    public void Die()
    {
        SceneManager.LoadScene(currentLevel);
    }
    public void Shake()
    {
        StartCoroutine(cameraShake.Shake(time,magnitude));
    }
}
