using System;
using UnityEngine;
using UnityEngine.UI;

public class AudioPlayer : MonoBehaviour
{
    public static AudioPlayer audioPlayer;
    [SerializeField] private AudioSource _coinPickUp;
    [SerializeField] private AudioSource _wallCollision;
    [SerializeField] private Button _audioButton;
    [SerializeField] private Image _effectsIcon;
    [SerializeField] private Sprite _effctsOn;
    [SerializeField] private Sprite _effctsOff;
    private bool isReadyToPlay;

    private void Awake()
    {
        if (audioPlayer == null)
            audioPlayer = this;
    }

    private void Start()
    {
        isReadyToPlay = Convert.ToBoolean(PlayerPrefs.GetInt("AudioAbbility", 1));
        _effectsIcon.sprite = isReadyToPlay ? _effctsOn : _effctsOff;
        _audioButton.onClick.AddListener(() => ChangeAudioPlayerAbility());
    }

    private void ChangeAudioPlayerAbility()
    {
        isReadyToPlay = !isReadyToPlay;
        PlayerPrefs.SetInt("AudioAbbility", Convert.ToInt32(isReadyToPlay));
        _effectsIcon.sprite = isReadyToPlay ? _effctsOn : _effctsOff;
    }

    public void CoinPickUpEffect()
    {
        if (isReadyToPlay)
            _coinPickUp.Play();
    }

    public void PlayerCollisionEffect()
    {
        if (isReadyToPlay)
            _wallCollision.Play();
    }
}
