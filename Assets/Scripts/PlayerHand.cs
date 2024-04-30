using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    // Start is called before the first frame update
    Camera playerCamera;
    //カメラからアイテムまでの距離
    float maxDist=5.0f;
    [SerializeField]GameManager gameManager;
    void Start()
    {
        playerCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) { ObjectClick(); }
    }
    void ObjectClick()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxDist))
        {
            if (hit.collider.gameObject.tag == " SubmissionSwitch")
            {
                gameManager.WaveChange(true);
            }
            if (hit.collider.gameObject.tag == "SkipSwitch")
            {
                gameManager.WaveChange(false);
            }
        }
    }
}
