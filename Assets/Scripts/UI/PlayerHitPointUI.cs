using UnityEngine;
using UnityEngine.UI;

public class PlayerHitPointUI : MonoBehaviour
{
    public Image hitPointBar;

    private void OnEnable()
    {
        EventBus.Subscribe("PlayerHitPointChanged", OnHitPointChanged);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe("PlayerHitPointChanged", OnHitPointChanged);
    }

    private void OnHitPointChanged(object value)
    {
        hitPointBar.fillAmount = (float)value;
    }
}
