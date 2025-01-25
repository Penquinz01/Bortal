using System;
using UnityEngine;
using System.Collections;

public class EndPoint : MonoBehaviour
{
    [SerializeField] GameObject transitionObject;
    private Animator transition;

    private void Start()
    {
        transition = transitionObject.GetComponentInChildren<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(LoadLevel());
        }
    }



    IEnumerator LoadLevel()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        GameManager.instance.NextScene();
    }

}
