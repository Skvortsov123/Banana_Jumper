using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;
    [SerializeField] float speed = 1.0f;

    void Start()
    {
        offset = new Vector3(offset.x, offset.y, transform.position.z);
    }
    void LateUpdate()
    {
        Vector3 newPosition = Vector3.Lerp(transform.position, target.position + offset, speed * Time.deltaTime);
        transform.position = newPosition;
    }

    //TODO: Make smooth camera follow/offset after mouse, so player can see more to direction he wants jump to
}
