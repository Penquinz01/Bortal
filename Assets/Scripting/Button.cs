using System;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] int id;


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
