using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ReStock : MonoBehaviour
{
    public ReStock_Scriptable beverage;
    public ReStock_Scriptable common;
    public ReStock_Scriptable change;

    private TurtleFlyStock turtleFlyStock;

    private void Start()
    {
        turtleFlyStock = gameObject.GetOrAddComponent<TurtleFlyStock>();
    }

    void OnGUI() // just for test
    {
        GUILayout.BeginArea(new Rect(10, 800, 200, 200));
        if (GUILayout.Button("Restock beverage"))
            turtleFlyStock.Accept(beverage);
        if (GUILayout.Button("Restock Common"))
            turtleFlyStock.Accept(common);
        if (GUILayout.Button("Restock Change"))
            turtleFlyStock.Accept(change);
        GUILayout.EndArea();
    }
}
