using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ImpactParticles : MonoBehaviour
{
    [SerializeField] GameObject impactParticle;
    [SerializeField] float minForce;
    [SerializeField] float maxForce;
    [SerializeField] float minSize;
    [SerializeField] float maxSize;
    [SerializeField] float particleCount;
    [SerializeField] float health;
    float timer = 0f;
    float hurtTimer = 0f;
    float bloodTimer = 0f;
    Animator anime;
    public bool isHurt;
    bool startHurt = false;
    bool startClip = false;
    bool isPlayer = false;

    public AudioSource hurter;
    public AudioClip hurtClip;
    private void Start()
    {
        anime = GetComponent<Animator>();
        isPlayer = gameObject.tag == "Player";
    }
    void Update()
    {
        timer += Time.deltaTime;
        //isHurt = Input.GetKeyDown(KeyCode.B);
        //anime.SetBool("isHurt", isHurt);
        if (isHurt)
        {
            for (int i = 0; i < particleCount; i++)
            {
                float z = Random.Range(0f, Mathf.PI);
                float force = Random.Range(minForce, maxForce);
                float size = Random.Range(minSize, maxSize);

                Vector2 dir = new Vector2(Mathf.Cos(z), Mathf.Sin(z));
                var instance = Instantiate(impactParticle, transform.position - (Vector3.forward), transform.rotation);

                instance.GetComponent<Rigidbody2D>().AddForce(dir * force);
                instance.transform.localScale = Vector3.one * size;
            }
            timer = 0f;
            if (startClip)
            {
                hurter.PlayOneShot(hurtClip);
                startClip = false;
            }

            if (!isPlayer)
            {
                health--;
            }
            if (health <= 0)
            {
                startHurt = true;
            }
        }
        isHurt = false;

        if (startHurt)
        {
            bloodTimer += Time.deltaTime;
            if (bloodTimer > 0.2f)
            {
                isHurt = true;
                bloodTimer = 0f;
            }
            hurtTimer += Time.deltaTime;
            if (hurtTimer > 0.3f)
            {
                Destroy(gameObject);
            }
        }


        //if (timer > 10f)
        //{
        //    Destroy(GameObject.Find(bloodParticle.name + "(Clone)"));
        //}


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Bullet"))
        {
            isHurt = true;
            startClip = true;
        }
    }

}
