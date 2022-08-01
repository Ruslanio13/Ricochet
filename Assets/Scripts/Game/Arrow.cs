using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private SpriteRenderer _spriteArrow;
    private float _destinationX;
    private float _destinationY;

    private void Start()
    {
        ArrowButton.instance.SetArrow(this);
    }

    public void UpdateArrow()
    {
        _spriteArrow.enabled = true;
        _destinationX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.parent.position.x;
        _destinationY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.parent.position.y;
        transform.eulerAngles = new Vector3(0, 0, (Mathf.Atan(_destinationY / _destinationX) * 180 / Mathf.PI));
        if (_destinationX < 0)
            transform.eulerAngles += new Vector3(0, 0, 180f);
    }

    public void SelectDirection()
    {
        _player.SetDirection(new Vector3(_destinationX, _destinationY).normalized);
        gameObject.SetActive(false);
    }
}
