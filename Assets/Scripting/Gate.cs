using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] int id;
    [SerializeField] GameObject gateBreak;
    [SerializeField] string clip;
    void Start()
    {
        GameManager.instance.Trigger += Open;
    }
    private void OnDestroy()
    {
        GameManager.instance.Trigger -= Open;
    }
    void Open(int id)
    {
        Debug.Log("Worked");
        if(this.id == id && gameObject != null)
        {
            Instantiate(gateBreak, gameObject.transform.position, Quaternion.identity);
            AudioManager audio = FindFirstObjectByType<AudioManager>();
            if (audio != null)
            {
                audio.Play(clip);
            }
            Destroy(gameObject);
        }
    }
}
