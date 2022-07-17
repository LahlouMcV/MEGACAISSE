using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attach_Hand_IK : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform PointToGrab;
    public Transform LeftHand;
    //IKShake PointToGrab;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        
        //animator.SetIKPosition(AvatarIKGoal.RightHand, 1);
    }

    void OnAnimatorIK()

    {
        animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
        animator.SetIKPosition(AvatarIKGoal.LeftHand, PointToGrab.position);
        animator.SetIKRotation(AvatarIKGoal.LeftHand, PointToGrab.rotation);
        //animator.SetIKPosition(AvatarIKGoal.LeftHandIndex1, 1);
    }
}
