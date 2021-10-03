using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	Image image;
	public static GameObject itemBeingDragged;
	Vector3 startPosition;
	Transform startParent;

	void Awake()
    {
		image = GetComponent<Image>();
	}

	#region IBeginDragHandler implementation
	public void OnBeginDrag(PointerEventData eventData)
	{
		itemBeingDragged = gameObject;
		startPosition = transform.position;
		startParent = transform.parent;
		GetComponent<CanvasGroup>().blocksRaycasts = false;
	}
	#endregion

	#region IDragHandler implementation

	public void OnDrag(PointerEventData eventData)
	{
		transform.position = eventData.position;
	}

	#endregion

	#region IEndDragHandler implementation
	public void OnEndDrag(PointerEventData eventData)
	{
		itemBeingDragged = null;
		GetComponent<CanvasGroup>().blocksRaycasts = true;
		if (transform.parent == startParent)
		{
			transform.position = startPosition;
		}
	}
	#endregion
}