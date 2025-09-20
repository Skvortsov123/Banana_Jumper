using System;
using UnityEngine;
using UnityEngine.UIElements;

public class MouseJump : MonoBehaviour
{
    [SerializeField] float jumpForce;
    [SerializeField] float jumpForceDelta;
    [SerializeField] float jumpForceSpeed;   //How fast line change direction
    [SerializeField] float lineLength;
    [SerializeField] float isGroundedDelay;
    [SerializeField] bool drawLine;
    Rigidbody2D rgbd;
    LineRenderer line;
    float dynamicJumpForce;
    float timerDynamicJump;
    float dynamicLineLength;
    float lastTimeIsGrounded;
    int amountJumps = 0;
    bool isGrounded = false;
    bool isMouseDown = false;

    void Start()
    {
        rgbd = gameObject.GetComponent<Rigidbody2D>();
        line = gameObject.AddComponent<LineRenderer>(); //Line properties
        line.sortingOrder = 1;
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
            resetDynamicJumpForce();
        }
        if (Input.GetMouseButtonUp(0))
        {
            isMouseDown = false;
            jump();
        }
        if (isMouseDown && isGroundedDelayed())
        {
            updateDynamicJumpForce();
            line.enabled = true;
        }
        else
        {
            line.enabled = false;
            resetDynamicJumpForce();
        }
    }

    void OnTriggerStay2D(Collider2D collision)  //TODO: Bug, sometimes banan dont want to jump. May be OnCollisionEnter2D dont trigger
    {
        isGrounded = true;
    }

    void OnTriggerExit2D(Collider2D collision)   //TODO: Make trigger around banana, so if something nerby banana can jump, not timer!
    {
        isGrounded = false;
    }

    bool isGroundedDelayed()
    {
        if (isGrounded)
        {
            lastTimeIsGrounded = Time.time;
        }
        if (lastTimeIsGrounded + isGroundedDelay > Time.time)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void updateDynamicJumpForce()  //onTick
    {
        dynamicJumpForce = jumpForce + Mathf.Sin((Time.time - timerDynamicJump) * jumpForceSpeed + Mathf.PI*1.5f) * jumpForceDelta;
        dynamicLineLength = dynamicJumpForce*lineLength*0.1f;  
    }

    void resetDynamicJumpForce()
    {
        timerDynamicJump = Time.time;
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
