using UnityEngine;
using UnityEngine.UI;

public class GuiManager : MonoBehaviour
{
    public static GuiManager Instance;
    public GameObject _pauseCanvas;

    private Image _healthBar;

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
        _pauseCanvas.SetActive(status);
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


}
