using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PGUINak : MonoBehaviour
{
	////////////////////////////////////////////////////////////////////////////////////////////////
	// variable
	public Text _nakMessageText = null;
	public Image _nakImage = null;

	////////////////////////////////////////////////////////////////////////////////////////////////
	// method
	private void Awake()
	{
		PGUIManager.RegisterUIEvent<eSymbolNum>("UIEvent_SendNakSymbol", SendNakMessage);
		PGUIManager.RegisterUIEvent<string>("UIEvent_SendNakMessage", SendNakMessage);
	}

	public void SendNakMessage(eSymbolNum symbol)
	{
		// 임시입니다
		Dictionary<eSymbolNum, string> dic = new Dictionary<eSymbolNum, string>
		{
			{ eSymbolNum.ProcessSuccess, "성공!!" },
		};

		_nakMessageText.text = dic[symbol];
		DotweenSequence();
	}

	public void SendNakMessage(string message)
	{
		_nakMessageText.text = message;
		DotweenSequence();
	}

	private void DotweenSequence()
	{
		DOTween.Sequence()
			.OnStart(() => { _nakMessageText.color = Color.white; })
			.Append(_nakMessageText.DOFade(0, 2f).SetEase(Ease.InBack));

		DOTween.Sequence()
			.OnStart(() => { _nakImage.transform.localScale = new Vector2(0.8f, 0.8f); })
			.Append(_nakImage.transform.DOScale(Vector3.one, 0.3f).SetEase(Ease.OutBack));

		DOTween.Sequence()
			.OnStart(() => { _nakImage.color = new Color32(0, 0, 0, 200); })
			.Append(_nakImage.DOFade(0, 2f).SetEase(Ease.InBack));
	}
}
