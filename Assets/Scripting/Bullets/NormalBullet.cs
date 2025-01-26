using UnityEditor.Tilemaps;
using UnityEngine;

public class NormalBullet : MonoBehaviour,IBullet,ITeleportable
{
    [SerializeField] float bulletForce = 100f;
    public Rigidbody2D rb;
    Vector2 direction;
    bool _right;
    [SerializeField] GameObject splash;
    public void Fire(Vector2 direction)
    {
        
        this.direction = direction;
        rb.AddForce(direction * bulletForce, ForceMode2D.Impulse);
    }

    public void Teleport(Vector3 vec, Vector3 dir, bool right)
    {
        float speed = rb.linearVelocity.magnitude;
        int mult = -1;
        if (_right != right)
        {
            mult = 1;
            Flip();
        }
        rb.position = vec;
        rb.linearVelocity = dir * speed*mult;
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
        Instantiate(splash, gameObject.transform.position, Quaternion.identity);
        AudioManager audio = FindFirstObjectByType<AudioManager>();
        if (audio != null)
        {
            audio.Play("splash");
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
