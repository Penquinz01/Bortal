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
        AudioManager audio = FindFirstObjectByType<AudioManager>();
        if (audio != null)
        {
            audio.Play("next");
        }
        yield return new WaitForSeconds(1);
        //FindFirstObjectByType<AudioManager>().Stop("walk");
        GameManager.instance.NextScene();
    }

}
