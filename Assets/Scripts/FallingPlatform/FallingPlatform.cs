using NUnit.Framework;
using UnityEngine;
using System.Collections;

public class FallingPlatform : MonoBehaviour
{
    public GameObject Player; // Referens till spelaren
    public string playerTag = "Player"; // Taggen som identifierar spelaren
    public float disableColliderDelay = 1.5f;  // Tid innan collidern stängs av (när luckan öppnas)
    public float enableColliderDelay = 1f;   // Tid innan collidern aktiveras igen (när luckan stängts)

    private Animator animator;
    private Collider2D platformCollider;
    private bool isTriggered = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        platformCollider = GetComponent<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isTriggered && other.CompareTag(playerTag))
        {
            StartCoroutine(ActivateTrapdoor());
        }
    }

    IEnumerator ActivateTrapdoor()
    {
        isTriggered = true;

        // Spela animationen (den går från stängd → öppen → stängd)
        animator.SetTrigger("Open");

        // Vänta tills luckan är öppen innan spelaren ska falla
        yield return new WaitForSeconds(disableColliderDelay);
        platformCollider.enabled = false;

        // Vänta tills animationen har gått klart och luckan stängt igen
        yield return new WaitForSeconds(enableColliderDelay);
        platformCollider.enabled = true;

        // Gör redo för att kunna användas igen
        isTriggered = false;
    }
}


