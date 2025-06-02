using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ServiceLocator.UI
{
    public class MonkeyImageHandler : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerDownHandler
    {
        private Image monkeyImage;
        private MonkeyCellController owner;
        private Sprite spriteToSet;
        private RectTransform rectTransform;
        private Vector3 origialPosition;
        private Vector3 originalAnchoredPosition;

        public void ConfigureImageHandler(Sprite spriteToSet, MonkeyCellController owner)
        {
            this.spriteToSet = spriteToSet;
            this.owner = owner;
        }

        private void Awake()
        {
            monkeyImage = GetComponent<Image>();
            monkeyImage.sprite = spriteToSet;
            rectTransform = GetComponent<RectTransform>();
            origialPosition = rectTransform.position;
            originalAnchoredPosition = rectTransform.anchoredPosition;
        }
        public void OnDrag(PointerEventData eventData)
        {
            // Vector2 localPoint;
            // RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform.parent as
            //    RectTransform, eventData.position,
            //    eventData.pressEventCamera, //another way 1
            //    out localPoint);
            // rectTransform.localPosition = localPoint;

            //rectTransform.anchoredPosition += eventData.delta;//outscal way but delay
            rectTransform.position = Input.mousePosition;//another way 2
            owner.MonkeyDraggedAt(rectTransform.position);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            RestMonkey();
            owner.MonkeyDroppedAt(eventData.position);
        }
        private void RestMonkey()
        {
            rectTransform.position = origialPosition;
            rectTransform.anchoredPosition = originalAnchoredPosition;
            GetComponent<LayoutElement>().enabled = false;
            GetComponent<LayoutElement>().enabled = true;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            monkeyImage.color = new Color(1, 1, 1, 0.6f);
        }
    }
}