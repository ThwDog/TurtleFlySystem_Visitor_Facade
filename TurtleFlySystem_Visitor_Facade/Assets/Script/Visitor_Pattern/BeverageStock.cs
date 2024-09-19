using UnityEngine;

public class BeverageStock : MonoBehaviour, ITurtleFlyElement
{
    [Header("Stock")]
    public float water = 100.0f;
    public float milk = 100.0f;
    public float coffee = 100.0f;
    public float coco = 100.0f;
    public float sugar = 100.0f;

    // IVisitor Come here 
    public void ReStock(int reStock)
    {
        water = reStock;
        milk = reStock;
        coffee = reStock;
        coco = reStock;
        sugar = reStock;
    }

    public float _water(float useNumber) // use in drink recipe
    {
        checkStock(water);

        var use = water -= useNumber;
        water = use;
        return use;
    }

    public float _milk(float useNumber) // use in drink recipe
    {
        checkStock(milk);

        var use = milk -= useNumber;
        milk = use;
        return use;
    }
    public float _coffee(float useNumber) // use in drink recipe
    {
        checkStock(coffee);

        var use = coffee -= useNumber;
        coffee = use;
        return use;
    }
    public float _coco(float useNumber) // use in drink recipe
    {
        checkStock(coco);

        var use = coco -= useNumber;
        coco = use;
        return use;
    }

    public float _sugar(float useNumber) // use in drink recipe
    {
        checkStock(sugar);

        var use = sugar -= useNumber;
        sugar = use;
        return use;
    }

    public void use(string name,float useNumber)
    {
        switch(name)
        {
            case "water":
                if(water <= 0)
                {
                    Debug.Log("out of water");
                    return;
                }
                _water(useNumber);
                break;
            case "milk":
                if(milk <= 0)
                {
                    Debug.Log("out of milk");
                    return;
                }
                _milk(useNumber);
                break;
            case "coffee":
                if(coffee <= 0)
                {
                    Debug.Log("out of coffee");
                    return;
                }
                _coffee(useNumber);
                break;
            case "coco":
                if(coco <= 0)
                {
                    Debug.Log("out of coco");
                    return;
                }
                _coco(useNumber);
                break;
            case "sugar":
                if(coco <= 0)
                {
                    Debug.Log("out of sugar");
                    return;
                }
                _sugar(useNumber);
                break;
        }
    }

    private bool checkStock(float _stock)
    {
        if(_stock <= 0)
        {
            return true;
        }
        return false;
    }

    // what Accept go to method visit in Restock_Scriptable  
    public void Accept(IVisitor visitor)
    {
        visitor.visit(this);
    }

    private void OnGUI() 
    {
        GUI.color = Color.red;

        GUI.Label(new Rect(10, 910, 200, 200), "Water Stock: " + water);
        GUI.Label(new Rect(10, 930, 200, 200), "Milk Stock: " + milk);
        GUI.Label(new Rect(10, 950, 200, 200), "Coco Stock: " + coco);
        GUI.Label(new Rect(10, 970, 200, 200), "Coffee Stock: " + coffee);     
        GUI.Label(new Rect(10, 1000, 200, 200), "Sugar Stock: " + sugar);     
    }

}
