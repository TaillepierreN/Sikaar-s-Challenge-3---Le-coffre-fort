using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WheelBehavior : MonoBehaviour
{
    int intRotation, prevRotation;
    bool chevron1, chevron2, chevron3, chevron4;
    [SerializeField] TMP_Text rotationCounter;
    [SerializeField] Material greenMat;
    [SerializeField] Renderer voyant1, voyant2, voyant3, voyant4;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //code 310 - 25 - 300 - 10
        intRotation = Mathf.FloorToInt(gameObject.transform.localEulerAngles.y);
        rotationCounter.text = intRotation.ToString();
        if (!chevron4)
        {
            if (intRotation == 310 && prevRotation == 311 && !chevron1)
            {
                chevron1 = true;
                voyant1.material = greenMat;
            }
            if (intRotation == 25 && prevRotation == 24 && chevron1)
            {
                chevron2 = true;
                voyant2.material = greenMat;

            }
            if (intRotation == 300 && prevRotation == 301 && chevron2)
            {
                chevron3 = true;
                voyant3.material = greenMat;

            }
            if (intRotation == 10 && prevRotation == 9 && chevron3)
            {
                chevron4 = true;
                voyant4.material = greenMat;
                //call door open here
                
            }
        }
        prevRotation = intRotation;
    }

}
