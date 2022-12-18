using UnityEngine;
using UnityEngine.Events;

public class SpriteAnimation : MonoBehaviour
{
    [SerializeField] private int _frameRate;
    [SerializeField] private bool _loop;
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private UnityEvent _action;


    private float _nextFrameTime;
    private int _currentSprite;
    private float _secondsPerFrame;
    private SpriteRenderer _renderer;

    private bool _isPlaying = true;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        _secondsPerFrame = 1f / _frameRate;
        _nextFrameTime = Time.time  + _secondsPerFrame;
        _currentSprite = 0;
    }

    private void Update()
    {
        if (!_isPlaying || _nextFrameTime > Time.time) return;

        if (_currentSprite >= _sprites.Length)
        {
            if(_loop)
            {
                _currentSprite = 0;
            }
            else
            {
                _isPlaying = false;
                _action?.Invoke();
                return;
            }
        }

        _renderer.sprite = _sprites[_currentSprite];
        _nextFrameTime += _secondsPerFrame;
        _currentSprite++;
    }

  
}