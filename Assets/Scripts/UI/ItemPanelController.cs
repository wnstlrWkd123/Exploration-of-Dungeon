using UnityEngine;
using UnityEngine.UI;

public class ItemPanelController : MonoBehaviour
{
    public GameObject resourcePanel;
    public GameObject consumablePanel;

    [Header("Resource Panel UI")]
    public Text resourceNameText;
    public Text resourceDescriptionText;
    public Button resourceButton;

    [Header("Consumable Panel UI")]
    public Text consumableNameText;
    public Text consumableDescriptionText;
    public Button useButton;
    public Button cancelButton;

    private Item currentItem;

    private void OnEnable()
    {
        EventBus.Subscribe("ShowItemPanel", param =>
        {
            currentItem = param as Item;
            if (currentItem != null)
            {
                ShowCorrectPanel(currentItem.itemData);
            }
        });

        resourceButton.onClick.AddListener(() =>
        {
            resourcePanel.SetActive(false);
            Time.timeScale = 1f;
        });
        useButton.onClick.AddListener(() =>
        {
            ((ConsumableItem)currentItem).UseItem();
            consumablePanel.SetActive(false);
            Time.timeScale = 1f;
        });
        cancelButton.onClick.AddListener(() =>
        {
            consumablePanel.SetActive(false);
            Time.timeScale = 1f;
        });
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe("ShowItemPanel", param =>
        {
            currentItem = param as Item;
            if (currentItem != null)
            {
                ShowCorrectPanel(currentItem.itemData);
            }
        });
    }

    private void ShowCorrectPanel(ItemData data)
    {
        switch (data.itemType)
        {
            case ItemType.Resource:
                SetResourcePanel(data);
                break;
            case ItemType.Consumable:
                SetConsumablePanel(data);
                break;
        }
    }

    private void SetResourcePanel(ItemData data)
    {
        resourceNameText.text = data.itemName;
        resourceDescriptionText.text = data.description;
        Time.timeScale = 0f;
        resourcePanel.SetActive(true);
    }

    private void SetConsumablePanel(ItemData data)
    {
        consumableNameText.text = data.itemName;
        consumableDescriptionText.text = data.description;
        Time.timeScale = 0f;
        consumablePanel.SetActive(true);
    }
}
