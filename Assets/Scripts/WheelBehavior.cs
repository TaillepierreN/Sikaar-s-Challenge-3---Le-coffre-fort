using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WheelBehavior : MonoBehaviour
{
    int intRotation, prevRotation;
    [SerializeField]bool chevron1, chevron2, chevron3, chevron4;
    [SerializeField] TMP_Text rotationCounter;
    [SerializeField] Material greenMat;
    [SerializeField] Renderer voyant1, voyant2, voyant3, voyant4;
    [SerializeField] HingeJoint door;
    [SerializeField] AudioSource audioDoor;
    [SerializeField] ParticleSystem smoke;
    [SerializeField] AudioSource click;
    Vector3 firstpos, center, newpos;

    GameObject hand;
    bool intrigger;
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
                click.Play();
            }
            if (intRotation == 25 && prevRotation == 24 && chevron1)
            {
                chevron2 = true;
                voyant2.material = greenMat;
                click.Play();

            }
            if (intRotation == 300 && prevRotation == 301 && chevron2)
            {
                chevron3 = true;
                voyant3.material = greenMat;
                click.Play();

            }
            if (intRotation == 10 && prevRotation == 9 && chevron3)
            {
                chevron4 = true;
                voyant4.material = greenMat;
                click.Play();
                //call door open here
                JointLimits limits = door.limits;
                limits.max = 90f;
                door.limits = limits;
                door.useMotor = true;
                audioDoor.Play();
                smoke.Play();
            }
        }
        
        prevRotation = intRotation;
        // if(intrigger)
        // {
        //     newpos = hand.transform.position;
        //     var angle=Vector3.Angle(firstpos-center, newpos-center);
        //     Debug.Log(angle);
        //     transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
        //     firstpos = newpos;

        // }


    }
    private void OnTriggerEnter(Collider other) {
         firstpos = other.transform.position;
         center = gameObject.transform.position;
         hand = other.gameObject;
    }
    private void OnTriggerStay(Collider other) {
        intrigger = true;
    }
    private void OnTriggerExit(Collider other) {
        intrigger = false;
    }
}
