using UnityEngine;
using System.Collections;
using TMPro;
public class PlayButtonScipt : MonoBehaviour
{
    [SerializeField] GameObject transitionObject;
    [SerializeField] GameObject text;
    private Animator transition;
    [SerializeField] Animator bubble;

    private void Start()
    {
        transition = transitionObject.GetComponentInChildren<Animator>();
        FindFirstObjectByType<AudioManager>().Play("theme");
    }
    public void OnJump()
    {
        text.SetActive(false);
        StartCoroutine(LoadLevel());   
    }

    IEnumerator LoadLevel()
    {
        transition.SetTrigger("Start");
        AudioManager audio = GetComponent<AudioManager>();
        if (audio != null)
        {
            audio.Play("next");
        }
        yield return new WaitForSeconds(2);
        GameManager.instance.NextScene();
    }
}
