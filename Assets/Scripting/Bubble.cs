using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] Transform bubblePair;
    [SerializeField] bool right;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ITeleportable por = collision.gameObject.GetComponent<ITeleportable>();
        if (por !=null)
        {
            por.Teleport(bubblePair.position,bubblePair.right,right);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
