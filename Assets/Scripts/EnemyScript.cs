using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    private Rigidbody2D _rigidBody;
    [SerializeField] private float _enemyVelocity = 2;
    private PlayerController _playerController;
    public int direction;
    public float _attackDamage = 10;
    [SerializeField] private float _enemyHealth = 20; 
    private Animator _animator;

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();    
    }

     void FixedUpdate()
    {
        _rigidBody.linearVelocity = new Vector2(_enemyVelocity * direction, _rigidBody.linearVelocity.y);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Limit" && direction == 1)
        {
            direction = -1;
        }
        else if(collision.gameObject.tag == "Limit" && direction == -1)
        {
            direction = 1;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            _animator.SetTrigger("Attack");
            _playerController.TakeDamage(_attackDamage);
        }
        
        if(collision.gameObject.tag == "Limit" && direction == 1)
        {
            direction = -1;
        }
        
        else if(collision.gameObject.tag == "Limit" && direction == -1)
        {
            direction = 1;
        }
    }

    public void TakeDamage(float damage)
    {
        _enemyHealth -= damage;
        if(_enemyHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        Destroy(gameObject);
    }

}
