using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Animator doorAnimator;

    public bool isOpenTrigger;
    public bool isCloseTrigger;

    public bool isNormalTrigger;

    public AudioSource sfxTriggers;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (isOpenTrigger || isNormalTrigger)
            {
                doorAnimator.SetBool("isOpen", true);
            }
            if (isCloseTrigger)
            {
                doorAnimator.SetBool("isOpen", false);
                doorAnimator.SetBool("isClose", true);
            }
            sfxTriggers.Play();
        }
    }

    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (isNormalTrigger)
            {
                doorAnimator.SetBool("isOpen", false);
                doorAnimator.SetBool("isClose", true);
            }
          
        }
    }
    
}
