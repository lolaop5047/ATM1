using UnityEngine;
using TMPro;

public class PopupError : MonoBehaviour
{
    public GameObject popupPanel; // ���� �˾� �г�
    public TextMeshProUGUI errorMessage; // ���� �޽��� ǥ�� �ؽ�Ʈ

    // ���� �޽����� �����ϰ� �˾��� ���� �޼���
    public void Show(string message)
    {
        errorMessage.text = message;
        popupPanel.SetActive(true);
    }

    // Ȯ�� ��ư Ŭ�� �� �˾� �ݱ�
    public void ClosePopup()
    {
        popupPanel.SetActive(false);
    }
}
