using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] float interactionRange = 2f;
    [SerializeField] float pickUpRange = 2f;

    public void Interact(InputAction.CallbackContext context)
    {
        Collider2D[] potentialInteractables = Physics2D.OverlapCircleAll(transform.position, interactionRange); // TODO: Maybe  add a layer

        List<GameObject> interactables = new List<GameObject>();

        foreach (var item in potentialInteractables)
        {
            if (item.TryGetComponent<IInteractable>(out IInteractable interactable))
            {
                interactables.Add(item.gameObject);
            }
        }
        if (interactables.Count > 0)
        {
            GameObject closest = SelectClosestGameObject(interactables);
            closest.GetComponent<IInteractable>().Interact(closest);
        }
    }
    public void Pick(InputAction.CallbackContext context)
    {
        Collider2D[] potentialPickables = Physics2D.OverlapCircleAll(transform.position, pickUpRange); // TODO: Maybe  add a layer

        List<GameObject> pickables = new List<GameObject>();

        foreach (var item in potentialPickables)
        {
            if (item.TryGetComponent<IPickable>(out IPickable pickable))
            {
                pickables.Add(item.gameObject);
            }
        }
        if (pickables.Count > 0)
        {
            GameObject closest = SelectClosestGameObject(pickables);
            closest.GetComponent<IPickable>().Pick(closest);
        }
    }
    private GameObject SelectClosestGameObject(List<GameObject> list)
    {
        float distance = float.MaxValue;
        GameObject closest = null;

        foreach (var item in list)
        {
            Vector2 itemDirection = item.transform.position - transform.position;
            float itemDistance = itemDirection.magnitude;
            if (itemDistance < distance)
            {
                distance = itemDistance;
                closest = item;
            }
        }
        return closest;
    }
}