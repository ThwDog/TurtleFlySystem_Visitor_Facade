using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/Restock", fileName = "Restock")]
public class ReStock_Scriptable : ScriptableObject, IVisitor
{
    public enum typeOfStock
    {
        Common , Beverage , Change
    }

    public typeOfStock type;

    [Header("Stock")]
    public int stockNum = 100;

    # region visit to that script 
    public void visit(BeverageStock beverage)
    {
        if(type == typeOfStock.Beverage)
            beverage.ReStock(stockNum);
    }

    public void visit(TurtleFly_MoneyChange change)
    {
        if(type == typeOfStock.Change)
            change.change += stockNum;
    }

    public void visit(CommonStock commonStock)
    {
        if(type == typeOfStock.Common)
            commonStock.ReStock(stockNum);
    }
    # endregion
}
