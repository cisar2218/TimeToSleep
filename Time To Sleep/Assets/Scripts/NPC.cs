using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    [SerializeField] Animator animator;
    bool canKill = false;
    bool canPickup = false;
    bool canPickupZone = false;
    bool alive = true;
    void IInteractable.Interact(GameObject interactor)
    {
        if (alive)
        {
            Kill();
        } else
        {
            PickUp(interactor);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (alive)
        {
            canKill = true;
        }
        
        if (canPickup)
        {
            canPickupZone = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (alive)
        {
            canKill = false;
        }
        if (canPickup)
        {
            canPickupZone = false;
        }
    }

    public void Kill()
    {
        if (!canKill) return;

        animator.SetTrigger("death");
        canKill = false;
    }

    public void KillAfterActions()
    {
        alive = false;
        // TODO spawn dead body
        canPickup = true;
        if (canKill) canPickupZone = true;
    }

    public void PickUp(GameObject interactor)
    {
        if (!canPickup || !canPickupZone) return;

        var tileBuilding = interactor.GetComponentInChildren<TileBuilding>();
        if (tileBuilding != null)
        {
            tileBuilding.AddBodiesToInventory();
        } else {
            Debug.LogError("TileBuilding not found: Cant be added to the inventory");
        }

        DisableNpc();
    }

    private void DisableNpc()
    {
        var collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            collider.enabled = false;
        }
        // PICKUP COMPLETE
        Destroy(gameObject);
    }
}
