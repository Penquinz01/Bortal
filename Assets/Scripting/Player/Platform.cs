using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float point1=1;
    [SerializeField] private float point2=10;

    void Start()
    {
        rb.linearVelocityX = speed;
    }

    // Update is called once per frame
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
