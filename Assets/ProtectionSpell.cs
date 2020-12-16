using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.XR;

public class ProtectionSpell : MonoBehaviour
{
    public MeshRenderer protectionMesh;
    public Collider protectionOn;
    public InputHelpers.Button protectButton;
    public float activationThreshold = 0.2f;
    public PhotonView photonView;

    // Start is called before the first frame update
    void Start()
    {
        //Disable the view of the network player by the player itself.
        protectionMesh.enabled = false;
        protectionOn.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            UpdateSpellNetwork(InputDevices.GetDeviceAtXRNode(XRNode.RightHand), protectionMesh);
        }
    }

    public bool CheckIfActivated(InputDevice targetdevice)
    {
        InputHelpers.IsPressed(targetdevice, protectButton, out bool isActivated, activationThreshold);
        return isActivated;

    }

    void UpdateSpellNetwork(InputDevice targetDevice, MeshRenderer theSpell)
    {
        if (CheckIfActivated(targetDevice))
        {
            theSpell.enabled = true;
            protectionOn.enabled = true;
        }
        else
        {
            theSpell.enabled = false;
            protectionOn.enabled = false;
        }
    }
}
