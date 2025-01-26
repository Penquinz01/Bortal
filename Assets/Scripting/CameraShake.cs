using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float shakeAmt = 0.2f;
    private Vector3 intialPos;
    private void Awake()
    {
        intialPos = transform.position;
    }
    public IEnumerator Shake(float time)
    {
        Debug.Log("Working shake");
        float elasped = 0f;
        while (elasped < time)
        {
            transform.position = intialPos + (Vector3)Random.insideUnitCircle * shakeAmt;
            elasped += Time.deltaTime;

            yield return null;
        }
    }
}
