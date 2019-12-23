using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PGUITestBtn : MonoBehaviour, IDragHandler
{
	public void OnDrag(PointerEventData eventData)
	{
		PGMainCamera.Instance.OnDragCamera(-eventData.delta.x);
	}
	
}
