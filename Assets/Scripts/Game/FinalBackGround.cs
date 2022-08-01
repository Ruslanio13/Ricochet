using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FinalBackGround : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _image;
    [SerializeField] private float _speedAppearing;
    private Color red = new Color(159f / 255, 43f / 255, 43f / 255, 0f);

    public IEnumerator SmoothApperaring()
    {
        _image.color = red;
        while (_image.color.a < 180f / 255)
        {
            _image.color += new Color(0, 0, 0, 1f / 255) * _speedAppearing;
            yield return new WaitForEndOfFrame();
        }
    }

    public void HideBackGround()
    {
        StopCoroutine(SmoothApperaring());
        _image.color = Color.clear;
    }
}
