using UnityEngine;
using UnityEngine.SceneManagement;
using System.Diagnostics;


public class MenuController : MonoBehaviour
{
    [SerializeField] string sceneToLoad;
        void Start()
    {

    }

    void Update()
    {

        //distance(image1.transform.position, image1TargetPosition);
        
    }

    

    // Buttons
    public void StartGame()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BetterGames()
    {
        Process.Start("steam://run/730");   //Works on Linux
    }
}
