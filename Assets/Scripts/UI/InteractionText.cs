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

    public void SetActive(object flag)    // 나중에 텍스트별로 구분 가능하게(?)
    {
        text.gameObject.SetActive((bool)flag);    // 게임오브젝트 말고 Text자체를 끄는거랑은 뭐가 더 좋을까?
    }
}
