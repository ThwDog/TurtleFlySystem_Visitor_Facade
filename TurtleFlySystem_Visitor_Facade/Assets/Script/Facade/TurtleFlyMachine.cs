using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TurtleFlyMachine : MonoBehaviour
{
    public bool useStraw;
    public bool useCupLid;
    public bool useScore;

    private Brew brew;
    internal Purchase purchase;
    private BeverageStock beverageStock;
    private CommonStock commonStock;
    private TurtleFly_MoneyChange moneyChange;

    private void Awake() 
    {
        brew = gameObject.GetOrAddComponent<Brew>();
        purchase = gameObject.GetOrAddComponent<Purchase>();

        beverageStock = gameObject.GetOrAddComponent<BeverageStock>();
        commonStock = gameObject.GetOrAddComponent<CommonStock>();
        moneyChange = gameObject.GetOrAddComponent<TurtleFly_MoneyChange>();
    }
    
    private void Start() 
    {
        brew.machine = this;
        purchase.machine = this;    
    }

    public void purchaseDrink(Customer customer, BeverageRecipe_Scriptable recipe) // get a drink
    {
        //check that if have in stock
        if(beverageStock.water < recipe.water || beverageStock.milk < recipe.milk ||beverageStock.coffee < recipe.coffee ||beverageStock.coco < recipe.coco )
        {
            Debug.Log(recipe.name + "Out of stock");
            return;
        }
        if(commonStock.cup <= 0)
        {
            Debug.Log("Cup out of stock");
            return;
        }

        purchase.Purchased(recipe,customer,moneyChange);
        if(!purchase.isPayed)
            return;
        brew.brewed(recipe,beverageStock,commonStock);
        Debug.Log("You Purchase " + recipe._name);
    }

    public void refund(Customer customer)
    {
        customer.totalMoney += customer.payMoney;
        customer.payMoney = 0;

        customer.totalScore += customer.useScore;
        customer.useScore = 0;
    }

    public void topUpMoney(Customer customer,int amount)
    {
        customer.topUpMoney(amount);
    }

    public void topUpScore(Customer customer,int amount)
    {
        customer.topUpScore(amount);
    }

}
