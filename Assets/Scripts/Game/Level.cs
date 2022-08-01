using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour
{
    [SerializeField] private int _amountAimRicochet;
    [SerializeField] private int _levelNumber;
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _finish;

    public int GetAmountAimRicochet() => _amountAimRicochet;

    public Player GetPlayer() => _player;

    private const int _speedTransition = 25; 

    public IEnumerator SmoothTransition()
    {
        var x = _finish.transform.localPosition.x;
        var y = _finish.transform.localPosition.y;
        Vector3 _dir;
        if (Mathf.Abs(x) > Mathf.Abs(y))
            _dir = new Vector3(x, 0, 0).normalized;
        else _dir = new Vector3(0, y, 0).normalized;
        var _timer = Time.time;
        while (Time.time - _timer < .25f)
        {
            gameObject.transform.position -= _dir * Time.deltaTime * _speedTransition;
            yield return new WaitForEndOfFrame();
        }
        LevelLoader.levelLoader.LoadLevel();
        gameObject.SetActive(false);
    }
}
