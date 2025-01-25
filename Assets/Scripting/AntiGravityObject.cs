using UnityEngine;

public class AntiGravityObject : MonoBehaviour,IGravityAffector
{
    Rigidbody2D rb;
    public void AntiGravity()
    {
        rb.gravityScale *= -1;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
}
