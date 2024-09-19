using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Script")]
    [SerializeField] Customer customer;
    [SerializeField] ClientTurtleFly client;

    [Header("UI")]

    [SerializeField] TMP_Text totalCustomerMoney_Text;
    [SerializeField] TMP_Text totalCustomerScore_Text;
    [SerializeField] TMP_Text moneyInMachine;
    [SerializeField] TMP_Text scoreInMachine;
    [SerializeField] TMP_Text recipeName_Text;
    [SerializeField] TMP_Text price_Text;
    [SerializeField] TMP_Dropdown payTypeSelectDropDown;
    [SerializeField] TMP_Dropdown sugarSelectDropDown;
    [SerializeField] Image drinkImg;

    private void Update() 
    {
        totalCustomerMoney_Text.text = "Total Customer Money : "+ customer.totalMoney.ToString();
        totalCustomerScore_Text.text = "Total Customer Score : "+ customer.totalScore.ToString();

        moneyInMachine.text = "Use Money : "+ customer.payMoney.ToString();
        scoreInMachine.text ="Use Score : "+ customer.useScore.ToString();
        recipeName_Text.text = client.recipe.name;
        price_Text.text = client.recipe.price.ToString();

        if(client.summary_Panel.activeSelf)
            drinkImg.sprite = client.recipe.Img;
    }

       public void setCustomerPayType()
    {
        switch(payTypeSelectDropDown.value)
        {
            case 0:
                customer._typeOfpay = Customer.typeOfpay.Cash;
                break;
            case 1:
                customer._typeOfpay = Customer.typeOfpay.Card;
                break;
        }
    }

    public void sugarSet()
    {
        var recipe = client.recipe;

        switch(sugarSelectDropDown.value)
        {
            case 0:
                recipe._currentSugar = recipe.sugar;
                Debug.Log("Sugar Add To : " + recipe._currentSugar);
                break;
            case 1:
                recipe._currentSugar = 0;
                Debug.Log("Sugar Add To : " + recipe._currentSugar);
                break;
            case 2:
                recipe._currentSugar = recipe.sugar * 1.5f;
                Debug.Log("Sugar Add To : " + recipe._currentSugar);
                break;
            case 3:
                recipe._currentSugar = recipe.sugar * 2f;
                Debug.Log("Sugar Add To : " + recipe._currentSugar);
                break;
            case 4:
                recipe._currentSugar = recipe.sugar*  5f;
                Debug.Log("Sugar Add To : " + recipe._currentSugar);
                break;
        }

    }
}
