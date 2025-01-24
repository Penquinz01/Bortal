using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public void Awake()
    {
        instance = this;
    }

    public void NextScene()
    {
        Debug.Log("Ended the Game");
    }
}
