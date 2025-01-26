using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour,IImpactable,IGravityAffector
{
    [SerializeField] GameObject transitionObject;
    private Animator transition;
    Rigidbody2D rb;

    public void AntiGravity()
    {
        rb.gravityScale *= -1;
        transform.localScale = new Vector3(transform.localScale.x,transform.localScale.y*-1f,transform.localScale.z);
    }

    public void Imbact(Vector2 dir, float force)
    {
        rb.AddForce(force * dir);
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transition = transitionObject.GetComponentInChildren<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Traps"))
        {
            StartCoroutine(LoadLevel());
        }
    }

    IEnumerator LoadLevel()
    {
        transition.SetTrigger("Start");
        //AudioManager audio = FindFirstObjectByType<AudioManager>();
        //if (audio != null)
        //{
        //    audio.Play("next");
        //}
        yield return new WaitForSeconds(1);
        //FindFirstObjectByType<AudioManager>().Stop("walk");
        GameManager.instance.Die();
    }

}
