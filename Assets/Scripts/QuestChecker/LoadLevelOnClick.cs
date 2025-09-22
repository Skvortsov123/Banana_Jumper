using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadLevelOnClick : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        Debug.Log("Object clicked!");
        LoadLevel("Level2");
    }

    void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName); // use your scene name
    }
}
