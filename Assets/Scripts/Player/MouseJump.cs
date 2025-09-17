using UnityEngine;
using UnityEngine.UIElements;

public class MouseJump : MonoBehaviour
{
    [SerializeField] float jumpForce;
    [SerializeField] bool drawLine;
    LineRenderer lr;
    Rigidbody2D rgbd;
    float lineLength = 1;
    int amountJumps = 0;
    bool isGrounded = false;
    bool isCreateLineRenderer = false;
    void Start()
    {
        rgbd = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(drawLine) drawLineToMouse();
        if(Input.GetMouseButtonDown(0)) jump();
    }

    void OnCollisionEnter2D(Collision2D collision)  //TODO: Chekck if real ground, not a wall or ceiling;
    {
        isGrounded = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    Vector3 getMouseDirection()    //Returns normalized direction form gameObject. normalized = enhetscircel
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.WorldToScreenPoint(transform.position).z;  // For a perspective camera, it is crucial to project the mouse onto the same depth as the object.
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);
        return (worldMousePos - transform.position).normalized;
    }

    void createLineRenderer()   //Line properties
    {
        LineRenderer line = gameObject.AddComponent<LineRenderer>();
        line.positionCount = 2;
        line.startWidth = 0.1f;
        line.endWidth = 0.1f;
        line.material = new Material(Shader.Find("Sprites/Default"));
        line.startColor = Color.red;
        line.endColor = Color.red;
        lr = line;
    }

    void jump()
    {
        if (isGrounded)
        {
            amountJumps++;
            Vector3 direction = getMouseDirection();
            rgbd.linearVelocity = new Vector2(direction.x * jumpForce, direction.y * jumpForce);
        }
    }

    void drawLineToMouse()
    {
        if(!isCreateLineRenderer)
        {
            isCreateLineRenderer = true;
            createLineRenderer();
        } 
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, transform.position + getMouseDirection() * lineLength);
    }

    public int getAmountJumps() //Other scripts may access
    {
        return amountJumps;
    }
}
