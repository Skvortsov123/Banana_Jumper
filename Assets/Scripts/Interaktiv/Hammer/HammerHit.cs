using UnityEngine;

public class HammerHit : MonoBehaviour
{
    [SerializeField] float delay;
    [SerializeField] float offsetDelay; //If few hammer, so they has some delay between hits, so they hits not exactly same time
    [SerializeField] float animationSpeed; //Needs for trigger to teleport to know exactly speed of animation
    [SerializeField] GameObject positionToTeleport;
    Animator anim;
    AudioSource audioSource;
    float timer1;
    bool activeHit;
    void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }


    void Update()
    {
        if (timer1 + delay < Time.time + offsetDelay)
        {
            timer1 = Time.time + offsetDelay;
            anim.SetTrigger("hit");
            audioSource.Play();
        }

        if (Time.time - timer1 > 0.2*animationSpeed && Time.time - timer1 < 0.4*animationSpeed)
        {
            activeHit = true;
        }
        else
        {
            activeHit = false;
        }
    }

    void OnTriggerStay2D(Collider2D other) {
        if (other.CompareTag("Player") && activeHit)
        {
            other.transform.position = positionToTeleport.transform.position;
        }
    }
}
