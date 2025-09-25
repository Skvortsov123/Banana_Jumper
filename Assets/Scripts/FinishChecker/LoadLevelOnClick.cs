using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadLevelOnClick : MonoBehaviour
{
    [SerializeField] string levelNameToLoad;
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
        LoadLevel(levelNameToLoad);
    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName); // use your scene name
    }
}
