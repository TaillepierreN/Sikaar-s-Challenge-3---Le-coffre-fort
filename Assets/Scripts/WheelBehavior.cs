using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WheelBehavior : MonoBehaviour
{
    [SerializeField] TMP_Text rotationCounter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotationCounter.text = gameObject.transform.localEulerAngles.x.ToString();
    }

}
