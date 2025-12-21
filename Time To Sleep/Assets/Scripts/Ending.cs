using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class Ending : MonoBehaviour, IInteractable
{
    [SerializeField] float endGameInSeconds = 1f;
    [SerializeField] UnityEvent thingsToHappen;
    void IInteractable.Interact(GameObject interactor)
    {
        Debug.Log("Interacted with ending game object.");
        thingsToHappen?.Invoke();
        StartCoroutine(ExitApplicationTimer(endGameInSeconds));
    }
    IEnumerator ExitApplicationTimer(float time)
    {
        yield return new WaitForSeconds(time);
        Debug.Log("Game closed!");
        Application.Quit();
    }
}