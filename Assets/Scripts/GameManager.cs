using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool isGetReport = false;
    public void WaveChange(bool _isSubmmitReport)
    {
        if (_isSubmmitReport)
        {
            if (isGetReport) Debug.Log("�ۑ��o����");
            else Debug.Log("�ۑ�������Ă��܂���");
        }
        if (!_isSubmmitReport)
        {
            Debug.Log("�ۑ���o�����i�݂܂�");
        }
    }
    public void GetReport()
    {
        Debug.Log("���|�[�g�������");
        isGetReport = true;
    }
}
