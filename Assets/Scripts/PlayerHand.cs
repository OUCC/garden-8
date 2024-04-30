using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    // Start is called before the first frame update
    Camera playerCamera;
    //カメラからアイテムまでの距離
    float maxDist = 5.0f;
    //カメラを構えているか
    bool isCameraSet;
    [SerializeField] GameManager gameManager;
    [SerializeField] PlayerPhoto_Proto playerPhoto;
    void Start()
    {
        playerCamera = Camera.main;
        isCameraSet = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) { ObjectClick(); }
        if (Input.GetMouseButtonDown(1))
        {
            isCameraSet = !isCameraSet;
            playerPhoto.CameraSet(isCameraSet);
        }

    }
    void ObjectClick()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;
        if (!isCameraSet && Physics.Raycast(ray, out hit, maxDist))
        {
            if (hit.collider.gameObject.tag == "SubmissionSwitch")
            {
                Debug.Log("aa");
                gameManager.WaveChange(true);
            }
            if (hit.collider.gameObject.tag == "SkipSwitch")
            {
                gameManager.WaveChange(false);
            }
        }
        if (isCameraSet && Physics.Raycast(ray, out hit, maxDist))
        {
            if (hit.collider.gameObject.tag == "Report")
            {
                gameManager.GetReport();
            }
        }

    }
}
