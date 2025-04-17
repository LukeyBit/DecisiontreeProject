using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ToolTipHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler {
    GameObject toolTipPrefab;
    GameObject toolTipTextBox;
    TMP_Text toolTipText;
    
    public void Init(){
        toolTipPrefab = GameObject.FindGameObjectWithTag("ToolTip");
        if (toolTipPrefab == null) {
            Debug.LogError("ToolTip prefab not found in the scene.");
            return;
        }
        toolTipTextBox = toolTipPrefab.transform.Find("TextBox").gameObject;
        if (toolTipTextBox == null) {
            Debug.LogError("ToolTip TextBox not found in the ToolTip prefab.");
            return;
        }
        toolTipText = toolTipTextBox.GetComponentInChildren<TMP_Text>();
        if (toolTipText.text == null) {
            Debug.LogError("ToolTip TextBox does not have a TMP_Text component.");
            return;
        }
        toolTipTextBox.SetActive(true);
    }

    void Awake() {
        Init();
    }

    public void ShowToolTip(string message) {
        if (toolTipText == null) {
            Debug.LogError("ToolTip TextBox does not have a TMP_Text component.");
            return;
        }
        toolTipText.text = message;
        toolTipTextBox.SetActive(true);
        toolTipTextBox.transform.SetAsLastSibling();

        Debug.Log("Showing tooltip: " + message);

        RectTransform rectTransform = toolTipTextBox.GetComponent<RectTransform>();
        Vector2 anchoredPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        rectTransform.anchoredPosition = anchoredPosition;
        rectTransform.sizeDelta = new Vector2(toolTipText.preferredWidth + 20, toolTipText.preferredHeight + 20);
        Debug.Log("Tooltip size: " + rectTransform.sizeDelta);
        Debug.Log("Tooltip position: " + rectTransform.anchoredPosition);
    }

    public void HideToolTip() {
        toolTipTextBox.SetActive(false);
        Debug.Log("Hiding tooltip");
    }

    public void UpdateToolTip(string message) {
        toolTipText.text = message;
        RectTransform rectTransform = toolTipTextBox.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(toolTipText.preferredWidth + 20, toolTipText.preferredHeight + 20);
    }

    public void UpdateToolTipPosition() {
        RectTransform rectTransform = toolTipTextBox.GetComponent<RectTransform>();
        Vector2 anchoredPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        rectTransform.anchoredPosition = anchoredPosition;
    }

    public void OnPointerEnter(PointerEventData eventData) {
        ShowToolTip("Tooltip message here");
    }

    public void OnPointerExit(PointerEventData eventData) {
        HideToolTip();
    }

    public void OnPointerMove(PointerEventData eventData) {
        UpdateToolTipPosition();
    }
}
