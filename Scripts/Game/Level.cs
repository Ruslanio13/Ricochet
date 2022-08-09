using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour
{
    [SerializeField] private int _amountAimRicochet;
    [SerializeField] private Player _player;
    [SerializeField] private Vector3 _directionTransition;

    public int GetAmountAimRicochet() => _amountAimRicochet;

    public Player GetPlayer() => _player;

    private const int _speedTransition = 25; 

    public IEnumerator SmoothTransition()
    {
        var camera = FindObjectOfType<Camera>();
        var _timer = Time.time;
        while (Time.time - _timer < .5f)
        {
            camera.transform.position += _directionTransition * Time.deltaTime * _speedTransition;
            yield return new WaitForEndOfFrame();
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
}
