using UnityEngine;

public class CharacterSwitcher : MonoBehaviour
{
    public CharacterController2D lowerCtrl;  // �Ʒ� ĳ���� ��ũ��Ʈ
    public CharacterController2D upperCtrl;  // �� ĳ���� ��ũ��Ʈ

    void Start()
    {
        lowerCtrl.canControl = true;
        upperCtrl.canControl = false;
    }

    // ��ư OnClick �Լ��� ����
    public void ToggleCharacter()
    {
        bool now = lowerCtrl.canControl;
        lowerCtrl.canControl = !now;
        upperCtrl.canControl = now;
    }
}
