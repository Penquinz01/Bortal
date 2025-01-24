using System;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] int id;

    public void Open()
    {
        GameManager.instance.ButtonTrigger(id);
    }
}
