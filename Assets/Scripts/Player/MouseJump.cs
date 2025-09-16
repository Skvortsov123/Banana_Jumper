using UnityEngine;
using UnityEngine.UIElements;

public class MouseJump : MonoBehaviour
{
    [SerializeField] float jumpForce;
    [SerializeField] float lineLength;
    LineRenderer lr;
    Rigidbody2D rgbd;
    int amountJumps = 0;
    bool isGrounded = false;
    void Start()
    {
        lr = createLineRenderer();
        rgbd = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, transform.position + getMouseDirection() * lineLength);

        if (Input.GetMouseButtonDown(0)) jump();
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

    LineRenderer createLineRenderer()   //Line properties
    {
        LineRenderer lr = gameObject.AddComponent<LineRenderer>();
        lr.positionCount = 2;
        lr.startWidth = 0.1f;
        lr.endWidth = 0.1f;
        lr.material = new Material(Shader.Find("Sprites/Default"));
        lr.startColor = Color.red;
        lr.endColor = Color.red;
        return lr;
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

    public int getAmountJumps() //Other scripts may access
    {
        return amountJumps;
    }
}
