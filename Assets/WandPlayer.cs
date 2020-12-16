using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Photon.Pun;
using UnityEngine.XR.Interaction.Toolkit;

public class WandPlayer : MonoBehaviour
{
    public Transform wand;
    private PhotonView photonView;
    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        //Disable the view of the network player by the player itself.
        if (photonView.IsMine)
        {
            foreach (var item in wand.GetComponentsInChildren<Renderer>())
            {
                item.enabled = false;
            }
        }
    }
}
