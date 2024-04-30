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
            if (isGetReport) Debug.Log("課題提出完了");
            else Debug.Log("課題を持っていません");
        }
        if (!_isSubmmitReport)
        {
            Debug.Log("課題を提出せず進みます");
        }
    }
    public void GetReport()
    {
        Debug.Log("レポート回収完了");
        isGetReport = true;
    }
}
