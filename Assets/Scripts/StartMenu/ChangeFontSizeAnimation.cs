using UnityEngine;
using TMPro;

public class ChangeFontSizeAnimation : MonoBehaviour
{
    [SerializeField] float textMinSize;
    [SerializeField] float textMaxSize;
    [SerializeField] float speed;
    TextMeshProUGUI tmpText;
    void Start()
    {
        tmpText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        tmpText.fontSize = Mathf.Lerp(textMinSize, textMaxSize, (Mathf.Sin(Time.time * speed) + 1f) / 2f);
    }
}
