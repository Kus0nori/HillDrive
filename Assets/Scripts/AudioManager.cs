using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private const float GasInputThreshold = 0.1f;
    private const float PitchChangeSpeed = 2f;
    private float _targetPitch;
    private float _currentPitch;
    [SerializeField] private AudioSource engineSound;
    [SerializeField] private AudioSource crackSound;
    [SerializeField] private AudioSource congratsSound;
    [SerializeField] private float minPitch = 0.6f;
    [SerializeField] private float maxPitch = 2.5f;
    public static AudioManager Instance;
    private bool _isMuted;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        engineSound.volume = 0.3f;
        _currentPitch = engineSound.pitch;
        _targetPitch = _currentPitch;
    }

    private void Update()
    {
        if (!GameManager.Instance.levelIsRunning)
        {
            engineSound.volume = 0f;
            _isMuted = true;
            return;
        }
        if (!_isMuted) return;
        engineSound.volume = 0.3f;
        _isMuted = false;
    }

    public void PlayCrackSound()
    {
        crackSound.Play();
    }
    
    public void ChangeEngineSound()
    {
        var horizontalInput = InputController.Instance.HorizontalInput;
        _targetPitch = horizontalInput > GasInputThreshold ? Mathf.Lerp(minPitch, maxPitch, horizontalInput) : minPitch;
        _currentPitch = Mathf.MoveTowards(_currentPitch, _targetPitch, PitchChangeSpeed * Time.deltaTime);
        engineSound.pitch = _currentPitch;
    }

    public void PlayCongratsSound()
    {
        congratsSound.Play();
    }
}
