using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.WSA;

public class Purchase : MonoBehaviour
{
    public TurtleFlyMachine machine;
    public bool isPayed = false;


    public void Purchased(BeverageRecipe_Scriptable _recipe,Customer _customer,TurtleFly_MoneyChange change)
    {
        if (change.change <= 0 && _customer._typeOfpay == Customer.typeOfpay.Cash)
        {
            Debug.Log("Pls use credit card or wait until reStock");
            isPayed = false;
            return;
        }

        int _total = _customer.payMoney + _customer.useScore;

        if(_total < _recipe.price)
        {
            isPayed = false;
            Debug.Log("Your money doesn't enough");
            return;
        }

        if(machine.useScore)
        {
            if(_customer.useScore <= 0)
            {
                Debug.Log("You don't have any score");
                isPayed = false;
                return;
            }
            var total = (_customer.payMoney + _customer.useScore) - _recipe.price;
            total = Mathf.Abs(total);  
            _customer.useScore = 0;
            if(total <= 0)
                _customer.payMoney = 0;
            change.changeMoney(total,_customer,machine);
            _customer.payMoney -= total;
            isPayed = true;
        }
        else if(!machine.useScore)
        {
            change.changeMoney(_recipe.price,_customer,machine);
            _customer.payMoney -= _recipe.price;

            isPayed = true;
        }
    }
}
