using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] int id;
    [SerializeField] GameObject gateBreak;
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
        if(this.id == id)
        {
            Instantiate(gateBreak, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
