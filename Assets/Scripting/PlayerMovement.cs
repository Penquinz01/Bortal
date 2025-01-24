using UnityEngine;

public class PlayerMovement : MonoBehaviour,ITeleportable
{
    PlayerInput input;
    [SerializeField] private float speed = 5f;
    Rigidbody2D rb;
    Vector2 direction;
    public bool IsTeleported = true;
    private bool isRight = true;
    void Start()
    {
        input = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        direction = input.moveVec;
        if((isRight &&direction.x<0)|| !isRight && direction.x > 0)
        {
            changeDirection();
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.linearVelocity = direction * speed;
    }

    public void Teleport(Vector3 loc)
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
