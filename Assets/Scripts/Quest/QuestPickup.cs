using UnityEngine;

public class QuestPickup : MonoBehaviour
{
    [SerializeField] private AudioClip pickupSound;
    [SerializeField] private GameObject gemParticles;

    public int gemsCollected = 0;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Gem"))
        {
            audioSource.PlayOneShot(pickupSound, 0.5f);
            Destroy(other.gameObject);
            gemsCollected++;
            Instantiate(gemParticles, other.transform.position, Quaternion.identity);
        }
    }
}
