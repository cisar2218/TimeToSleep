using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    [SerializeField] Animator animator;
    bool canKill = false;
    void IInteractable.Interact(GameObject interactor)
    {
        Kill();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        canKill = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        canKill = false;
    }

    public void Kill()
    {
        if (!canKill) return;

        animator.SetTrigger("death");
        DisableNpc();
    }



    private void DisableNpc()
    {
        canKill = false;

        // Disable collider so it no longer triggers interactions
        var collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            collider.enabled = false;
        }

        // Stop further script logic
        enabled = false;
    }
}
