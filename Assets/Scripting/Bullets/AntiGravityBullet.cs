using UnityEngine;

public class AntiGravityBullet : MonoBehaviour,IBullet,ITeleportable
{
    [SerializeField] float bulletForce = 100f;
    Rigidbody2D rb;
    bool _right;
    [SerializeField] float affectRadius = 2f;
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
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        _right = rb.linearVelocityX > 0;
    }
    void Flip()
    {
        rb.linearVelocityX *= -1;
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

    void Impact()
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, affectRadius);
        foreach (Collider2D col in cols) { 
            IGravityAffector gravity = col.GetComponent<IGravityAffector>();
            gravity?.AntiGravity();
        }
    }
}
