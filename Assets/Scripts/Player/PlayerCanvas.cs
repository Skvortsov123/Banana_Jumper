using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerCanvas : MonoBehaviour
{
    [SerializeField] TMP_Text amountJumpsTMP_Text;
    MouseJump mouseJump;
    ExpireByJumps expireByJumps;

    void Start()
    {
        mouseJump = GetComponent<MouseJump>();
        expireByJumps = GetComponent<ExpireByJumps>();
    }

    void Update()
    {
        amountJumpsTMP_Text.text = mouseJump.getAmountJumps()+" / "+expireByJumps.getMaxJumps();
    }
}
