using UnityEngine;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour, IPointerClickHandler
{
    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Vector3 localPoint;

        if (eventData.selectedObject != null)
        {
            return;
        }

        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(
            rectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out localPoint))
        {
            ICommand moveCommand = new MoveToCommand(localPoint, MoveController.Instance);
            GameEvents.RequestCommand(moveCommand);
        }
    }
}
