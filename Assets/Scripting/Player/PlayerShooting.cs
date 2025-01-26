using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    private PlayerInput input;
    [SerializeField] private GameObject normalBullet;
    [SerializeField] private Transform firePoint;
    [SerializeField][Range(0.1f,1f)] float bulletTimediff = 1f;
    [SerializeField] private GameObject impactBullet;
    [SerializeField] private GameObject gravityBullet;
    [SerializeField] private GameObject magneticBullet;
    private int currentBullet;
    GameObject currentBulletObject;
    //currentBullet Code
    // 0 -> normal
    //1 ->impact
    //2 -> grivity
    //3->magnetic
    [SerializeField] private int totaltypeofBullet = 2;
    private float bulletTime = 0;
    private void Start()
    {
        input = GetComponent<PlayerInput>();
        input.Shoot += Fire;
        currentBullet = 0;
    }

    private void OnDisable()
    {
        input.Shoot -= Fire;
    }

    public void Fire()
    {
        if (bulletTime <= Time.time)
        {
            
            switch (currentBullet)
            {
                case 0 :currentBulletObject = normalBullet;
                    break;
                case 1:currentBulletObject = impactBullet;
                    break;
                case 2:currentBulletObject = gravityBullet;
                    break;
                case 3:currentBulletObject = magneticBullet;
                    break;
                default:return;
            }
            bulletTime = Time.time + bulletTimediff;
            GameObject bullet = Instantiate(currentBulletObject, firePoint.position, Quaternion.identity);
            IBullet bull = bullet.GetComponent<IBullet>();
            bull.Fire(firePoint.right);
            AudioManager audio = FindFirstObjectByType<AudioManager>();
            if (audio != null)
            { 
                audio.Play("shoot");
            }
        }
        
    }
    public void SwitchBullet()
    {
        currentBullet++;
        if(currentBullet >= totaltypeofBullet)
        {
            currentBullet = 0;
        }
    }
}
