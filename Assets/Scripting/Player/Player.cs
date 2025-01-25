using UnityEngine;

public class Player : MonoBehaviour,IImpactable,IGravityAffector
{
    Rigidbody2D rb;
    [SerializeField]bool isGrounded = false;
    [SerializeField] float rayLength;
    [SerializeField] LayerMask layer;

    public void AntiGravity()
    {
        rb.gravityScale *= -1;
        transform.localScale = new Vector3(transform.localScale.x,transform.localScale.y*-1f,transform.localScale.z);
    }

    public void Imbact(Vector2 dir, float force)
    {
        Debug.Log(force);
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
    private void Update()
    {
        isGrounded = Grounded();
    }
    private bool Grounded()
    {
        return Physics2D.Raycast(transform.position,Vector2.down,rayLength,layer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position - Vector3.up * rayLength);
    }
}
