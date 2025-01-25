using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _anim;
    private Rigidbody2D _rb;
    float speed;
    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        speed = Mathf.Abs(_rb.linearVelocityX);
        _anim.SetFloat("Speed", speed);
        //_anim.SetBool("Teleport", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Portal"))
        {
            _anim.SetTrigger("Teleport");
        }
    }
}
