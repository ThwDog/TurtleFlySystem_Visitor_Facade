using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DrinkButtonScript : MonoBehaviour
{
    public enum type
    {
        Drink , Strew , CupLid , Sugar
    }

    public type _type;
    private BeverageStock beverageStock;
    private CommonStock commonStock;
    [SerializeField] GameObject client;
    [SerializeField] BeverageRecipe_Scriptable recipe;
    [SerializeField] GameObject outOfStock;
    [Header("")]
    Button button;
    Toggle toggle;
    TMP_Dropdown dropdown;

    private void Start() 
    {
        beverageStock = client.GetComponent<BeverageStock>();
        commonStock = client.GetComponent<CommonStock>();
        button = this.GetComponent<Button>();
        toggle = this.GetComponent<Toggle>();
        dropdown = this.GetComponent<TMP_Dropdown>();
    }

    private void Update() 
    {
        if(client.GetComponent<ClientTurtleFly>().selectDrink_Panel.activeSelf)
            if(_type == type.Drink)
            checkStock();    
        if(client.GetComponent<ClientTurtleFly>().addOn_Panel.activeSelf)
            if(_type != type.Drink)
                checkCommonStock();
    }

    public void checkStock()
    {
        if(beverageStock.water < recipe.water || beverageStock.milk < recipe.milk ||beverageStock.coffee < recipe.coffee ||beverageStock.coco < recipe.coco || commonStock.cup <= 0)
        {
            outOfStock.SetActive(true);
            button.interactable = false;
            Debug.Log(recipe.name + "Out of stock");
        }
        else
        {
            outOfStock.SetActive(false);
            button.interactable = true;
        }
    }

    public void checkCommonStock()
    {
        if(_type == type.Strew)
        {
            if(commonStock.straw <= 0)
                toggle.interactable = false;
            else toggle.interactable = true;
        }
        if(_type == type.CupLid)
        {
            if(commonStock.cupLid <= 0)
                toggle.interactable = false;
            else toggle.interactable = true;
        }
        if(_type == type.Sugar)
        {
            if(beverageStock.sugar <= 0)
            {
                dropdown.interactable = false;
                dropdown.value = 1;
            }
            else dropdown.interactable = true;
        }
    }
}
