using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PGMainCamera : MonoBehaviour
{
	private const float MAX_CAMERA_X_POS = 7.5f;

	#region Singleton
	public static PGMainCamera Instance { get; private set; }
	#endregion

	/// <summary>
	/// 카메라 움직일려면 반드시 이 함수 사용
	/// </summary>
	public void SetPos(Vector3 pos)
	{
		if (MAX_CAMERA_X_POS < Mathf.Abs(pos.x))
		{
			return;
		}

		this.transform.position = pos;
	}

	/// <summary>
	/// 카메라 좌우움직일때..
	/// </summary>
	public void OnDragCamera(float xDelta)
	{
		SetPos(this.transform.position + new Vector3(xDelta / 300f, 0, 0));
	}

	private void Awake()
	{
		Instance = this;
	}
}
