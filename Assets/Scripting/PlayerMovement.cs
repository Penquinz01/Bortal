using UnityEngine;

public class PlayerMovement : MonoBehaviour,ITeleportable
{
    PlayerInput input;
    [SerializeField] private float speed = 5f;
    [SerializeField] Transform Gun;
    Rigidbody2D rb;
    Vector2 direction;  
    Vector3 offset;
    public bool IsTeleported = true;
    private bool isRight = true;
    float yValue;
    void Start()
    {
        input = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
        offset = Vector3.up * 0.5f;
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
        if(yValue != 0)
        {
            RotateGun(yValue);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(direction.x * speed,rb.linearVelocityY);
    }

    public void Teleport(Vector3 loc, bool right)
    {
        rb.position = loc-offset;
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
    private void RotateGun(float yValue)
    {
        int multi =yValue>0?1:-1 ;
        //transform.rotation = new Vector3(0,0,90*multi);
    }
}
