using UnityEngine;

public class Star : MonoBehaviour
{
    //GameManager _gameManager;
    [SerializeField] private AudioClip _starsfx;

    public void Interaction()
    {
        GuiManager.Instance.UpdateStars();
        SoundManager.Instance.ReproduceSound(_starsfx);
        Debug.Log("Adios");
        Destroy(gameObject);
    }
}
