using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class io : MonoBehaviour
{
    /// <summary>
    /// import export data
    /// - player save
    /// - multiple resource
    /// </summary>

    void Awake()
    {
        // var tex = Resources.LoadAll("inRoot/subFolder", typeof(Texture2D)).Cast<Texture2D>().ToList();

        // 1. Change directory, LoadAll will make a list of all imported resource
        // 2. Change "typeof", it will decide the data type
    }

}