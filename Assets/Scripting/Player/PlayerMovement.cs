using UnityEngine;

public class PlayerMovement : MonoBehaviour,ITeleportable
{
    PlayerInput input;
    [SerializeField] private float speed = 5f;
    [SerializeField] Transform Gun;
    Rigidbody2D rb;
    Vector2 direction;  
    public bool IsTeleported = true;
    private bool isRight = true;
    float yValue;
    void Start()
    {
        input = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        direction = input.moveVec;
        yValue = direction.y;
        direction.y = 0;
        if((isRight &&direction.x<0)|| !isRight && direction.x > 0)
        {
            changeDirection();
        }
        if (yValue != 0)
        {
            RotateGun(yValue, 0);
        }
        if (Mathf.Abs(direction.x) > 0)
        {
            int multi = direction.x > 0 ?1:-1;
            Gun.rotation = Quaternion.Euler(0, 0, 90 * multi - 90);
            Gun.localScale = new Vector3(1, multi, 1);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(direction.x * speed,rb.linearVelocityY);
    }

    public void Teleport(Vector3 loc, Vector3 dir,bool right)
    {
        rb.position = loc;
    }
    public void setBool(bool value)
    {
        IsTeleported = value;
    }
    public void changeDirection()
    { 
        isRight = !isRight;

        transform.Rotate(new Vector3(0,180,0));
    }
    private void RotateGun(float yValue, float angle)
    {
        int multi =yValue>0?1:-1 ;
        Gun.rotation = Quaternion.Euler(0,0,90 * multi - angle);
    }
}
