using System.Collections;
using UnityEngine;
using System;

namespace Playground
{
    public static class Q
    {
		public static bool Approx ( float a, float b, float threshold = 0.01f ) => Mathf.Abs(a - b) <= threshold;
		public static bool Approx ( Vector3 a, Vector3 b, float threshold = 0.01f ) => Mathf.Abs(a.sqrMagnitude - b.sqrMagnitude) <= threshold * threshold;
	}

	public static class Vector
	{
		public static Vector2 VecByAng ( float angle ) => new(Mathf.Cos(angle), Mathf.Sin(angle));
		public static Vector2 Vc ( Vector3 x ) => new(x.x, x.y);
	}

	public static class Wait
	{
		public static void Second ( float time, Action callback, MonoBehaviour x ) => _ = x.StartCoroutine(IESecond(time, callback));
		public static void Pause ( float time, MonoBehaviour x ) => _ = x.StartCoroutine(IPause(time));

		static IEnumerator IESecond(float time, Action callback )
		{
            yield return new WaitForSecondsRealtime(time);
            callback.Invoke();
		}
		static IEnumerator IPause(float time)
		{
			Time.timeScale = 0;
			yield return new WaitForSecondsRealtime(time);
			Time.timeScale = 1;
		}
	}
}