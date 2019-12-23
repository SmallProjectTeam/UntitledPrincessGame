using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PGTimer
{
	private static Dictionary<int, WaitForSeconds> _secondsList = new Dictionary<int, WaitForSeconds>();

	/// <summary>
	/// waitforseconds 는 꼭 이 함수를 사용하자.
	/// 1 / 1000 초 단위로 사용.
	/// </summary>
	public static WaitForSeconds PGWaitForSeconds(int time)
	{
		WaitForSeconds rv;

		if (false == _secondsList.TryGetValue(time, out rv))
		{
			rv = new WaitForSeconds(time / 1000f);
			_secondsList.Add(time, rv);
		}

		return rv;
	}

	public static void ResumeTime()
	{
		Time.timeScale = 1;
	}

	public static void StopTime()
	{
		Time.timeScale = 0;
	}

	/// <summary>
	/// 추후 흐름제어를 위해 timescale 은 이 함수를 꼭 쓰자.
	/// </summary>
	/// <param name="amount"></param>
	public static void ModifyTimeScale(float amount)
	{
		Time.timeScale = amount;
	}
}
