using UnityEngine;
using UnityEngine.Rendering;

public class MusicController : MonoBehaviour
{
    [SerializeField] AudioClip[] musicArray;
    AudioSource audioSource;
    int currentSongIndex;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentSongIndex = Random.Range(0, musicArray.Length);
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            nextSong();
        }
    }

    public void nextSong()
    {
        currentSongIndex++;
        if (currentSongIndex >= musicArray.Length) currentSongIndex = 0;
        setMusic(currentSongIndex);
    }

    void setMusic(int index)
    {
        audioSource.resource = musicArray[index];
        audioSource.Play(); // You should preload music so it does not freeze at new song
    }
}
