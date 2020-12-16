using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class spell2 : MonoBehaviour
{
    public Rigidbody projectile;
    public Transform Spawnpoint;
    public float activationThreshold = 0.2f;
    // Update is called once per frame
    void Update()
    {
        var rightHandDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.RightHand, rightHandDevices);

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
        }

    }
}
