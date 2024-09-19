using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Brew : MonoBehaviour
{
    public TurtleFlyMachine machine;
    
    public void brewed(BeverageRecipe_Scriptable _recipe,BeverageStock _beverageStock,CommonStock _commonStock)
    {
        StartCoroutine(_recipe.brewed(_beverageStock));

        _commonStock._Cup(1);

        if(machine.useCupLid)
        {
            if(_commonStock.cupLid <= 0)
            {
                Debug.Log("Cup lid out of stock");
                machine.useCupLid = false;
            }
            else _commonStock._CupLid(1);
        }
        if(machine.useStraw)
        {
            if(_commonStock.straw <= 0)
            {
                Debug.Log("Cup lid out of stock");
                machine.useStraw = false;
            }
            else _commonStock._Straw(1);
        }
    }

}
