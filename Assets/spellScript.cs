using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class spellScript : MonoBehaviour
{
    public GameObject spell;
    public InputHelpers.Button spellButton;
    public float activationThreshold = 0.2f;

    //GLOBAL BOOL
    public static bool IceON = false;
    // Start is called before the first frame update
    void Start()
    {
        //Disable the view of the network player by the player itself.
        spell.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
            UpdateSpellNetwork(InputDevices.GetDeviceAtXRNode(XRNode.RightHand), spell);
    }
    public bool CheckIfActivated(InputDevice targetdevice)
    {
        InputHelpers.IsPressed(targetdevice, spellButton, out bool isActivated, activationThreshold);
        return isActivated;

    }

    void UpdateSpellNetwork(InputDevice targetDevice, GameObject theSpell)
    {
        if (CheckIfActivated(targetDevice))
        {
            spell.SetActive(true);
            IceON = true;
        }
        else
        {

            spell.SetActive(false);
            IceON = false;
        }
    }
}
