using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GazePointer : MonoBehaviour
{
    public Image fillImage;
    public float fillRate;
    [HideInInspector]
    public bool gazeComplete;
    private float fill;

    void Start()
    {
        gazeComplete = false;
        transform.localPosition = new Vector3(0, 0, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward, Color.red);
            if (hit.transform.gameObject.tag == "wearable" && !gazeComplete)
            {                
                fill = 1.0f/fillRate * Time.deltaTime;
                fillImage.fillAmount += fill; 
                Debug.Log(hit.transform.gameObject.name);

                if (fillImage.fillAmount >= 1f)
                {
                    gazeComplete = true;
                    fillImage.fillAmount = 0;
                    Debug.Log("Filled");
                }
            }
            else
            {
                fillImage.fillAmount = 0;
            }
        }
    }
}
