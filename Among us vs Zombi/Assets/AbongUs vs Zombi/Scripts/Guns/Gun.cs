using System.Collections;
using UnityEngine;

namespace Guns {

    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Rigidbody2D))]

    public class Gun : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private Transform _player;
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform _firePoint;
        [SerializeField] private float _bulletForce;
        [SerializeField] private float _bulletTime;

        private Vector2 _mousePosition;
        private Rigidbody2D _rigidBody;
        private SpriteRenderer _sprite;
        private float _nextShoot;

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
            if (Input.GetButton("Fire1") || Input.GetButtonDown("Fire1"))
                if (_nextShoot <= 0)
                {
                    GameObject bullet = Instantiate(_bulletPrefab, _firePoint.position, transform.rotation);
                    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                    rb.AddForce(_firePoint.up * _bulletForce, ForceMode2D.Impulse);
                    _nextShoot = _bulletTime;
                }
                else
                {
                    _nextShoot -= Time.deltaTime;
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