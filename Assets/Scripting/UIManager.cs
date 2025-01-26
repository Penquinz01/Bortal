using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Sprite[] img;
    public static UIManager Instance;
    void Awake()
    {
        if (Instance == null) {
            Instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
