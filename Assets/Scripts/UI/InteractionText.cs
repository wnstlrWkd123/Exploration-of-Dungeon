using UnityEngine;
using UnityEngine.UI;

public class InteractionTextUI : MonoBehaviour
{
    [SerializeField] private Text text;

    private void OnEnable()
    {
        EventBus.Subscribe("InteractionText", SetActive);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe("InteractionText", SetActive);
    }

    public void SetActive(object flag)
    {
        text.gameObject.SetActive((bool)flag);
    }
}
