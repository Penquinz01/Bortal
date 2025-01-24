using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] int id;
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
        if(this.id == id)
        {
            Destroy(gameObject);
        }
    }
}
