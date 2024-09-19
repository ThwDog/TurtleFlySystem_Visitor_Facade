using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ClientTurtleFly : MonoBehaviour // this is facade
{
    [Header("")]
    public Customer customer;
    [Header("")]
    public BeverageRecipe_Scriptable recipe;
    TurtleFlyMachine machine;

    [Header("UI")]
    public GameObject selectDrink_Panel;
    public GameObject addOn_Panel;
    [SerializeField] GameObject payMenu_Panel;
    [SerializeField] GameObject useScore_Panel;
    public GameObject summary_Panel;
    [SerializeField] TMP_InputField inputMoneyAmount;
    [SerializeField] TMP_InputField inputScoreAmount;
    

    private void Awake() 
    {
        machine = gameObject.GetOrAddComponent<TurtleFlyMachine>();    
    }
    
    public void UseStrewButton()
    {
        machine.useStraw = !machine.useStraw;
    }
    public void UseCupLidButton()
    {
        machine.useCupLid = !machine.useCupLid;
    }

    public void UseScoreButton()
    {
        machine.useScore = !machine.useScore;
    }

    public void getDrinkButton(BeverageRecipe_Scriptable recipe)
    {
        this.recipe = recipe;
        nextPanel();
    }

    public void nextPanel()
    {
        if(selectDrink_Panel.activeSelf)
        {
            addOn_Panel.SetActive(true);
            selectDrink_Panel.SetActive(false);
        }
        else if(addOn_Panel.activeSelf)
        {
            addOn_Panel.SetActive(false);
            payMenu_Panel.SetActive(true);
        }
        else if(payMenu_Panel.activeSelf)
        {
            if(machine.useScore)
            {
                payMenu_Panel.SetActive(false);
                useScore_Panel.SetActive(true);
            }
            else
            {
                payMenu_Panel.SetActive(false);
                purchase();
            }
        }
    }

    public void backPanel()
    {
        if(addOn_Panel.activeSelf)
        {
            addOn_Panel.SetActive(false);
            selectDrink_Panel.SetActive(true);
        }
        else if(payMenu_Panel.activeSelf)
        {
            addOn_Panel.SetActive(true);
            payMenu_Panel.SetActive(false);
        }
        else if(useScore_Panel.activeSelf)
        {
            useScore_Panel.SetActive(false);
            payMenu_Panel.SetActive(true);
        }
        else if(summary_Panel.activeSelf)
        {
            summary_Panel.SetActive(false);
            selectDrink_Panel.SetActive(true);

        }
    } 

    public void purchase()
    {
        if(useScore_Panel.activeSelf)
            useScore_Panel.SetActive(false);
        
        machine.purchaseDrink(customer,recipe);
        if(machine.purchase.isPayed)
            summary_Panel.SetActive(true);
        else
        {
            payMenu_Panel.SetActive(true);
        }
    }


    public void topUpMoney()
    {
        machine.topUpMoney(customer,int.Parse(inputMoneyAmount.text));
    }

    public void topUpScore()
    {
        machine.topUpScore(customer,int.Parse(inputScoreAmount.text));
    }

    public void refund()
    {
        machine.refund(customer);
        if(!selectDrink_Panel.activeSelf)
            backPanel();
    }

    
}
