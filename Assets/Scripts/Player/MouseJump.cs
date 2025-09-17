using UnityEngine;
using UnityEngine.UIElements;

public class MouseJump : MonoBehaviour
{
    [SerializeField] float jumpForce;
    [SerializeField] float jumpForceDelta;
    [SerializeField] float dynamicJumpForceSpeed;   //How fast line change direction
    [SerializeField] float lineLength;
    [SerializeField] bool drawLine;
    Rigidbody2D rgbd;
    LineRenderer line;
    float dynamicJumpForce;
    float timerDynamicJump;
    float dynamicLineLength;
    int amountJumps = 0;
    bool isGrounded = false;
    bool isMouseDown = false;

    void Start()
    {
        rgbd = gameObject.GetComponent<Rigidbody2D>();
        line = gameObject.AddComponent<LineRenderer>(); //Line properties
        line.positionCount = 2;
        line.startWidth = 0.1f;
        line.endWidth = 0.1f;
        line.material = new Material(Shader.Find("Sprites/Default"));
        line.startColor = Color.red;
        line.endColor = Color.yellow;
        line.enabled = false;
    }

    void Update()
    {
        if(drawLine) drawLineToMouse();
        if (Input.GetMouseButtonDown(0))
        {
            isMouseDown = true;
            timerDynamicJump = Time.time;
            line.enabled = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isMouseDown = false;
            jump();
            line.enabled = false;
        }
        if (isMouseDown)
        {
            dynamicJumpForce = jumpForce - jumpForceDelta;
            updateDynamicJumpForce();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)  //TODO: Chekck if real ground, not a wall or ceiling;
    {
        isGrounded = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    void updateDynamicJumpForce()  //onTick
    {
        dynamicJumpForce = jumpForce + Mathf.Sin(timerDynamicJump - Time.time * dynamicJumpForceSpeed) * jumpForceDelta;
        dynamicLineLength = dynamicJumpForce*lineLength*0.1f;  
    }

    Vector3 getMouseDirection()    //Returns normalized direction. normalized = enhetscircel
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.WorldToScreenPoint(transform.position).z;  // For a perspective camera, it is crucial to project the mouse onto the same depth as the object.
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);
        return (worldMousePos - transform.position).normalized;
    }

    void jump()
    {
        if (isGrounded)
        {
            amountJumps++;
            Vector3 direction = getMouseDirection();
            rgbd.linearVelocity = new Vector2(direction.x * dynamicJumpForce, direction.y * dynamicJumpForce);
        }
    }

    void drawLineToMouse()
    {
        line.SetPosition(0, transform.position);
        line.SetPosition(1, transform.position + getMouseDirection() * dynamicLineLength);
    }


    public int getAmountJumps() //Other scripts may access
    {
        return amountJumps;
    }
}
