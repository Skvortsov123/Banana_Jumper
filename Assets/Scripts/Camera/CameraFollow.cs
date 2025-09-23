using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector2 offset;
    [SerializeField] float speed = 1.0f;
    [SerializeField] GameObject limitLeftObj;
    [SerializeField] GameObject limitRightObj;
    Vector3 offset3;

    void Start()
    {
        offset3 = new Vector3(offset.x, offset.y, transform.position.z);
    }
    void LateUpdate()
    {
        Vector3 newPosition = Vector3.Lerp(transform.position, target.position + offset3, speed * Time.deltaTime);
        if (newPosition.x > limitLeftObj.transform.position.x && newPosition.x < limitRightObj.transform.position.x)
        {
            transform.position = newPosition;
        }
        else
        {
            transform.position = new Vector3(transform.position.x, newPosition.y, transform.position.z);
        }

    }

}
