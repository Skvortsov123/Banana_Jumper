using UnityEngine;

public class FinishCheckerLevel1 : MonoBehaviour
{
    [SerializeField] GameObject Button_nextLevel;
    [SerializeField] GameObject Button_restartLevel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.GetComponent<ExpireByJumps>().expired)
            {   //Restart
                Button_restartLevel.SetActive(true);
            }
            else
            {
                Button_nextLevel.SetActive(true);
            }
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}