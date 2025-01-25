using UnityEngine;

public class MagneticBox : MonoBehaviour,IMettalic
{
    [SerializeField] SpikeScript SpikeThing;

    public void Magnetise()
    {
        SpikeThing.MoveableFunction();
    }
}
