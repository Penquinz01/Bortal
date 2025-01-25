using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    [SerializeField] Transform EndPos;
    bool Moveable = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position == EndPos.position && Moveable)
        {
            Moveable = false;
        }
        if (Moveable)
        {
            transform.position = Vector3.Lerp(transform.position,EndPos.position,0.3f);
        }
    }
    public void MoveableFunction()
    {
        Moveable = true;
    }
}
