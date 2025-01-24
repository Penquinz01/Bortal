using System;
using UnityEngine;

public class Button : MonoBehaviour
{
    public event Action<int> Trigger;
    [SerializeField] int id;

    void Open()
    {
        GameManager.instance.ButtonTrigger(id);
    }
}
