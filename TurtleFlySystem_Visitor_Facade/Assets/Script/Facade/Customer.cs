using UnityEngine;

public class Customer : MonoBehaviour
{
    public enum typeOfpay
    {
        Cash , Card 
    }
    public typeOfpay _typeOfpay;

    [Header("In wallet")]
    public int totalMoney;
    public int totalScore; // collected score
    [Header("Use")]
    public int useScore; // use score
    public int payMoney;

    public void topUpMoney(int totalTopUp)
    {
        if(totalTopUp > totalMoney)
        {
            Debug.Log("Your money doesn't enough");
            return;
        }
        totalMoney -= totalTopUp;
        payMoney += totalTopUp;
    }

    public void topUpScore(int totalTopUp)
    {
        if(totalTopUp > totalScore)
        {
            Debug.Log("Your Score doesn't enough");
            return;
        }
        totalScore -= totalTopUp;
        useScore += totalTopUp;
    }
}
