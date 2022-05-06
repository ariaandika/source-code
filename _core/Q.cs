using System.Collections;
using UnityEngine;

public class Q : MonoBehaviour
{
    // nice awowkawok

    // Print -------------------------------------------------------------------------------------------------------------------------------------------------
    public void p()
    {
        print("awowkawok");
    }
    public void p(string message)
    {
        print(message);
    }
    public void p(float message)
    {
        print(message.ToString());
    }
    public void p(int message)
    {
        print(message.ToString());
    }
    public void p(string x, string y)
    {
        print(x + " : " + y);
    }
    public void p(float x, float y)
    {
        print(x.ToString() + " : " + y.ToString());
    }
    public void p(int x, int y)
    {
        print(x.ToString() + " : " + y.ToString());
    }

    // Random -------------------------------------------------------------------------------------------------------------------------------------------------
    public int r(int x, int y)
    {
        return Random.Range(x, y + 1);
    }
    public int r(bool isInt)
    {
        return Random.Range(0, 2);
    }
    public float r()
    {
        return Random.Range(0, 1);
    }
    public float r(float x, float y)
    {
        return Random.Range(x, y);
    }
    // Center world, normalized
    public Vector3 RandomInsideCircle(float radius, float y = 0.5f)
    {
        Vector2 x;
        do
        {
            x = Random.insideUnitCircle.normalized;
        } while (x == Vector2.zero);
        x *= radius;
        return new Vector3(x.x, y, x.y);
    }

    // Sin Cos Tan
    public Vector2 VecByAng(float angle)
    {
        return new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
    }
    public Vector2 Vc(Vector3 x)
    {
        return new Vector2(x.x, x.y);
    }

    // Other -------------------------------------------------------------------------------------------------------------------------------------------------
    public bool Approx(float a, float b, float threshold = 0.01f)
    {
        return Mathf.Abs(a - b) <= threshold;
    }
    public bool Approx(Vector3 a, Vector3 b, float threshold = 0.01f)
    {
        return Mathf.Abs(a.magnitude - b.magnitude) <= threshold;
    }
}
