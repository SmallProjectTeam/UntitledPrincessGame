using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eActorStatus
{
	Idle = 0,
	Move = 1,
}

public class PGActorBase : MonoBehaviour
{
	[SerializeField] Transform _graphicTransform;
	[SerializeField] Animator _actorAnimator;

	public void MovePos(Vector3 pos) { this.transform.position += pos; }
	public Vector2 GetPos() { return this.transform.position; }
	public Vector2 GetGraphicPos() { return _graphicTransform.position; }

	/// <summary>
	/// 주의 : 액터 방향은 무조건 왼쪽이 default 이다!!
	/// </summary>
	public void SetDirection(bool isLeft)
	{
		Vector3 scaleVector = Vector3.one;

		if (false == isLeft) { scaleVector.x = -1; }

		_graphicTransform.localScale = scaleVector;
	}
	
	private float _charMoveSpeed = 0;
	private eActorStatus _currentStatus = eActorStatus.Idle;

	#region 임시 움직임 테스트
	protected IEnumerator ActorTestAIRoutine()
	{
		while (true)
		{
			PGUIManager.CallUIEvent<string>("UIEvent_SendNakMessage", "액터 시작합니다 : " + _currentStatus.ToString());

			switch (_currentStatus)
			{
				case eActorStatus.Idle:
					yield return IdleProcess();
					break;

				case eActorStatus.Move:
					yield return MoveProcess();
					break;
			}

			yield return null;
		}
	}

	protected IEnumerator MoveProcess()
	{
		_actorAnimator.Play(_currentStatus.ToString());

		// 랜덤한 방향으로 일정시간 움직임
		float randMoveTime = Random.Range(0.8f, 3f);
		int randDir = Random.Range(0, 2);

		while (0 < randMoveTime)
		{
			if (0 == randDir)
			{
				// 왼쪽으로 가버리기
				SetDirection(true);
				MovePos(Vector2.left * Time.deltaTime * _charMoveSpeed);
			}
			else
			{
				// 오른쪽으로 가버리기
				SetDirection(false);
				MovePos(Vector2.right * Time.deltaTime * _charMoveSpeed);
			}

			randMoveTime -= Time.deltaTime;
			yield return null;
		}

		// 쉼
		_currentStatus = eActorStatus.Idle;
	}

	protected IEnumerator IdleProcess()
	{
		_actorAnimator.Play(_currentStatus.ToString());

		// 랜덤하게 기달렷다가 움직인다.
		int randIdleTime = Random.Range(500, 2000);
		yield return PGTimer.PGWaitForSeconds(randIdleTime);
		_currentStatus = eActorStatus.Move;
	}
	
	private void Start()
	{
		_charMoveSpeed = 1;

		// 테스트코드
		StartCoroutine(ActorTestAIRoutine());
	}
	#endregion
}
