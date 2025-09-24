using UnityEngine;

public class Star : MonoBehaviour
{


    //GameManager _gameManager;
    [SerializeField] private AudioClip _starsfx;

    void Awake()
    {
        //_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Interaction()
    {
        //_gameManager.AddStar();
        GameManager.instance.AddStar();
        AudioManager.instance.ReproduceSound(_starsfx);
        Destroy(gameObject);
    }

}
