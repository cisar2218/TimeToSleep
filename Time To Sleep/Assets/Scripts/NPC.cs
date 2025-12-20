using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
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

        // TODO:
        // play kill animation
        // animate to dead body
        // remove this and other fluff
        Debug.Log("Killed!");
    }
}
