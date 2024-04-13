using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace MonkeModMenu.Misc
{
    internal class Variables
    {
        public static bool Doonce = true;
        public static float Teletime;

        public static float minlag;


        public static float maxlag;

        public static GradientColorKey[] colorKeys;

        public static bool ResetSpeed = false;

        public static int bigmonkecooldown;

        public static GameObject hud;

        public static bool gripDown;

        public static bool primaryRightDown;

        public static GameObject menu = null;

        public static GameObject canvasObj = null;

        public static GameObject reference = null;

        public static int framePressCooldown = 0;

        public static GameObject pointer = null;

        public static bool gravityToggled = false;

        public static bool flying = false;

        public static int soundCooldown = 0;

        public static float? maxJumpSpeed = null;

        public static float? jumpMultiplier = null;

        public static string githubversion = null;

        public static object index;

        public static int BlueMaterial = 5;

        public int NotificationDecayTime = 150;

        public int NotificationDecayTimeCounter;

        public string[] Notifilines;

        public string newtext;

        public static string PreviousNotifi;

        public bool HasInit;

        public static bool Slip = true;

        public static int TransparentMaterial = 6;

        public static int LavaMaterial = 2;

        public static int RockMaterial = 1;

        public static int DefaultMaterial = 5;

        public static int NeonRed = 3;

        public static int RedTransparent = 4;

        public static int self = 0;

        public static Vector3? leftHandOffsetInitial = null;

        public static Vector3? rightHandOffsetInitial = null;

        public static float? maxArmLengthInitial = null;

        public static bool noClipDisabledOneshot = false;

        public static bool noClipEnabledAtLeastOnce = false;

        public static Vector3 head_direction;

        public static Vector3 roll_direction;

        public static Vector2 left_joystick;

        public static float acceleration;

        public static float maxs;

        public static float distance;

        public static float multiplier;

        public static float speed;

        public static bool Start;

        public static bool ghostToggle = false;

        public static bool bigMonkeyEnabled = false;

        public static bool bigMonkeAntiRepeat = false;

        public static int bigMonkeCooldown = 0;

        public static bool ghostMonkeEnabled = false;

        public static bool ghostMonkeAntiRepeat = false;

        public static int ghostMonkeCooldown = 0;

        public static bool checkedProps = false;

        public static bool teleportGunAntiRepeat = false;

        public static Color colorRgbMonke = new Color(0f, 0f, 0f);

        public static float hueRgbMonke = 0f;

        public static float timerRgbMonke = 0f;

        public static float updateRateRgbMonke = 0f;

        public static float updateTimerRgbMonke = 0f;

        public static Vector3? checkpointPos;

        public static bool checkpointTeleportAntiRepeat = false;

        public static bool foundPlayer = false;

        public static int btnTagSoundCooldown = 0;

        public static float timeSinceLastChange = 0f;

        public static float myVarY1 = 0f;

        public static float myVarY2 = 0f;

        public static bool gain = false;

        public static bool less = false;

        public static GameObject C4;

        public static bool spawned;

        public static float SpawnGrip;

        public static float BoomGrip;

        public static float rSpawnGrip;

        public static float rBoomGrip;

        public static bool reset = false;

        public static bool fastr = false;

        public static Color color;

        public static bool speed1 = true;

        public static float gainSpeed = 1f;

        public static float bigScale = 2f;

        public static int pageSize = 10;

        public static int pageNumber = 0;

        public static float updateRate;

        public static float updateTimer;

        public static GameObject GtagPlayer = GameObject.Find("Gorilla Player");
        public static GameObject Beacon;
        public static Material UberShader = new Material(Shader.Find("GorillaTag/UberShader"));
        public static float timer;
        public static bool RIGHTTTT = true;
        public static bool LEFTTTT = true;
        public static GameObject LObject;
        public static GameObject ROject;
        public static float TagAllVar;
        public static float delay2;
        public static float delay22;
        public static float delay3;
        public static bool ddddd = true;
        public static GameObject rig = null;
        public static GameObject rig1 = null;
        public static GameObject lineObject = null;
        public static bool InvisToggle = false;
        public static GameObject BombObject = null;
        public static bool Bombbby = true;
        public static float hue;

        public static bool DoOneTime = false;

        public static int layers;

        public static bool up;

        public static bool down;
        public static object NotifiLib;

        public static object RigManager { get; private set; }











        public class TimedBehaviour : MonoBehaviour
        {
            public virtual void Start()
            {
                this.startTime = Time.time;
            }
            public virtual void Update()
            {
                bool flag = this.complete;
                if (!flag)
                {
                    this.progress = Mathf.Clamp((Time.time - this.startTime) / this.duration, 0f, 1.5f);
                    bool flag2 = (double)Time.time - (double)this.startTime > (double)this.duration;
                    if (flag2)
                    {
                        bool flag3 = this.loop;
                        if (flag3)
                        {
                            this.OnLoop();
                        }
                        else
                        {
                            this.complete = true;
                        }
                    }
                }
            }
            public virtual void OnLoop()
            {
                this.startTime = Time.time;
            }
            public bool complete = false;
            public bool loop = true;
            public float progress = 0f;
            protected bool paused = false;
            protected float startTime;
            protected float duration = 2f;
        }
        public class ColorChanger : TimedBehaviour
        {
            public override void Start()
            {
                base.Start();
                this.gameObjectRenderer = base.GetComponent<Renderer>();
            }
            public override void Update()
            {
                base.Update();
                if (this.colors != null && gameObjectRenderer != null)
                {
                    this.gameObjectRenderer.material.color = color;
                    this.gameObjectRenderer.material.SetColor("_Color", this.color);
                    this.gameObjectRenderer.material.SetColor("_EmissionColor", this.color);
                }
                if (this.timeBased)
                {
                    this.color = this.colors.Evaluate(this.progress);
                }
            }
            public Renderer gameObjectRenderer;
            public Gradient colors = null;
            public Color color;
            public bool timeBased = true;
        }




    }
}
