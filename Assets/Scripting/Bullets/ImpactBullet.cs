using UnityEngine;

public class ImpactBullet : MonoBehaviour,IBullet,ITeleportable
{
    [SerializeField] float bulletForce = 100f;
    Rigidbody2D rb;
    bool _right;
    [SerializeField] float impactRadius = 2f;
    [SerializeField] float impactForce = 200f;
    public void Fire(Vector2 direction)
    {
        rb.AddForce(direction * bulletForce, ForceMode2D.Impulse);
    }

    public void Teleport(Vector3 vec, bool right)
    {
        if (_right != right)
        {

            Flip();
        }
        rb.position = vec;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb= GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Portal") || collision.gameObject.CompareTag("Player"))
        {
            return;
        }
        Impact();
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        _right = rb.linearVelocityX > 0;
    }
    void Impact()
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, impactRadius);
        foreach (Collider2D col in cols) { 
            if (col.TryGetComponent<IImpactable>(out var imbacted)) {
                Vector2 dir = (col.transform.position - transform.position).normalized;
                float distance = Vector2.Distance(col.transform.position, transform.position);
                float force =Mathf.Max(impactForce * (1-(distance/impactRadius)* (distance / impactRadius)),0);
                imbacted.Imbact(dir, force);
            }
        }
    }
    void Flip()
    {
        rb.linearVelocityX *= -1;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, impactRadius);
    }
}
