using System;
using UnityEngine;

public class Button : MonoBehaviour,IMettalic
{
    [SerializeField] int id;

    public void Magnetise()
    {
        throw new NotImplementedException();
    }

    public void Open()
    {
        GameManager.instance.ButtonTrigger(id);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("KeyBox"))
        {
            Open();
        }
    }
}
