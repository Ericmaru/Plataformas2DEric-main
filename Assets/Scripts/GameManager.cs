using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    int _stars = 0;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }


    void Start()
    {

    }

    void Update()
    {

    }

    public void AddStar()
    {
        _stars++;
        Debug.Log("Estrellas recogidas" + _stars);
    }


}
