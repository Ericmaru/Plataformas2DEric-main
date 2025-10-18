using UnityEngine;
using UnityEngine.UI;

public class GuiManager : MonoBehaviour
{
    public static GuiManager Instance;
    public GameObject _pauseCanvas;
    public GameObject _winCanvas;

    private Image _healthBar;

    [SerializeField] private Text _coinText;
    [SerializeField] private Text _starText;
    [SerializeField] private int _coin;
    [SerializeField] private int _star;


    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void ChangeCanvasStatus(GameObject canvas, bool status)
    {
        canvas.SetActive(status);
    }

    // Update is called once per frame
    public void Resume()
    {
        GameManager.instance.pause();
    }

    public void UpdateHealthBar(float currentHealth, float maxHealth)
    {
        _healthBar.fillAmount = currentHealth - maxHealth;
    }

    public void ChangeScene(string sceneName)
    {
        SceneLoad.Instance.ChangeScene(sceneName);
    }

    public void UpdateStars()
    {
        _star ++;
        _starText.text = "Stars: 0" + _star.ToString();

        if(_star >= 3)
        {
            ChangeCanvasStatus(_winCanvas, true);
        }
    }

    public void UpdateCoins()
    {
        _coin ++;
        _coinText.text = "Coins: 0" + _coin.ToString();
    }
}
