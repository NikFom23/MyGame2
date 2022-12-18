using UnityEngine;

namespace enemy
{
    public class EnemyTrigger : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private string _tag;
        [SerializeField] private Transform _gameObject;

        private Transform _target;
        private Vector3 _destination;
        private SpriteRenderer _sprite;
        private float _angle;

        private bool _atack = false;

        private void Start()
        {
            _sprite = GetComponent<SpriteRenderer>();
            _gameObject = GetComponent<Transform>();


        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag(_tag))
            {
                _atack = true;
            }
        }

        private void FixedUpdate()
        {
            
            if (_atack == true)
            {
                RayCast();
                Run();
                SpriteReflect();
            }
        }

        private void RayCast() 
        {
            Ray ray = new Ray(transform.position, _gameObject.position);
            Debug.DrawRay(transform.position, _gameObject.position, Color.red);
        }

        private void Run()
        {
            _target = GameObject.FindGameObjectWithTag(_tag).GetComponent<Transform>();
            transform.position = Vector2.MoveTowards(transform.position, _target.position, Time.deltaTime * _speed);
        }

        private void SpriteReflect()
        {
            if (_atack == true)
            {
                _sprite.flipX = true;
            }
            else if (_atack != true)
            {
                _sprite.flipX = false;
            }
        }


    }

}
