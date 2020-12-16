using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
public class Spells : MonoBehaviour
{
    public Rigidbody projectile;
    public Transform Spawnpoint;
    public InputHelpers.Button spellButton;
    public float fireDelta = 0.5F;

    private float nextFire = 0.5F;
    private Rigidbody newProjectile;
    private float myTime = 0.0F;

    private bool isPressed;
    // Update is called once per frame
    void Update()
    {
        //var rightHandDevices = new List<UnityEngine.XR.InputDevice>();
        //UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.RightHand, rightHandDevices);
        /*
        if (rightHandDevices.Count == 1)
        {
            UnityEngine.XR.InputDevice device = rightHandDevices[0];
            bool triggerValue;
            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue)
            {
                Rigidbody clone;
                clone = (Rigidbody)Instantiate(projectile, Spawnpoint.position, projectile.rotation);

                clone.velocity = Spawnpoint.TransformDirection(Vector3.forward * 50);
            }
        }*/
        myTime = myTime + Time.deltaTime;

        if (InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(XRNode.RightHand),spellButton, out bool isPressed) && myTime > nextFire)
        {
            nextFire = myTime + fireDelta;
            newProjectile = (Rigidbody)Instantiate(projectile, Spawnpoint.position, Spawnpoint.rotation) as Rigidbody;

            // create code here that animates the newProjectile
            newProjectile.velocity = Spawnpoint.TransformDirection(Vector3.forward * 20);
            nextFire = nextFire - myTime;
            myTime = 0.0F;
        }

    }

}
