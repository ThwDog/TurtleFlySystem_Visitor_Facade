using Unity.Mathematics;
using UnityEngine;

public class TurtleFly_MoneyChange : MonoBehaviour, ITurtleFlyElement
{
    [Header("Stock")]
    public int change = 1000;

    public void changeMoney(int price, Customer customer, TurtleFlyMachine machine) // amount is amount of money that player pay
    {
        if (machine.useScore)
        {
            int _total = customer.payMoney + customer.useScore;
            if (_total == price)
            {
                Debug.Log("No change");
                return;
            }
            else
            {
                Debug.Log("change");
                var total = price - customer.payMoney;
                change -= Mathf.Abs(total);
            }
        }
        if (customer.payMoney == price || customer._typeOfpay == Customer.typeOfpay.Card)
        {
            Debug.Log("No change");
            return;
        }
        else
        {
            Debug.Log("change");
            var total = price - customer.payMoney;
            change -= Mathf.Abs(total);
        }
    }

    // what Accept go to method visit in Restock_Scriptable  
    public void Accept(IVisitor visitor)
    {
        // get visit in Restock_Scriptable
        visitor.visit(this);
    }
    private void OnGUI()
    {
        GUI.color = Color.red;

        GUI.Label(new Rect(10, 1030, 200, 200), "change Money : " + change);

    }
}
