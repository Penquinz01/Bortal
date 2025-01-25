using UnityEngine;

public class Magnetise : MonoBehaviour, IMettalic
{
    [SerializeField] float _range = 5f;
    void IMettalic.Magnetise()
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, _range); 
    }
}
