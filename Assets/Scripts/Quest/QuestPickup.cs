using UnityEngine;

public class QuestPickup : MonoBehaviour
{
    public int gemsCollected = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Gem"))
        {
            Destroy(other.gameObject);
            gemsCollected++;  
        }
    }
}
