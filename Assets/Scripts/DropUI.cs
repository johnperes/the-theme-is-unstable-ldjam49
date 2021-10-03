using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class DropUI : MonoBehaviour, IDropHandler
{
	[SerializeField]
	GameObject EletricPanel;

	#region IDropHandler implementation
	public void OnDrop(PointerEventData eventData)
	{
		SoundManager.Instance.Play("Switch");
		Core.Instance.Plug = true;
		if (Core.Instance.Switch && Core.Instance.Plug)
		{
			Core.Instance.CanAttack = true;
			Destroy(EletricPanel);
		}
		DragUI.itemBeingDragged.transform.SetParent(transform);
		DragUI.itemBeingDragged.transform.localPosition = Vector3.zero;
	}
	#endregion
}
