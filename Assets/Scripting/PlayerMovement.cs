using UnityEngine;

public class PlayerMovement : MonoBehaviour,ITeleportable
{
    PlayerInput input;
    [SerializeField] private float speed = 5f;
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
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(direction.x * speed,rb.linearVelocityY);
    }

    public void Teleport(Vector3 loc, bool right)
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
}
