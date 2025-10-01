using UnityEngine;

public class Star : MonoBehaviour
{
    //GameManager _gameManager;
    [SerializeField] private AudioClip _starsfx;

    void Awake()
    {
        //_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public void Interaction()
    {
        //_gameManager.AddStar();
        GameManager.instance.AddStar();
        AudioManager.instance.ReproduceSound(_starsfx);
        Debug.Log("Adios");
        Destroy(gameObject);
    }
}
