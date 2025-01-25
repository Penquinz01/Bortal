using UnityEngine;

public class GateSpawn : MonoBehaviour
{
    [SerializeField] private int id = 1;
    [SerializeField] GameObject prefab;
    [SerializeField] Transform target;

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
            Instantiate(prefab,target);
        }
    }
}
