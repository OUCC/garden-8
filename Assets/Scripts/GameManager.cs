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
            if (isGetReport) Debug.Log("‰Û‘è’ñoŠ®—¹");
            else Debug.Log("‰Û‘è‚ğ‚Á‚Ä‚¢‚Ü‚¹‚ñ");
        }
        if (!_isSubmmitReport)
        {
            Debug.Log("‰Û‘è‚ğ’ño‚¹‚¸i‚İ‚Ü‚·");
        }
    }
    public void GetReport()
    {

    }
}
