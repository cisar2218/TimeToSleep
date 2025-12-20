using UnityEngine;

public class FollowerLerp : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float followSpeed = 5f;

   private void OnValidate()
    {
        if (player == null)
        {
            Debug.LogError($"{name}: {nameof(player)} is required!", this);
        }
    }

    void FixedUpdate()
    {
        if (player == null) return;

        Vector3 targetPosition = player.position;
        // Keep the current Z so it doesn't drift in 2D
        targetPosition.z = transform.position.z;

        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            followSpeed * Time.deltaTime
        );
    }
}
