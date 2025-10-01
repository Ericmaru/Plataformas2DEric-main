using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public bool _isPaused = false;

    [SerializeField] private GameObject _pauseCanvas;

    public InputActionAsset playerInputs;

    private InputAction _pauseInput;

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

        _pauseInput = InputSystem.actions["Pause"];
    }


    void Start()
    {

    }

    void Update()
    {
        if (_pauseInput.WasPressedThisFrame())
        {
            pause();
        }
    }

    public void AddStar()
    {
        _stars++;
        Debug.Log("Estrellas recogidas" + _stars);
    }

    public void pause()
    {
        if (_isPaused)
        {
            _isPaused = false;
            Time.timeScale = 1;
            GuiManager.Instance.ChangeCanvasStatus(GuiManager.Instance._pauseCanvas, false);
            playerInputs.FindActionMap("Player").Enable();
        }
        else
        {
            _isPaused = true;
            Time.timeScale = 0;
            GuiManager.Instance.ChangeCanvasStatus(GuiManager.Instance._pauseCanvas, true);
            playerInputs.FindActionMap("Player").Disable();
        }
    }


}
