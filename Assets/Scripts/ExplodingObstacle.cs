using UnityEngine;

public class ExplodingObstacle : Obstacle
{
    [SerializeField] private GameObject explosionEffect;

    internal override void OnCollision(Collision collision)
    {
        base.OnCollision(collision);

        if (explosionEffect != null)
        {
            GameObject effect = Instantiate(
                explosionEffect,
                transform.position,
                Quaternion.identity
            );

            Destroy(effect, 2f);
        }

        Destroy(gameObject);
    }
}