using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class LocalNetworkVisibility : MonoBehaviour
{

    public MeshRenderer targetprotectionMesh;
    public Collider targetprotectionOn;
    public GameObject ice;
    private PhotonView photonView;
    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
    }
    // Update is called once per frame
    void Update()
    {
        //Disable the view of the network player by the player itself.
        if (photonView.IsMine)
        {
            if (ProtectionSpell.ProtecON == false)
            {
                targetprotectionMesh.enabled = false;
                targetprotectionOn.enabled = false;
            }
            else
            {
                targetprotectionMesh.enabled = true;
                targetprotectionOn.enabled = true;
            }

            if(spellScript.IceON == false)
            {
                ice.SetActive(false);
            }
            else
            {
                ice.SetActive(true);
            }
        }
        
    }
}
