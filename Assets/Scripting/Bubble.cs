using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] Transform bubblePair;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ITeleportable por = collision.gameObject.GetComponent<ITeleportable>();
        if (por !=null)
        {
            por.Teleport(bubblePair.position);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
