using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Globalization;

public class UserData : MonoBehaviour
{
    public string userName; //�̸�
    public int cash;         //��������
    public int balance;      //�����ܾ�
    //TextMeshProUGUI;
    public UserData(string name, int cash, int balance)
    {
        this.userName = name;
        this.cash = cash;
        this.balance = balance;
    }

}
