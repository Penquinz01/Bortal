using UnityEngine;

public class Player : MonoBehaviour,IImpactable,IGravityAffector
{
    Rigidbody2D rb;

    public void AntiGravity()
    {
        rb.gravityScale *= -1;
        transform.localScale = new Vector3(transform.localScale.x,transform.localScale.y*-1f,transform.localScale.z);
    }

    public void Imbact(Vector2 dir, float force)
    {
        rb.AddForce(force * dir);
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Traps"))
        {
            GameManager.instance.Die();
        }
    }
    

    
}
