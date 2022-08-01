using UnityEngine;
using UnityEngine.EventSystems;

public class ArrowButton : MonoBehaviour, IUpdateSelectedHandler, IPointerDownHandler, IPointerUpHandler
{
    public bool isPressed;
    private Arrow _arrow;
    public static ArrowButton instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void OnUpdateSelected(BaseEventData data)
    {
        if (isPressed)
        {
            _arrow.UpdateArrow();
        }
    }
    public void OnPointerDown(PointerEventData data)
    {
        isPressed = true;
    }
    public void OnPointerUp(PointerEventData data)
    {
        isPressed = false;
        _arrow.SelectDirection();
        gameObject.SetActive(false);
    }

    public Arrow SetArrow(Arrow arrow) => _arrow = arrow;
    public void EnableButton() => gameObject.SetActive(true);
}
