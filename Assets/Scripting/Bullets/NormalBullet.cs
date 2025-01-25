using UnityEditor.Tilemaps;
using UnityEngine;

public class NormalBullet : MonoBehaviour,IBullet,ITeleportable
{
    [SerializeField] float bulletForce = 100f;
    public Rigidbody2D rb;
    Vector2 direction;
    bool _right;
    public void Fire(Vector2 direction)
    {
        
        this.direction = direction;
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
    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Portal") || collision.gameObject.CompareTag("Player"))
        {
            return;
        }
        if (collision.gameObject.CompareTag("Button"))
        {
            Button button = collision.gameObject.GetComponent<Button>();
            button.Open();
        }
        Destroy(gameObject);
    }
    private void Update()
    {
        _right = rb.linearVelocityX > 0;
    }
    void Flip() {
        Debug.Log("Working");
        rb.linearVelocityX *=-1;
    }   


}
