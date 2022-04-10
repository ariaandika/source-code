using System.Collections;
using UnityEngine;

public class Q : MonoBehaviour
{
    // nice awowkawok

    // Print -------------------------------------------------------------------------------------------------------------------------------------------------
    public void p(){
        print("awowkawok");
    }
    public void p(string message){
        print(message);
    }
    public void p(float message){
        print(message.ToString());
    }
    public void p(int message){
        print(message.ToString());
    }

    // Input -------------------------------------------------------------------------------------------------------------------------------------------------
    public float GA(string axisName){
        return Input.GetAxis(axisName);
    }
    public float GAR(string axisName,bool isRaw=true){
        return Input.GetAxisRaw(axisName);
    }

    // Other -------------------------------------------------------------------------------------------------------------------------------------------------
    public bool OtApprox(float a, float b, float threshold)
    {
        return Mathf.Abs(a - b) <= threshold;
    }
    public bool OtApprox(Vector3 a, Vector3 b, float threshold)
    {
        float z = a.magnitude - b.magnitude;
        return Mathf.Abs(z) <= threshold;
    }
}
