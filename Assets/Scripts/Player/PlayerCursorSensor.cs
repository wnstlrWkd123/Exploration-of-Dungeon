using UnityEngine;

public class PlayerCursorSensor : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    private float maxDistance = 100f;

    public void IsInteraction(Ray ray)
    {
        if (Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance, layerMask))
        {
            float distance = Vector3.Distance(transform.position, hitInfo.point);
            if (distance <= 5f)
            {
                EventBus.Publish("InteractionText", true);
                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("올라타기에는 위험해 보이는 보트이다.");
                }
            }
            else
            {
                EventBus.Publish("InteractionText", false);
            }
        }
        else
        {
            EventBus.Publish("InteractionText", false);
        }
    }
}
