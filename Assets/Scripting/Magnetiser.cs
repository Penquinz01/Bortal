using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Magnetiser : MonoBehaviour,IMettalic
{
    [SerializeField] List<GameObject> MetalPieces;
    [SerializeField] List<Transform> Target;
    [SerializeField] GameObject Gate;
    [SerializeField] int id;

    public void Ended()
    {
        GameManager.instance.ButtonTrigger(id);
    }
    public void Magnetise()
    {
        for(int i = 0; i < MetalPieces.Count; i++)
        {
            MetalObject ob = MetalPieces[i].GetComponent<MetalObject>();
            if (ob !=null)
            {
                Vector2 direction = (transform.position - Target[i].position).normalized;
                Debug.Log(direction);
                ob.Attract(direction);
            }
        }
        StartCoroutine(waitFor());
    }
    IEnumerator waitFor()
    {
        yield return new WaitForSeconds(1.5f);
        Ended();
    }



}
