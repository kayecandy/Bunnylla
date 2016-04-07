using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class AnalogController : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {

    private Image background;
    private Image analogStick;
    private Vector3 analogPosition;

    void Start()
    {
        background = GetComponent<Image>();
        analogStick = transform.GetChild(0).GetComponent<Image>();
    }

    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        analogStick.rectTransform.anchoredPosition = new Vector3(0,0,0);
        analogPosition = new Vector3(0, 0, 0);
    }

    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 pos;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(background.rectTransform, ped.position, ped.pressEventCamera, out pos))
        {
            pos.x = (pos.x / background.rectTransform.sizeDelta.x)*2;
            pos.y = (pos.y / background.rectTransform.sizeDelta.y)*2;

            analogPosition = new Vector3(pos.x, pos.y);
            analogPosition = (analogPosition.magnitude > 1f) ? analogPosition.normalized : analogPosition;

            analogStick.rectTransform.anchoredPosition = new Vector3(
                analogPosition.x * background.rectTransform.sizeDelta.x/3,
                analogPosition.y * background.rectTransform.sizeDelta.y/3
                );
        }
    }

    public Vector3 getPosition()
    {
        return analogPosition;
    }
}
