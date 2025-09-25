using UnityEngine;

public class FinishCheckerLevel1 : MonoBehaviour
{
    [SerializeField] GameObject Button_nextLevel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Button_nextLevel.SetActive(true);
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}