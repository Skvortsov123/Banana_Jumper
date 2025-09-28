using UnityEngine;
using UnityEngine.UI;

public class QuestCheckerCanvas : MonoBehaviour
{
    [SerializeField] private GameObject questIncomplete, questComplete;
    [SerializeField] private QuestPickup questPickup;     // drag in "Player"
    [SerializeField] private FinishChecker finishChecker; // drag in "QuestChecker"

    void FixedUpdate()
    {
        if (questPickup.gemsCollected >= finishChecker.questGoal)
        {
            questComplete.SetActive(true);
            questIncomplete.SetActive(false);
        }
        else
        {
            questIncomplete.SetActive(true);
            questComplete.SetActive(false);
        }
    }


}
