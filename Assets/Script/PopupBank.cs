using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopupBank : MonoBehaviour
{
    public GameObject depositPanel; // �Ա� UI �г�
    public GameObject withdrawPanel; // ��� UI �г�
    public TMP_InputField depositInputField; // �Ա� �ݾ� �Է� �ʵ�
    public TMP_InputField withdrawInputField; // ��� �ݾ� �Է� �ʵ�
    public PopupError popupError; // ���� �˾�
    public Button[] depositButtons; // ���� �Ա� ��ư��
    public Button[] withdrawButtons; // ���� ��� ��ư��

    private void Start()
    {
        // ���� �Ա� ��ư�� �̺�Ʈ �߰�
        foreach (Button button in depositButtons)
        {
            int amount = int.Parse(button.GetComponentInChildren<TextMeshProUGUI>().text.Replace("��", "").Trim());
            button.onClick.AddListener(() => Deposit(amount));
        }

        // ���� ��� ��ư�� �̺�Ʈ �߰�
        foreach (Button button in withdrawButtons)
        {
            int amount = int.Parse(button.GetComponentInChildren<TextMeshProUGUI>().text.Replace("��", "").Trim());
            button.onClick.AddListener(() => Withdraw(amount));
        }
    }

    // �Ա� ���
    public void Deposit(int amount)
    {
        UserData user = GameManager.Instance.userData;

        if (user.cash < amount)
        {
            popupError.Show("������ �����մϴ�!");
            return;
        }

        user.cash -= amount;
        user.balance += amount;
        GameManager.Instance.SaveUserData(); //�Ա� �� �ڵ� ����--10����
        GameManager.Instance.RefreshUI();
    }

    // ��� ���
    public void Withdraw(int amount)
    {
        UserData user = GameManager.Instance.userData;

        if (user.balance < amount)
        {
            popupError.Show("�ܾ��� �����մϴ�!");
            return;
        }

        user.cash += amount;
        user.balance -= amount;
        GameManager.Instance.SaveUserData(); //�Ա� �� �ڵ� ����--10����
        GameManager.Instance.RefreshUI();
    }

    // ���� �Է��Ͽ� �Ա�
    public void DepositFromInput()
    {
        if (int.TryParse(depositInputField.text, out int amount) && amount > 0)
        {
            Deposit(amount);
        }
        else
        {
            popupError.Show("��ȿ�� �ݾ��� �Է��ϼ���!");
        }
    }

    // ���� �Է��Ͽ� ���
    public void WithdrawFromInput()
    {
        if (int.TryParse(withdrawInputField.text, out int amount) && amount > 0)
        {
            Withdraw(amount);
        }
        else
        {
            popupError.Show("��ȿ�� �ݾ��� �Է��ϼ���!");
        }
    }

    // �Ա� UI Ȱ��ȭ
    public void OpenDepositPanel()
    {
        depositPanel.SetActive(true);
        withdrawPanel.SetActive(false);
    }

    // ��� UI Ȱ��ȭ
    public void OpenWithdrawPanel()
    {
        depositPanel.SetActive(false);
        withdrawPanel.SetActive(true);
    }

    // ��� �г� �ݱ�
    public void CloseAllPanels()
    {
        depositPanel.SetActive(false);
        withdrawPanel.SetActive(false);
    }

    // �ڷΰ��� ��ư
    public void BackToMainPanel()
    {
        depositPanel.SetActive(false);
        withdrawPanel.SetActive(false);
    }
}
