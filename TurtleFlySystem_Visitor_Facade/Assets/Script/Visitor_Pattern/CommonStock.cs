using UnityEngine;

public class CommonStock : MonoBehaviour , ITurtleFlyElement
{
    [Header("Stock")]
    public int straw = 100;
    public int cup = 100;
    public int cupLid = 100;

    //IVisitor come here
    public void ReStock(int reStock)
    {
        straw = reStock;
        cup = reStock;
        cupLid = reStock;
    }

    public int _Straw(int useNumber) // use in drink recipe
    {
        var use = straw -= useNumber;
        straw = use;
        return use;
    }

    public int _Cup(int useNumber) // use in drink recipe
    {
        var use = cup -= useNumber;
        cup = use;
        return use;
    }

    public int _CupLid(int useNumber) // use in drink recipe
    {
        var use = cupLid -= useNumber;
        cupLid = use;
        return use;
    }

    // what Accept go to method visit in Restock_Scriptable  
    public void Accept(IVisitor visitor)
    {
        visitor.visit(this);
    }

    private void OnGUI() 
    {
        GUI.color = Color.red;

        GUI.Label(new Rect(150, 910, 200, 200), "straw Stock: " + straw);
        GUI.Label(new Rect(150, 930, 200, 200), "cup Stock: " + cup);
        GUI.Label(new Rect(150, 950, 200, 200), "cupLid Stock: " + cupLid);
    }
}
