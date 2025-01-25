using UnityEngine;

public class ImpactableBox : MonoBehaviour,IImpactable
{
    [SerializeField] float force = 20f;
    Rigidbody2D rb;
    public void Imbact(Vector2 dir, float force)
    {
        rb.AddForce(Vector2.right * this.force);
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


}
