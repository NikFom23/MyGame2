using UnityEngine;

namespace Gun {

    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Rigidbody2D))]

    public class Gun : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private Transform _player;
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform _firePoint;
        [SerializeField] private float _bulletForce;

        private Vector2 _mousePosition;
        private Rigidbody2D _rigidBody;
        private SpriteRenderer _sprite;

        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
            _sprite = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            GunPosition();
            Shooting();
        }

        private void FixedUpdate()
        {
            LookAtMouse();
            SpriteReflect();
        }

        private void GunPosition()
        {
            transform.position = new Vector3(_player.position.x , _player.position.y, transform.position.z);
        }

        private void Shooting()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                GameObject bullet = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
                Rigidbody2D rb =bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(_firePoint.position * _bulletForce, ForceMode2D.Impulse);
            }
        }

        private void LookAtMouse()
        {
            _mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            Vector2 lookDir = _mousePosition - _rigidBody.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
            _rigidBody.rotation = angle;
        }

        private void SpriteReflect()
        {
            if (_rigidBody.rotation > 90f || _rigidBody.rotation < -90f)
            {
                _sprite.flipY = true;
            }
            else if (_rigidBody.rotation < 90f || _rigidBody.rotation > -90f)
            {
                _sprite.flipY = false;
            }
        }
    }
}