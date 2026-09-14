using UnityEngine;

public class MissDetector : MonoBehaviour
{
    public PlatformMovement playerPlatform;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Collectible collectible = other.GetComponent<Collectible>();

        if (collectible != null)
        {
            if (playerPlatform != null)
            {
                playerPlatform.LoseHalfPoints(collectible.pointValue);
            }

            Destroy(other.gameObject);
        }
    }
}
