using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum eSymbolNum
{
	ProcessSuccess = 0,     // 성공
	ProcessFail = 1,        // 단순 실패
}

public class PGCommon
{
	/// <summary>
	/// 씬 로드는 반드시 이 함수를 사용해야 한다.
	/// </summary>
	/// <param name="sceneName"></param>
	public static void LoadScene(string sceneName)
	{
		// 씬이 바뀔 때 해주어야 하는 것들..
		PGUIManager.ClearUIEvent();

		PGTimer.ResumeTime();

		SceneManager.LoadScene(sceneName);
	}

	/// <summary>
	/// 비동기 씬 로드시 이 함수를 사용해야 한다.
	/// </summary>
	/// <param name="sceneName"></param>
	/// <returns></returns>
	public static AsyncOperation LoadSceneAsync(string sceneName)
	{
		// 씬이 바뀔 때 해주어야 하는 것들..
		PGUIManager.ClearUIEvent();
		
		PGTimer.ResumeTime();

		return SceneManager.LoadSceneAsync(sceneName);
	}

	/// <summary>
	/// 게임 정상종료
	/// 데이터를 한번 더 저장하고 나가자
	/// </summary>
	public static void Quit()
	{
		Debug.Log("게임 정상종료");
		Application.Quit();
	}

	/// <summary>
	/// 게임 강제종료시
	/// 정상적으로 죽는것이 아니기 때문에 적절한 처리 필요
	/// </summary>
	public static void ForceQuit()
	{
		Debug.Log("강제로 죽습니다!! : " + StackTraceUtility.ExtractStackTrace());
		Application.Quit();
	}
}
