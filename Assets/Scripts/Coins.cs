using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField] private AudioClip _coinSFX;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            GuiManager.Instance.UpdateCoins();
            SoundManager.Instance.ReproduceSound(_coinSFX);
            Debug.Log("Adios");
            Destroy(gameObject);
        }
    }
}
