using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float point1=1;
    [SerializeField] private float point2=10;
   /* private GameObject target = null;
    private Vector3 offset;

    private void OnTriggerStay2D(Collision2D collision)
    {
        target = collision.gameObject;
        offset = target.transform.position - transform.position;
    }

    private void OnTriggerExit2D(Collision2D collision)
    {
        target = null;
    }*/

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("SpikeBox");
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        rb.linearVelocityX = speed;
        //target = null;
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

        /*if (target != null)
            target.transform.position = transform.position + offset;
        */
    }
}
