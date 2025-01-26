using UnityEngine;

public class SpikeBox : MonoBehaviour, ITeleportable
{
    Rigidbody2D rb;
    [SerializeField] float speed = 5f;
    public void Teleport(Vector3 vec, Vector3 dir, bool right)
    {
        transform.position= vec;
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rb.linearVelocityY = -speed;
    }
}
