using UnityEngine;

namespace Gun
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(CapsuleCollider2D))]

    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Transform _position;
        [SerializeField] private float _spead;

        private Rigidbody2D _rigidBody;
        private Collider2D _collider;

        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
            _collider = GetComponent<Collider2D>();
        }


        private void FixedUpdate()
        {
                
        }

    }

}