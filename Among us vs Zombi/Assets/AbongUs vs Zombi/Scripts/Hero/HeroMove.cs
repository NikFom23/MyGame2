using UnityEngine;

namespace Hero {

    public class HeroMove : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Camera _camera;
        [SerializeField] private Rigidbody2D _gunPosition;


        private Vector2 _movement;
        private Animator _animator;
        private Rigidbody2D _rigidBody;
        private SpriteRenderer _spriteRenderer;


        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            ReadKey();
            SpriteAnimator();        
        }


        private void FixedUpdate()
        {
            Move();
            SpriteReflectX();
        }



        private void SpriteAnimator()
        {
            _animator.SetBool("is-running", _movement.x != 0 || _movement.y != 0);
        }

        private void ReadKey()
        {
            _movement.x = Input.GetAxisRaw("Horizontal");
            _movement.y = Input.GetAxisRaw("Vertical");
        }

        private void Move()
        {
            _rigidBody.MovePosition(_rigidBody.position + _movement * _speed * Time.deltaTime);

        }

        private void SpriteReflectX()
        {
            if (_gunPosition.rotation > 90f || _gunPosition.rotation < -90f)
            {
                _spriteRenderer.flipX = true;
            }
            else if (_gunPosition.rotation < 90f || _gunPosition.rotation > -90f)
            {
                _spriteRenderer.flipX = false;
            }
        }
    

    }

}