using UnityEngine;

public class SkiTrailControl : MonoBehaviour
{
    [SerializeField] private TrailRenderer[] skiTrails;
    [SerializeField] private Rigidbody playerRigidbody;

    [Header("Ground Check")]
    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private float groundCheckDistance = 1.2f;

    [Header("Trail Settings")]
    [SerializeField] private float minSpeedForTrail = 0.5f;

    private bool wasGrounded = false;

    private void Awake()
    {
        if (playerRigidbody == null)
        {
            playerRigidbody = GetComponent<Rigidbody>();
        }
    }

    private void Update()
    {
        bool isGrounded = Physics.Linecast(
            transform.position,
            transform.position - transform.up * groundCheckDistance,
            groundLayers
        );

        float speed = playerRigidbody != null ? playerRigidbody.linearVelocity.magnitude : 0f;

        bool shouldEmit = isGrounded && speed > minSpeedForTrail;

        // Если игрок только что приземлился, очищаем trail,
        // чтобы не было длинной линии из воздуха до земли.
        if (isGrounded && !wasGrounded)
        {
            ClearTrails();
        }

        SetTrailEmission(shouldEmit);

        wasGrounded = isGrounded;
    }

    private void SetTrailEmission(bool value)
    {
        foreach (TrailRenderer trail in skiTrails)
        {
            if (trail != null)
            {
                trail.emitting = value;
            }
        }
    }

    private void ClearTrails()
    {
        foreach (TrailRenderer trail in skiTrails)
        {
            if (trail != null)
            {
                trail.Clear();
            }
        }
    }
}