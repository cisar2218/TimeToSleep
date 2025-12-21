using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class QuitGame : MonoBehaviour
{
    public void Quit(InputAction.CallbackContext context)
    {
        Application.Quit();
    }
}