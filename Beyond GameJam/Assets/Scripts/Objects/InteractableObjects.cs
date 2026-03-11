using UnityEngine;

public class InteractableObjects : MonoBehaviour, IInteractables
{
    public void Interact()
    {
        Debug.Log("has interacted");
    }

    public void OffFocus()
    {
        Debug.Log("not looked");
    }

    public void OnFocus()
    {
        Debug.Log("is looked");
    }
}
