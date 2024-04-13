using GorillaExtensions;
using GorillaTag;
using Photon.Pun;
using POpusCodec.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using static MonkeModMenu.Misc.Variables;
using static MonkeModMenu.Menu.Main;
using static Mono.Security.X509.X509Stores;
using static GorillaLocomotion.Player;
using BepInEx;
using System.Diagnostics;
using System.Linq;


namespace MonkeModMenu.Mods
{
    public class MoveMent : MonoBehaviour
    {
        public static void JoioDiscord()
        {
            Process.Start("https://discord.gg/XFTsyFhzcf");
        }
        public static void SpeedBoost(bool w)
        {
            if (w == true) 
            {
                GorillaLocomotion.Player.Instance.rightHandSurfaceOverride.extraVelMaxMultiplier = 1.5f;
                GorillaLocomotion.Player.Instance.rightHandSurfaceOverride.extraVelMultiplier = 1.5f;
                GorillaLocomotion.Player.Instance.leftHandSurfaceOverride.extraVelMultiplier = 1.5f;
                GorillaLocomotion.Player.Instance.leftHandSurfaceOverride.extraVelMaxMultiplier = 1.5f;
            }
            else
            {
                GorillaLocomotion.Player.Instance.rightHandSurfaceOverride.extraVelMaxMultiplier = 1f;
                GorillaLocomotion.Player.Instance.rightHandSurfaceOverride.extraVelMultiplier = 1f;
                GorillaLocomotion.Player.Instance.leftHandSurfaceOverride.extraVelMultiplier = 1f;
                GorillaLocomotion.Player.Instance.leftHandSurfaceOverride.extraVelMaxMultiplier = 1f;
            }
        }

        public static void TagAll()
        {
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.Contains("fected") && Time.deltaTime > TagAllVar + 0.5f)
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = false;
                    if (!vrrig.mainSkin.material.name.Contains("fected"))
                    {
                        GorillaTagger.Instance.offlineVRRig.transform.position = vrrig.transform.position;
                    }
                    TagAllVar = Time.deltaTime;
                }
                if (GorillaParent.instance.vrrigs.All(vrrig => vrrig.mainSkin.material.name.Contains("fected")))
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = true;
                    GetIndex("Tag All").enabled = false;
                }
            }
        }

        public static void SuperMonk()
        {
            if (ControllerInputPoller.instance.rightControllerSecondaryButton)
            {
                GorillaLocomotion.Player.Instance.transform.position += GorillaLocomotion.Player.Instance.headCollider.transform.forward * Time.deltaTime * 15;
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }
        public static void NoGrav()
        {
            if (ControllerInputPoller.instance.rightControllerPrimaryButton)
            {
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().AddForce(Vector3.up * 10f, ForceMode.Acceleration);
            }
        }

        public static void FlickTagGun()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                RaycastHit hit;
                if (Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position - GorillaLocomotion.Player.Instance.rightControllerTransform.up, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out hit))
                {
                    GameObject pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    pointer.gameObject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    UnityEngine.GameObject.Destroy(pointer.gameObject.GetComponent<SphereCollider>());
                    pointer.gameObject.transform.position = hit.point;
                    pointer.gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
                    UnityEngine.GameObject.Destroy(pointer, Time.deltaTime);
                    if (ControllerInputPoller.instance.rightControllerIndexFloat == 1f)
                    {
                        pointer.gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
                        GorillaLocomotion.Player.Instance.rightControllerTransform.position = hit.point + new Vector3(0f, 0.3f, 0f);
                    }
                }
            }
        }
    }
    public class Visuals : MonoBehaviour
    {
        public static void Beacons()
        {
            foreach (VRRig item in GorillaParent.instance.vrrigs)
            {
                //
                if (!item.isOfflineVRRig && !item.isMyPlayer)
                {
                    if(Beacon == null)
                    {
                        Beacon = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                        Beacon.transform.rotation = Quaternion.identity;
                        Beacon.transform.localScale = new Vector3(0.05f, 1000, 0.05f);
                    }

                    Beacon.transform.position = item.transform.position;
                    MeshRenderer r = Beacon.AddComponent<MeshRenderer>();
                    r.material = item.mainSkin.material;
                    r.material.color = item.mainSkin.material.color;


                    GameObject.Destroy(r.GetComponent<Rigidbody>());
                    GameObject.Destroy(r.GetComponent<Rigidbody2D>());
                    GameObject.Destroy(Beacon, Time.deltaTime);
                }
            }
          
            
        }
    }
}
