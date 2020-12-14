using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Photon.Pun;
public class NetworkPlayer : MonoBehaviour
{
    public Transform head;
    public Transform leftHand;
    public Transform rightHand;

    public Animator leftHandAnimator;
    public Animator rightHandAnimator;

    private PhotonView photonView;


    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();

        //Disable the view of the network player by the player itself.
        if (photonView.IsMine)
        {
            foreach (var item in GetComponentsInChildren<Renderer>())
            {
                item.enabled = false;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            MapPosition(head, GameObject.Find("CenterEyeAnchor").transform);
            MapPosition(leftHand, GameObject.Find("LeftControllerAnchor").transform);
            MapPosition(rightHand, GameObject.Find("RightControllerAnchor").transform);

            UpdateHandAnimation(InputDevices.GetDeviceAtXRNode(XRNode.LeftHand), leftHandAnimator);
            UpdateHandAnimation(InputDevices.GetDeviceAtXRNode(XRNode.RightHand), rightHandAnimator);
        }
    }

    void UpdateHandAnimation(InputDevice targetDevice, Animator handAnimator)
    {
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            handAnimator.SetFloat("Trigger", triggerValue);
        }
        else
        {
            handAnimator.SetFloat("Trigger", 0);
        }

        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            handAnimator.SetFloat("Grip", gripValue);
        }
        else
        {
            handAnimator.SetFloat("Grip", 0);
        }
    }

    //Target will get the position and the rotation of the XR node
    void MapPosition(Transform target, Transform from)
    {

        Vector3 position = from.position;
        Quaternion rotation = from.rotation;
        target.position = position;
        target.rotation = rotation;
    }
}
