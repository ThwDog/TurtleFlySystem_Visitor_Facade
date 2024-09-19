using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/Recipe", fileName = "Recipe")]
public class BeverageRecipe_Scriptable : ScriptableObject
{
    [Header("Recipe")]
    public string _name;
    public int price;
    public float time; //how long to made
    public Sprite Img;
    [Header("Ingredient")]
    public float water;
    public float milk;
    public float coffee;
    public float coco; 
    public float sugar;
    public float _currentSugar{get;set;}


    private void brew(BeverageStock stock)
    {
        stock.use("water",water);
        stock.use("milk",milk);
        stock.use("coffee",coffee);
        stock.use("coco",coco);
        stock.use("sugar",_currentSugar);
    }

    public IEnumerator brewed(BeverageStock stock)
    {
        brew(stock);
        yield return new WaitForSecondsRealtime(time);
        yield break;
    }

}
