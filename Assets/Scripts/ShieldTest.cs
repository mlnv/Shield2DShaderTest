using UnityEngine;
using System.Collections;
using DG.Tweening;

public class ShieldTest : MonoBehaviour
{
	Material _mat;

	void Awake()
	{
		_mat = GetComponent<SpriteRenderer>().material;
	}

	void Start()
	{
		_mat.SetFloat("_Fill", 0f);
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			EnableGlitch(0.5f);
			_mat.SetFloat("_DispIntensity", 0.07f);
			_mat.SetFloat("_ColorIntensity", 0.04f);
		}

		if (Input.GetKeyDown(KeyCode.S))
		{
			float time = 3f;
			DOTween.To(() => _mat.GetFloat("_Fill"), x => _mat.SetFloat("_Fill", x), 1f, time).SetEase(Ease.InOutCirc);
			EnableGlitch(time);
		}

		if (Input.GetKeyDown(KeyCode.D))
		{
			float time = 3f;
			DOTween.To(() => _mat.GetFloat("_Fill"), x => _mat.SetFloat("_Fill", x), 0f, time).SetEase(Ease.InOutCirc);
			EnableGlitch(time);
		}
	}

	void EnableGlitch(float time)
	{
		_mat.SetFloat("_DispIntensity", 0.07f);
		_mat.SetFloat("_ColorIntensity", 0.04f);

		Sequence s = DOTween.Sequence();
		s.AppendInterval(time);
		s.Play().OnComplete(()=>
		{
			_mat.SetFloat("_DispIntensity", 0f);
			_mat.SetFloat("_ColorIntensity", 0f);
			Debug.Log("Completed");
		});
	}
}
