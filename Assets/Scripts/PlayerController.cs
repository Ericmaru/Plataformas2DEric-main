
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    int vida = 50;

    private Rigidbody2D _rigidBody;

    private InputAction _moveAction;
    private Vector2 _moveInput;
    [SerializeField] private float _playerVelocity = 5;

    private InputAction _jumpAction;
    [SerializeField] private float _jumpForce = 7;
    private float jumpHeight = 2;

    private bool _alreadyLanded = true;

    private InputAction _attackAction;

    private GroundSensor _groundSensor;

    private Animator _animator;

    private InputAction _interAction;

    [SerializeField] private Vector2 _interactionZone = new Vector2(1, 1);

    [SerializeField] private Transform _sensorPosition;
    [SerializeField] private Vector2 _sensorSize = new Vector2(0.5f, 0.5f);
    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _groundSensor = GetComponentInChildren<GroundSensor>();
        _animator = GetComponent<Animator>();
        _moveAction = InputSystem.actions["Move"];
        _jumpAction = InputSystem.actions["Jump"];
        _attackAction = InputSystem.actions["Attack"];
        _interAction = InputSystem.actions["Interact"];
    }

    void Start()
    {

    }

    void Update()
    {
        _moveInput = _moveAction.ReadValue<Vector2>();
        Debug.Log(_moveInput);
        //transform.position = transform.position + new Vector3(_moveInput.x, 0, 0) * _playerVelocity * Time.deltaTime;

        if (_jumpAction.WasPressedThisFrame() && isGrounded())
        {
            Jump();
        }

        Movement();

        _animator.SetBool("IsJumping", !isGrounded());
    }

    void Interact()
    {
        //Debug.Log("haciendo cosas");
        Collider2D[] interactables = Physics2D.OverlapBoxAll(transform.position, _interactionZone, 0);
        foreach (Collider2D item in interactables)
        {
            
            if (item.gameObject.tag == "Star")
            {
                Star starScript = item.gameObject.GetComponent<Star>();
            
                if (starScript != null)
                {
                    starScript.Interaction();
                }
            }
        
        }
    }


    void Jump()
    {
        Debug.Log("salto");
        _rigidBody.AddForce(transform.up * Mathf.Sqrt(jumpHeight * -2 * Physics2D.gravity.y), ForceMode2D.Impulse);
        

    }

    void FixedUpdate()
    {
        _rigidBody.linearVelocity = new Vector2(_playerVelocity * _moveInput.x, _rigidBody.linearVelocity.y);
    }

    bool isGrounded()
    {
        Collider2D[] ground = Physics2D.OverlapBoxAll(_sensorPosition.position, _sensorSize, 0);
        foreach (Collider2D item in ground)
        {
            if (item.gameObject.layer == 3)
            {
                return true;
            }
        }

        return false;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(_sensorPosition.position, _sensorSize);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, _interactionZone);
    }

    void Movement()
    {
        if (_moveInput.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            _animator.SetBool("IsMoving", true);
        }
        else if (_moveInput.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            _animator.SetBool("IsMoving", true);
        }
        else
        {
            _animator.SetBool("IsMoving", false);
        }
    }
}
