using UnityEngine;

public class MoveButtonWhenHovering : MonoBehaviour
{
    [SerializeField] float speed = 100f;
    RectTransform rt;
    bool mouseOver = false;
    void Start()
    {
        rt = gameObject.GetComponent<RectTransform>();
    }

    public void PointerEnter()
    {
        mouseOver = true;
    }

    public void PointerExit()
    {
        mouseOver = false;
    }

    void Update()
    {
        if (mouseOver) MoveFromMouse();
    }

    void MoveFromMouse()
    {
        Vector2 localMousePos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rt, Input.mousePosition, null, out localMousePos);
        rt.anchoredPosition -= localMousePos.normalized * speed * Time.deltaTime;
    }
}
