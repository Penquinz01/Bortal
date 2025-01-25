using UnityEngine;

public class MetalObject : MonoBehaviour
{
    [SerializeField] float force= 30f;
    Rigidbody2D rb;
    bool isAttracting = false;
    private Vector3 target;
    public bool isDone = false;
    [SerializeField] Magnetiser attAobject;
    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void Attract(Vector2 target)
    {
        isAttracting=true;
        this.target = target; 
    }
    public void Update()
    {
        if (isAttracting)
        {
            rb.linearVelocity = target *force *Time.deltaTime;
        }
        if (Vector2.Distance(target, transform.position) < 2f)
        {
            isAttracting=false;
            isDone = true;
            attAobject.Ended();
        }
        
    }
}
