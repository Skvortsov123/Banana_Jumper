using UnityEngine;

public class FinishChecker : MonoBehaviour
{
    [SerializeField] GameObject Button_nextLevel, Button_restartLevel;
    [SerializeField] private GameObject dialougeBox, finishedText, unfinishedText, expiredText;
    public int questGoal = 1;

    private bool levelIsLoading = false;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.GetComponent<QuestPickup>().gemsCollected >= questGoal)
            {
                if (collision.GetComponent<ExpireByJumps>().expired)
                {
                    dialougeBox.SetActive(true);
                    expiredText.SetActive(true);
                    Button_restartLevel.SetActive(true);
                    GetComponent<BoxCollider2D>().enabled = false;
                    levelIsLoading = true;
                } else {
                    dialougeBox.SetActive(true);
                    finishedText.SetActive(true);
                    Button_nextLevel.SetActive(true);
                    GetComponent<BoxCollider2D>().enabled = false;
                    levelIsLoading = true;
                }
            }
            else
            {
                dialougeBox.SetActive(true);
                unfinishedText.SetActive(true);
            }
        }
        
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !levelIsLoading)
        {
            dialougeBox.SetActive(false);
            finishedText.SetActive(false);
            unfinishedText.SetActive(false);
        }
    }
}
