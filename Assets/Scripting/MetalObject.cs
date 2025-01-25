using UnityEngine;

public class MetalObject : MonoBehaviour
{
    [SerializeField] float force= 30f;
    Rigidbody2D rb;
    bool isAttracting = false;
    private Vector2 target;
    public bool isDone = false;
    [SerializeField] Magnetise attAobject;
    public void Attract(Vector2 target)
    {
        isAttracting=true;
        this.target = target; 
    }
    public void Update()
    {
        if (isAttracting)
        {
            transform.Translate(target.normalized * force * Time.deltaTime);
        }
        if (Vector2.Distance(target, transform.position) < 0.2f)
        {
            isAttracting=false;
            isDone = true;
            attAobject.Ended();
        }
        
    }
}
