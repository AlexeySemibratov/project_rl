using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionRadius;
    [SerializeField] private LayerMask _interactionMask;

    private Collider2D[] _colliders;
    private IInteractable _interactable;

    void Update()
    {
        _colliders = Physics2D.OverlapCircleAll(_interactionPoint.position, _interactionRadius, _interactionMask);

        if(_colliders.Length > 0)
        {
            IInteractable newInteractable = NearestInteractable(_colliders);

            if (_interactable == null)
            {
                _interactable = newInteractable;
                _interactable.Select();
            }
            else if (_interactable != newInteractable) 
            { 
                _interactable.Deselect(); 
                _interactable = newInteractable;
                _interactable.Select();
            }
        }
        else if(_interactable != null) 
        { 
            _interactable.Deselect();
            _interactable = null; 
        }
    }

    public void Interact()
    {
        if(_interactable != null) { _interactable.Interact(); }
    }

    private IInteractable NearestInteractable(Collider2D[] colliders)
    {
        IInteractable interactable = null;
        float minDistance = 0;

        foreach(var collider in colliders)
        {
            float distance = Vector2.Distance(_interactionPoint.position, collider.transform.position);
            if (distance < minDistance || minDistance == 0) 
            {
                minDistance = distance;
                interactable = collider.GetComponent<IInteractable>();
            }
        }
        return interactable;
    }
}
