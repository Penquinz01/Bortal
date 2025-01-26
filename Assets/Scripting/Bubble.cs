using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] Transform bubblePair;
    [SerializeField] bool right;
    private Animator anim;
    [SerializeField] Bubble pairAnim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        //pairAnim = bubblePair.GetComponentInParent<Bubble>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ITeleportable por = collision.gameObject.GetComponent<ITeleportable>();
        if (por !=null)
        {
            por.Teleport(bubblePair.position,bubblePair.right,right);
            anim.SetTrigger("Boom");
            pairAnim.animateBurst();
            AudioManager audio = FindFirstObjectByType<AudioManager>();
            if (audio != null)
            {
                audio.Play("teleport");
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //anim.SetBool("Burst", false);
        
        //pairAnim.SetBool("Burst", false);
    }
    public void animateBurst()
    {
        anim.SetTrigger("Boom");
    }
}
