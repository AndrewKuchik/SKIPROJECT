using UnityEngine;

public class SkiingSound : MonoBehaviour
{
    [SerializeField] private AudioSource skiAudioSource;
    [SerializeField] private Rigidbody rb;

    [SerializeField] private float minSpeed = 0.5f;
    [SerializeField] private float maxVolume = 0.35f;
    [SerializeField] private float fadeSpeed = 5f;

    private void Awake()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (skiAudioSource == null || rb == null)
            return;

        float speed = rb.linearVelocity.magnitude;

        if (!skiAudioSource.isPlaying)
            skiAudioSource.Play();

        float targetVolume = speed > minSpeed ? maxVolume : 0f;

        skiAudioSource.volume = Mathf.Lerp(
            skiAudioSource.volume,
            targetVolume,
            Time.deltaTime * fadeSpeed
        );
    }
}