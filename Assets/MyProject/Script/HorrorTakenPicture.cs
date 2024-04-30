using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorrorTakenPicture : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isVisible { get; set; }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnBecameInvisible()
    {
        isVisible = false;
    }
    private void OnBecameVisible()
    {
        isVisible=true;
    }
}
interface IHorrorTakenPicture
{
    public bool isVisible { get; }
}