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
        _moveSpeed = _moveSpeedConst;
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
            CounterCurrentRicochets.counterCurrentRicochets.UpdateAmountRicochets();
            if (Mathf.Abs(collision.GetContact(0).normal.x) >= 1 - 1e-3)
                _direction.x *= -1;
            else if (Mathf.Abs(collision.GetContact(0).normal.y) >= 1 - 1e-3)
                _direction.y *= -1;
            Vector2 direction = collision.GetContact(0).normal;
            if (direction.x == 1) print("right");
            if (direction.x == -1) print("left");
            if (direction.y == 1) print("up");
            if (direction.y == -1) print("down");
        }
    }

    public void StopPlayer() =>_moveSpeed = 0;

    private void ChangeColorTrail(Color color)
    {
        var main = _playerTrail.main;
        main.startColor = new ParticleSystem.MinMaxGradient(color);
    }

    private void NormalizeTimeScale() => Time.timeScale = 1;
}