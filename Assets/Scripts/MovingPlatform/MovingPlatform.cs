using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform target1, target2; // Två målpositioner för plattformen att röra sig mellan
    [SerializeField] private float speed = 1f; // Hastigheten på plattformens rörelse
   
    private Transform currentTarget; // Det nuvarande målet som plattformen rör sig mot
    void Start()
    {
        currentTarget = target1; // Sätt det initiala målet till Target1
    }

   
    void FixedUpdate()
    {
        if(transform.position == target1.position) // Om plattformen når Target1
        {
            currentTarget = target2; // Sätt målet till Target2
        }
        else if(transform.position == target2.position) // Om plattformen når Target2
        {
            currentTarget = target1; // Sätt målet till Target1
        }
        transform.position = Vector2.MoveTowards(transform.position, currentTarget.position, speed * Time.fixedDeltaTime); // Flytta plattformen mot det nuvarande målet
    }
}
