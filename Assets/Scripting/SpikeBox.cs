using UnityEngine;

public class SpikeBox : MonoBehaviour, ITeleportable
{
    public void Teleport(Vector3 vec, Vector3 dir, bool right)
    {
        transform.position= vec;
    }
}
