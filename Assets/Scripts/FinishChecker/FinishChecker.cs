using UnityEngine;

public class FinishChecker : MonoBehaviour
{
    [SerializeField] GameObject Button_nextLevel;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Button_nextLevel.SetActive(true);
        }
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
