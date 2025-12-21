using System;
using TMPro;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public int currentResource;

    [SerializeField] TMP_Text currentResourceText;

    private void Start()
    {
        if (currentResourceText == null)
        {
            Debug.LogWarning("Resource text object is not assigned. The resource will not be displayed.");
            return;
        }
        DisplayUpdatedResource();
    }
    public void ChangeResource(int ammount)
    {
        currentResource += ammount;

        if (currentResourceText == null)
        {
            return;
        }
        DisplayUpdatedResource();
    }
    private void DisplayUpdatedResource()
    {
        currentResourceText.text = "Bodies: " + currentResource.ToString();
    }

    [ContextMenu("Add Resource")]
    private void ExampleResourceAdd()
    {
        ChangeResource(1);
    }
}