using UnityEngine;

public class Killzone : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint; // Spawn point för spelaren

    void OnTriggerEnter2D(Collider2D other) // Spelaren dör om den kolliderar med killzonen
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = spawnPoint.position; // Flytta spelaren till spawnpunkten
            other.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero; // Nollställ spelarens hastighet
        }
    }
}
