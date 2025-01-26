using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float point1=1;
    [SerializeField] private float point2=10;
    [SerializeField] private GameObject spikebox1;
    [SerializeField] private GameObject spikebox2;

    private void Start()
    {
        Physics2D.IgnoreCollision(spikebox1.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(spikebox2.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        rb.linearVelocityX = speed;
    }

    void Update()
    {
        if (transform.position.x >= point2)
        {
            rb.linearVelocityX = 0f;
            rb.linearVelocityX = -speed;
        }
        if (transform.position.x <= point1)
        {
            rb.linearVelocityX = 0;
            rb.linearVelocityX = speed;
        }
    }
}
