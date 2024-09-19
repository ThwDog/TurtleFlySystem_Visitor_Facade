using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TurtleFlyStock : MonoBehaviour, ITurtleFlyElement
{
    private List<ITurtleFlyElement> _turtleFlyElement = new List<ITurtleFlyElement>();

    void Start()
    {
        _turtleFlyElement.Add(gameObject.GetOrAddComponent<BeverageStock>());
        _turtleFlyElement.Add(gameObject.GetOrAddComponent<CommonStock>());
        _turtleFlyElement.Add(gameObject.GetOrAddComponent<TurtleFly_MoneyChange>());
    }

    // Select Visitor that you want to visit
    public void Accept(IVisitor visitor)
    {
        // go to all script that has interface ITurtleFlyElement
        foreach (var element in _turtleFlyElement)
        {
            // accept visitor that you select
            element.Accept(visitor);
        }
    }
}
