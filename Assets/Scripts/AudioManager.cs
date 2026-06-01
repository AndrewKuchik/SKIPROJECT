using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;

    [Header("Obstacle")]
    [SerializeField] private AudioClip obstacleHitSound;

    [Header("Flags")]
    [SerializeField] private AudioClip correctFlagSound;

    [SerializeField] private AudioClip correctSoundanother;
        
    [SerializeField] private AudioClip penaltySound;
    [SerializeField] private AudioClip penaltySoundanother;

    [Header("Race")]
    [SerializeField] private AudioClip finishSound;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        Obstacle.OnPlayerHit += PlayObstacleHitSound;
        SlalomFlag.CorrectFlagPassed += PlayCorrectFlagSound;
        SlalomFlag.RacePenalty += PlayPenaltySound;
        FinishGate.FinishRace += PlayFinishSound;
    }

    private void OnDisable()
    {
        Obstacle.OnPlayerHit -= PlayObstacleHitSound;
        SlalomFlag.CorrectFlagPassed -= PlayCorrectFlagSound;
        SlalomFlag.RacePenalty -= PlayPenaltySound;
        FinishGate.FinishRace -= PlayFinishSound;
    }

    private void PlayObstacleHitSound()
    {
        PlaySound(obstacleHitSound);
    }

    private void PlayCorrectFlagSound()
    {
        PlaySound(correctFlagSound);
        PlaySound(correctSoundanother);
    }

    private void PlayPenaltySound()
    {
        PlaySound(penaltySound);
        PlaySound(penaltySoundanother);
    }

    private void PlayFinishSound()
    {
        PlaySound(finishSound);
    }

    private void PlaySound(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}