using UnityEngine;

public class ImageAnimation : MonoBehaviour
{
    [SerializeField] GameObject tar1, tar2;
    [SerializeField] float startSpeed, continueSpeed;
    [SerializeField] float distanceChangeDir;
    Vector3 currentTar;
    Vector3 tarPos1;
    Vector3 tarPos2;
    float speed;

    void Start()
    {
        tarPos1 = tar1.transform.position;
        tarPos2 = tar2.transform.position;
        currentTar = tarPos1;
        speed = startSpeed;
    }


    void Update()
    {   //ERROR: When changin window size, images flies random directions
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, currentTar, speed * Time.deltaTime);
        if (distance(gameObject.transform.position, currentTar) < distanceChangeDir)
        {
            changeCurrentTar();
            speed = continueSpeed;
        }
    }

    float distance(Vector2 vector1, Vector2 vector2) {
        return Mathf.Sqrt(Mathf.Pow(vector1.x - vector2.x, 2) + Mathf.Pow(vector1.y - vector2.y, 2));
    }

    void changeCurrentTar() {
        if (currentTar == tarPos1)
        {
            currentTar = tarPos2;
        }
        else
        {
            currentTar = tarPos1;
        }
    }
}
