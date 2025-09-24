using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    private Rigidbody2D _rigidBody;
    [SerializeField] private float _enemyVelocity = 2;

    public int direction;

    private Animator _animator;

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    
     void FixedUpdate()
    {
        _rigidBody.linearVelocity = new Vector2(_enemyVelocity * direction, _rigidBody.linearVelocity.y);
    }

}
