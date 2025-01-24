using UnityEngine;

public class NormalBullet : MonoBehaviour,IBullet,ITeleportable
{
    [SerializeField] float bulletForce = 100f;
    public Rigidbody2D rb;
    
    public void Fire(Vector2 direction)
    {
        
        Debug.Log(direction);
        rb.AddForce(direction * bulletForce, ForceMode2D.Impulse);
    }

    public void Teleport(Vector3 vec)
    {
        rb.position = vec;
    }
    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }


}
