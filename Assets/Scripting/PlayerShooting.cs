using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    private PlayerInput input;
    [SerializeField] private GameObject normalBullet;
    [SerializeField] private Transform firePoint;
    [SerializeField][Range(0.1f,1f)] float bulletTimediff = 1f;
    private float bulletTime = 0;
    private void Start()
    {
        input = GetComponent<PlayerInput>();
        input.Shoot += Fire;
    }

    private void OnDisable()
    {
        input.Shoot -= Fire;
    }

    public void Fire()
    {
        if (bulletTime <= Time.time)
        {
            bulletTime = Time.time + bulletTimediff;
            GameObject bullet = Instantiate(normalBullet, firePoint.position, Quaternion.identity);
            IBullet bull = bullet.GetComponent<IBullet>();
            bull.Fire(transform.right);
        }
        
    }
}
