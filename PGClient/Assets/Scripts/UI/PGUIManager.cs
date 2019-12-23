using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// delegate 함수 리스트를 들고있는 구조체.
/// </summary>
public struct DelegateList
{
	public List<Delegate> _funcList;
	public List<Delegate> GetEventList() { return _funcList; }

	public void AddFunction<T>(T func)
	{
		if (null == _funcList)
		{
			_funcList = new List<Delegate>();
		}

		_funcList.Add(func as Delegate);
	}

	public bool IsEmpty()
	{
		if (null == _funcList)
		{
			return true;
		}

		if (_funcList.Count <= 0)
		{
			return true;
		}

		return false;
	}
}

public class PGUIManager
{
	// delegate 변수로 사용할 것들.
	public delegate void EventFunc();
	public delegate void EventFunc<T>(T param1);
	public delegate void EventFunc<T1, T2>(T1 param1, T2 param2);

	// 실제 ui event 함수들을 들고있는 dictionary
	private static Dictionary<int, DelegateList> _uiEventTable = null;

	////////////////////////////////////////////////////////////////////////////////////////////////
	// 주의 : 씬이 바뀔 때 ui event 는 모두 클리어된다.
	public static void ClearUIEvent()
	{
		if (null == _uiEventTable)
		{
			return;
		}

		_uiEventTable.Clear();
	}

	////////////////////////////////////////////////////////////////////////////////////////////////
	// UI 이벤트 호출 부분. 원하는 이벤트 이름과 인자로 전달할 내용을 전달하면 된다.
	public static void CallUIEvent(string eventName)
	{
		if (null == _uiEventTable)
		{
			return;
		}

		if (false == _uiEventTable.ContainsKey(eventName.GetHashCode()))
		{
			Debug.LogError("등록되지 않은 이벤트입니다 : " + eventName);
			return;
		}

		// 해당 이벤트에 달린 모든 함수를 실행.
		List<Delegate> eventList = _uiEventTable[eventName.GetHashCode()].GetEventList();
		foreach (EventFunc func in eventList)
		{
			func();
		}
	}

	public static void CallUIEvent<T>(string eventName, T param)
	{
		if (null == _uiEventTable)
		{
			return;
		}

		if (false == _uiEventTable.ContainsKey(eventName.GetHashCode()))
		{
			Debug.LogError("등록되지 않은 이벤트입니다 : " + eventName);
			return;
		}

		// 해당 이벤트에 달린 모든 함수를 실행.
		List<Delegate> eventList = _uiEventTable[eventName.GetHashCode()].GetEventList();
		foreach (EventFunc<T> func in eventList)
		{
			func(param);
		}
	}

	public static void CallUIEvent<T1, T2>(string eventName, T1 param1, T2 param2)
	{
		if (null == _uiEventTable)
		{
			return;
		}

		if (false == _uiEventTable.ContainsKey(eventName.GetHashCode()))
		{
			Debug.LogError("등록되지 않은 이벤트입니다 : " + eventName);
			return;
		}

		// 해당 이벤트에 달린 모든 함수를 실행.
		List<Delegate> eventList = _uiEventTable[eventName.GetHashCode()].GetEventList();
		foreach (EventFunc<T1, T2> func in eventList)
		{
			func(param1, param2);
		}

	}

	////////////////////////////////////////////////////////////////////////////////////////////////
	// UI 이벤트 등록 부분. 인자 개수에 따라서 다른 RegisterUIEvent 함수로 등록하면 된다.
	public static void RegisterUIEvent(string eventName, EventFunc func)
	{
		if (null == _uiEventTable)
		{
			_uiEventTable = new Dictionary<int, DelegateList>();
		}

		int eventHash = eventName.GetHashCode();

		// 이벤트가 아얘 없었으면 새로 할당해주어야 한다.
		if (false == _uiEventTable.ContainsKey(eventHash))
		{
			DelegateList list = new DelegateList();
			list.AddFunction<EventFunc>(func);

			_uiEventTable.Add(eventHash, list);
		}
		else
		{
			// 이벤트에 함수 추가.
			_uiEventTable[eventHash].AddFunction<EventFunc>(func);
		}
	}

	public static void RegisterUIEvent<T>(string eventName, EventFunc<T> func)
	{
		if (null == _uiEventTable)
		{
			_uiEventTable = new Dictionary<int, DelegateList>();
		}

		int eventHash = eventName.GetHashCode();

		// 이벤트가 아얘 없었으면 새로 할당해주어야 한다.
		if (false == _uiEventTable.ContainsKey(eventHash))
		{
			DelegateList list = new DelegateList();
			list.AddFunction<EventFunc<T>>(func);

			_uiEventTable.Add(eventHash, list);
		}
		else
		{
			// 이벤트에 함수 추가.
			_uiEventTable[eventHash].AddFunction<EventFunc<T>>(func);
		}
	}

	public static void RegisterUIEvent<T1, T2>(string eventName, EventFunc<T1, T2> func)
	{
		if (null == _uiEventTable)
		{
			_uiEventTable = new Dictionary<int, DelegateList>();
		}

		int eventHash = eventName.GetHashCode();

		// 이벤트가 아얘 없었으면 새로 할당해주어야 한다.
		if (false == _uiEventTable.ContainsKey(eventHash))
		{
			DelegateList list = new DelegateList();
			list.AddFunction<EventFunc<T1, T2>>(func);

			_uiEventTable.Add(eventHash, list);
		}
		else
		{
			// 이벤트에 함수 추가.
			_uiEventTable[eventHash].AddFunction<EventFunc<T1, T2>>(func);
		}
	}
}
