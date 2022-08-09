using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Vector3 _direction;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private List<Color> _colors = new List<Color>();
    [SerializeField] private SpriteRenderer _playerSkin;
    [SerializeField] private ParticleSystem _playerTrail;
    const float _moveSpeedConst = 3f;

    private void Start()
    {
        NormalizeTimeScale();
        ChangeColorTrail(_colors[PlayerPrefs.GetInt("SkinTRAIL", 3)]);
        _playerSkin.color = _colors[PlayerPrefs.GetInt("SkinBODY", 0)];
        _moveSpeed = 3f;
    }

    private void FixedUpdate()
    {
        _rigidbody2D.transform.position += _direction * _moveSpeed * Time.fixedDeltaTime;
    }

    public void SetDirection(Vector2 dir)
    {
        _direction = dir;
    }

    public Vector2 GetDirection() => _direction;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Vector2 collisionDirection = collision.GetContact(0).normal;
            if (Mathf.Abs(collisionDirection.x) >= .99 && collisionDirection.x * _direction.x < 0)
            {
                _direction.x *= -1;
                CounterCurrentRicochets.counterCurrentRicochets.UpdateAmountRicochets();
                AudioPlayer.audioPlayer.PlayerCollisionEffect();
            }
            else if (Mathf.Abs(collisionDirection.y) >= .99 && collisionDirection.y * _direction.y < 0)
            {
                _direction.y *= -1;
                CounterCurrentRicochets.counterCurrentRicochets.UpdateAmountRicochets();
                AudioPlayer.audioPlayer.PlayerCollisionEffect();
            }
        }
    }

    public void StopPlayer()
    {
        _moveSpeed = 0;
        _direction = Vector2.zero;
    }

    private void ChangeColorTrail(Color color)
    {
        var main = _playerTrail.main;
        main.startColor = new ParticleSystem.MinMaxGradient(color);
    }

    private void NormalizeTimeScale() => Time.timeScale = 1;

    public void PushPlayer(Vector3 dir) => _rigidbody2D.transform.position += dir;
}