using UnityEngine;

namespace enemy
{
    public class EnemyTrigger : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private string _tag;
        [SerializeField] private Vector3 _gameObject;

        private Transform _target;
        private Vector3 _destination;
        private SpriteRenderer _sprite;
        private float _angle;
        private Rigidbody2D _rigidBody;

        private bool _atack = false;

        private void Start()
        {
            _sprite = GetComponent<SpriteRenderer>();
            _rigidBody = GetComponent<Rigidbody2D>();

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag(_tag))
            {
                _atack = true;
            }
        }

        private void Update()
        {
            if (_atack == true)
            {
                
              
            }

        }

        private void FixedUpdate()
        {
            
            if (_atack == true)
            {
                Run();
            }
        }


        private void Run()
        {
            _target = GameObject.FindGameObjectWithTag(_tag).GetComponent<Transform>();
            _destination = Vector2.MoveTowards(transform.position, _target.position, Time.deltaTime * _speed);
            _rigidBody.MovePosition(_destination);
        }

        




    }

}
