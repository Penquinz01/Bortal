using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnetise : MonoBehaviour, IMettalic
{
    [SerializeField] List<GameObject> MetalPieces;
    [SerializeField] List<Transform> Target;
    [SerializeField] GameObject Gate;
    private int done = 0;
    void IMettalic.Magnetise()
    {
        for (int i = 0; i < MetalPieces.Count; i++) {
            MetalObject ob= MetalPieces[i].GetComponent<MetalObject>();
            if (ob != null) {
                ob.Attract(Target[i].position);
            }
        }
    }
    public void Ended()
    {
        done++;
        if(done == MetalPieces.Count)
        {
            Destroy(Gate);
        }
    }
}
