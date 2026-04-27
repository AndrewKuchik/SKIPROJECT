using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip obstacleHitSound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        Obstacle.OnPlayerHit += PlayObstacleHitSound;
    }

    // Update is called once per frame
    private void PlayObstacleHitSound()
    {
        AudioSource.PlayOneShot(obstacleHitSound);
    }
}
