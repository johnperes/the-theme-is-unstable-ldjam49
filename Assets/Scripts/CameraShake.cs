using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
	Transform CameraTransform;

	public float ShakeDuration = 0f;

	[SerializeField]
	float ShakeAmount = 0.7f;

	[SerializeField]
	float DecreaseFactor = 1.0f;

	Vector3 originalPos;

	void Awake()
	{
		if (CameraTransform == null)
		{
			CameraTransform = GetComponent(typeof(Transform)) as Transform;
		}
	}

	void OnEnable()
	{
		originalPos = CameraTransform.localPosition;
	}

	void Update()
	{
		if (ShakeDuration > 0)
		{
			CameraTransform.localPosition = originalPos + Random.insideUnitSphere * ShakeAmount;
			ShakeDuration -= Time.deltaTime * DecreaseFactor;
		}
		else
		{
			ShakeDuration = 0f;
			CameraTransform.localPosition = originalPos;
		}
	}
}