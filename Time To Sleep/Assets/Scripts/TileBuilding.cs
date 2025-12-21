using UnityEngine;
using UnityEngine.InputSystem;

public class TileBuilding : MonoBehaviour
{
    [SerializeField] GameObject bodyPrefab;
    [SerializeField] Transform whereToSpawn;
    [SerializeField] Vector2 force;
    [SerializeField] LayerMask blockingLayers;

    public int tilesToPlace = 0;

    public void AddBodiesToInventory()
    {
        tilesToPlace+=2;
    }
    public void PlaceBody(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        if (tilesToPlace <= 0) {
            Debug.Log("Not enough tiles to place");
            return;
        }
        
        if (bodyPrefab == null)
        {
            Debug.LogError("TileBuilding: bodyPrefab is not assigned.", this);
            return;
        }

        if (whereToSpawn == null)
        {
            Debug.LogError("TileBuilding: whereToSpawn is not assigned.", this);
            return;
        }


        GameObject bodyInstance = Instantiate(
            bodyPrefab,
            whereToSpawn.position,
            whereToSpawn.rotation
        );

        tilesToPlace--;

        Rigidbody2D rb = bodyInstance.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogWarning("TileBuilding: Instantiated bodyPrefab has no Rigidbody2D to apply force to.", bodyInstance);
            return;
        }
        rb.AddForce(force, ForceMode2D.Impulse);
    }
}
