using UnityEngine;

public class ExpireByJumps : MonoBehaviour
{
    [SerializeField] int maxAmoutJumps;
    [SerializeField] GameObject CanvasButton_restartLevel;
    MouseJump mouseJump;
    public bool expired;
    void Start()
    {
        mouseJump = GetComponent<MouseJump>();
    }

    void Update()
    {
        if (mouseJump.getAmountJumps() > maxAmoutJumps) //Does not need to check every tick, can check enly every jump
        {
            expireBanana();
        }
    }

    void expireBanana()
    {
        expired = true;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0.588f, 0.431f, 0f);    //TODO: New skin for expired banana
        CanvasButton_restartLevel.SetActive(true);
    }

    public int getMaxJumps()
    {
        return maxAmoutJumps;
    }
}
