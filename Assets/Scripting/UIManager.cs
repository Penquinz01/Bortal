using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Sprite[] img;
    public static UIManager Instance;
    [SerializeField] Image image;
    [SerializeField]PlayerShooting shoot;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else { 
            Destroy(gameObject);
        } 
    }

    // Update is called once per frame
    void Update()
    {
        image.sprite = img[shoot.currentBullet];
    }
}
