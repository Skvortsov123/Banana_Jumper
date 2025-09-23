using UnityEngine;

public class FinishChecker : MonoBehaviour
{
    [SerializeField] GameObject Button_nextLevel;
    [SerializeField] private GameObject dialougeBox, finishedText, unfinishedText;
    [SerializeField] private int questGoal = 1;

    private bool levelIsLoading = false;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.GetComponent<QuestPickup>().gemsCollected >= questGoal)
            {
                dialougeBox.SetActive(true);
                finishedText.SetActive(true);
                Button_nextLevel.SetActive(true);
                
                levelIsLoading = true;
            }
            else
            {
                dialougeBox.SetActive(true);
                unfinishedText.SetActive(true);
            }
            GetComponent<BoxCollider2D>().enabled = false;
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
