using UnityEngine;

namespace enemy
{
    public class EnemyTrigger : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private string _tag;

        private Transform _target;
        private Vector3 _destination;

        private bool _atack = false;


        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.CompareTag(_tag))
            {
                _atack= true;
            }
        }

        private void Update()
        {
            if (_atack == true)
            {
                _target = GameObject.FindGameObjectWithTag(_tag).GetComponent<Transform>();
                _destination = new Vector3(_target.position.x, _target.position.y, transform.position.z);

                transform.position = Vector3.Lerp(transform.position, _destination, Time.deltaTime * _speed);
            }
        }
    }

}
