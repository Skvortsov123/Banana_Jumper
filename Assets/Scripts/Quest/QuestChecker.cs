using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestChecker : MonoBehaviour
{
    [SerializeField] private GameObject dialougeBox, finishedText, unfinishedText;
    //[SerializeField] private int questGoal = 1; Cause an Warning in console "assigned but never used"
    [SerializeField] private int levelToLoad;

    private Animator anim;
    private bool levelIsLoading = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<SceneChanger>() )//.applesCollected >= questGoal) Cause an error in console, please fix
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

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(levelToLoad);
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
