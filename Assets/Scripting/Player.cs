using UnityEngine;

public class Player : MonoBehaviour,IImpactable
{
    Rigidbody2D rb;
    public void Imbact(Vector2 dir, float force)
    {
        Debug.Log(force);
        rb.AddForce(force * dir);
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


}
