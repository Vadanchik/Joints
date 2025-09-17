using System;
using System.Drawing;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private bool _isLeftMouseClick => Input.GetMouseButtonDown(0);

    private void Update()
    {
        if (_isLeftMouseClick)
        {
            Vector3 mousePosition = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            RaycastHit hit;
            float maxDistance = 100;

            if (Physics.Raycast(ray, out hit, maxDistance) && hit.collider.TryGetComponent(out IInteractable interactable))
            {
                interactable.Interact();
            }
        }
    }
}
