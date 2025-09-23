using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestChecker : MonoBehaviour
{
    /*[SerializeField] private GameObject dialougeBox, finishedText, unfinishedText;
    [SerializeField] private int questGoal = 1;
    [SerializeField] private int levelToLoad;

    private bool levelIsLoading = false;

    private void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<QuestPickup>().gemsCollected >= questGoal)
            {
                dialougeBox.SetActive(true);
                finishedText.SetActive(true);
                Invoke("LoadNextLevel", 3.0f);
                levelIsLoading = true;
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
    */
}
