using System.Collections;
using UnityEngine;
using System;

namespace Playground
{
    public static class Value
    {
		public static bool Approx ( float a, float b, float threshold = 0.01f ) => Mathf.Abs(a - b) <= threshold;
		public static bool Approx ( Vector3 a, Vector3 b, float threshold = 0.01f ) => Mathf.Abs(a.sqrMagnitude - b.sqrMagnitude) <= threshold * threshold;

	}

	public static class Vector
	{
		public static Vector2 VecByAng ( float angle ) => new(Mathf.Cos(angle), Mathf.Sin(angle));
		public static Vector2 Convert ( this Vector3 x ) => new(x.x, x.y);
        public static Vector3 Round(this Vector3 x) => new(Mathf.Round(x.x), Mathf.Round(x.y), Mathf.Round(x.z));
        public static Vector2 Round(this Vector2 x) => new(Mathf.Round(x.x), Mathf.Round(x.y));

		public static Vector3 FloatToVector(float[] x) => new(x[0], x[1], x[2]);
    }

	public static class Wait
	{
		public static void WaitSecond( this MonoBehaviour x,float time, Action callback) => _ = x.StartCoroutine(IESecond(time, callback));

        static IEnumerator IESecond(float time, Action callback )
		{
            yield return new WaitForSecondsRealtime(time);
            callback.Invoke();
		}
	}
}