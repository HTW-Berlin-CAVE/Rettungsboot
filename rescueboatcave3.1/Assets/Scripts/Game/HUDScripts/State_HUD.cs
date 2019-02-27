using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_HUD: MonoBehaviour {

    public GameObject ship;
	public Color hudColor;
	public float timeDuringPOST;
	public float timeDuringTotalBoot;


	public int activeHud;

	private short course;
	private string displayedCourse;

	private Vector3 lastPosition;
	private float speed;
	private string displayedSpeed;

	private float depth;
	private string displayedDepth;

	private bool radioContact;
	private bool radioConnection;
	private float connectionBuildUp;
	private float radioLevel;

	private bool collisionWarning;

	private float bootTime;
	public bool hudLock;
	private bool postPhase;
	private bool bootPhase;

	private DateTime startTime;
	private TimeSpan passedTime;
	private string passedTimeLabel;

	private byte oxygenLevel;
	private string oxygenLevelLabel;

	private byte batteryLevel;
	private string batteryLevelLabel;

	private byte pressureLevel;
	private string pressureLevelLabel;

	private byte hullLevel;
	private string hullLevelLabel;

	private bool boardPcCondition;
	private string boardPcConditionLabel;

	private bool autoPilotCondition;
	private string autoPilotConditionLabel;

	private bool engineCondition;
	private string engineConditionLabel;

	private bool rescSignalCondition;
	private string rescSignalConditionLabel;

	private bool radioCondition;
	private string radioConditionLabel;

	private bool craneCondition;

    void start() {
        startTime = DateTime.Now;
        activeHud = 0;
        bootTime = 0;
        postPhase = true;
        bootPhase = false;
        hudLock = true;
        craneCondition = false;
       // TextIdleStartUp idlestartup = GameObject.FindObjectOfType<TextIdleStartUp>();
       // StartCoroutine(idlestartup.Booting(timeDuringPOST, timeDuringTotalBoot));
    }

    public void setShip(GameObject ship)
    {
        this.ship = ship;
        lastPosition = ship.transform.position;
    }
	public Color HudColor
	{
		get
		{
			return hudColor;
		}
	}

	public int Hud
	{
		get
		{
			return activeHud;
		}
	}

	public string Course 
	{
		get
		{
			return displayedCourse;
		}
	}

	public string Speed
	{
		get
		{
			return displayedSpeed;
		}
	}

	public string Depth
	{
		get
		{
			return displayedDepth;
		}
	}

	public bool RadioContact
	{
		get
		{
			return radioContact;
		}
		set
		{
			radioContact = value;
		}
	}

	public bool RadioConnection
	{
		get
		{
			return radioConnection;
		}
	}

	public byte RadioLevel
	{
		get
		{
			return (byte) radioLevel;
		}
	}

	public bool CollisionWarning
	{
		get
		{
			return collisionWarning;
		}
		set
		{
			collisionWarning = value;
		}
	}

	public float TimeDuringPOST
	{
		get
		{
			return timeDuringPOST;
		}
	}

	public float TimeDuringTotalBoot
	{
		get
		{
			return timeDuringTotalBoot;
		}
	}

	public bool HudLock
	{
		get
		{
			return hudLock;
		}
	}
 

	public bool POSTPhase
	{
		get
		{
			return postPhase;
		}
	}

	public bool BootPhase
	{
		get
		{
			return bootPhase;
		}
	}

	public TimeSpan PassedTime
	{
		get
		{
			return passedTime;
		}
	}

	public string PassedTimeLabel	
	{
		get
		{
			return passedTimeLabel;
		}
	}

	public byte OxygenLevel
	{
		get
		{
			return oxygenLevel;
		}
		set
		{
			oxygenLevel = value;
		}
	}

	public string OxygenLevelLabel
	{
		get
		{
			return oxygenLevelLabel;
		}
	}

	public byte BatteryLevel
	{
		get
		{
			return batteryLevel;
		}
		set
		{
			batteryLevel = value;
		}
	}

	public string BatteryLevelLabel
	{
		get
		{
			return batteryLevelLabel;
		}
	}

	public byte PressureLevel
	{
		get
		{
			return pressureLevel;
		}
		set
		{
			pressureLevel = value;
		}
	}

	public string PressureLevelLabel
	{
		get
		{
			return pressureLevelLabel;
		}

	}

	public byte HullLevel
	{
		get
		{
			return hullLevel;
		}
		set
		{
			hullLevel = value;
		}
	}

	public string HullLevelLabel
	{
		get
		{
			return hullLevelLabel;
		}
	}

	public bool BoardPcCondition
	{
		get
		{
			return boardPcCondition;
		}
		set
		{
			boardPcCondition = value;
		}
	}

	public string BoardPcConditionLabel
	{
		get
		{
			return boardPcConditionLabel;
		}
	}

	public bool AutoPilotCondition
	{
		get
		{
			return autoPilotCondition;
		}
		set
		{
			autoPilotCondition = value;
		}
	}

	public string AutoPilotConditionLabel
	{
		get
		{
			return autoPilotConditionLabel;
		}
	}

	public bool EngineCondition
	{
		get
		{
			return engineCondition;
		}
		set
		{
			engineCondition = value;
		}
	}

	public string EngineConditionLabel
	{
		get
		{
			return engineConditionLabel;
		}
	}

	public bool RescSignalCondition
	{
		get
		{
			return rescSignalCondition;
		}
		set
		{
			rescSignalCondition = value;
		}
	}

	public string RescSignalConditionLabel
	{
		get
		{
			return rescSignalConditionLabel;
		}
	}

	public bool RadioCondition
	{
		get
		{
			return radioCondition;
		}
		set
		{
			radioCondition = value;
		}
	}

	public string RadioConditionLabel
	{
		get
		{
			return radioConditionLabel;
		}
	}

	public bool CraneCondition
	{
		get
		{
			return craneCondition;
		}
		set
		{
			craneCondition = value;
		}
	}
			

	
	

	void Update () {
		//CheckHudSelection();
	/*	Test_CheckRadioContact();
		Test_CheckCollisionWarning();
		Test_CheckOxygenLevel();
		Test_CheckBatteryLevel();
		Test_CheckPressureLevel();
		Test_CheckHullLevel();
		Test_CheckBoardPcCondition();
		Test_CheckAutoPilotCondition();
		Test_CheckEngineCondition();
		Test_CheckRescSignalCondition();
		Test_CheckRadioCondition();
		Text_CheckCraneCondition();
		*/
        RunThroughStartUp();
		CheckRadioContact();
		AscertainCourse();
		AscertainSpeed();
		AscertainDepth();
		AscertainTime();
		PutOxygenLevelLabel();
		PutBatteryLevelLabel();
		PutPressureLevelLabel();
		PutHullLevelLabel();
		PutBoardPcConditionLabel();
		PutAutoPilotConditionLabel();
		PutEngineConditionLabel();
		PutRescSignalConditionLabel();
		PutRadioConditionLabel();
	}
    /*
	private void CheckHudSelection()
	{
		if (HudLock == false)
		{
            if (wii != null)
            {
                if (wii.buttonB()){

                    if (activeHud == 0)
                    {
                        //start board system start up function
                        activeHud = 3;
                    }

                    if (activeHud == 1)
                    {
                        activeHud = 3;
                    }
                    else
                    {
                        activeHud -= 1;
                    }
                }
             }
            if (Input.GetKeyDown(KeyCode.Alpha1))
                //if (wii.buttonB())
			{
                
                if (activeHud == 0)
				{
					//start board system start up function
					activeHud = 3;
				}

				if (activeHud == 1)
				{
					activeHud = 3;
				}
				else
				{
					activeHud -= 1;
				}
			}
			if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				if (activeHud == 0)
				{
					//start board system start up fuction
					activeHud = 3;
				}

				if (activeHud == 3)
				{
					activeHud = 1;
				}
				else
				{
					activeHud += 1;
				}
			}
		}
	}
    
	private void Test_CheckCollisionWarning()
	{
		if (Input.GetKeyDown(KeyCode.D))
		{
			this.CollisionWarning = true;
		}
		if (Input.GetKeyDown(KeyCode.F))
		{
			this.CollisionWarning = false;
		}
	}

	private void Test_CheckRadioContact()
	{
		if (Input.GetKeyDown(KeyCode.A))
		{
			this.RadioContact = true;
		}
		if (Input.GetKeyDown(KeyCode.S))
		{
			this.RadioContact = false;
		}
	}

	private void Test_CheckOxygenLevel() 
	{
		if (Input.GetKey(KeyCode.G))
		{
			this.OxygenLevel += 1;
		}
		if (Input.GetKey(KeyCode.H))
		{
			this.OxygenLevel -= 1;
		}
	}

	private void Test_CheckBatteryLevel()
	{
		if (Input.GetKey(KeyCode.G))
		{
			this.BatteryLevel += 1;
		}
		if (Input.GetKey(KeyCode.H))
		{
			this.BatteryLevel -= 1;
		}
	}

	private void Test_CheckPressureLevel()
	{
		if (Input.GetKey(KeyCode.G))
		{
			this.PressureLevel += 1;
		}
		if (Input.GetKey(KeyCode.H))
		{
			this.PressureLevel -= 1;
		}
	}

	private void Test_CheckHullLevel()
	{
		if (Input.GetKey(KeyCode.G))
		{
			this.HullLevel += 1;
		}
		if (Input.GetKey(KeyCode.H))
		{
			this.HullLevel -= 1;
		}
	}

	private void Test_CheckBoardPcCondition()
	{
		if (Input.GetKeyDown(KeyCode.J))
		{
			this.BoardPcCondition = true;
		}
		if (Input.GetKeyDown(KeyCode.K))
		{
			this.BoardPcCondition = false;
		}
	}

	private void Test_CheckAutoPilotCondition()
	{
		if (Input.GetKeyDown(KeyCode.J))
		{
			this.AutoPilotCondition = true;
		}
		if (Input.GetKeyDown(KeyCode.K))
		{
			this.AutoPilotCondition = false;
		}
	}

	private void Test_CheckEngineCondition()
	{
		if (Input.GetKeyDown(KeyCode.J))
		{
			this.EngineCondition = true;
		}
		if (Input.GetKeyDown(KeyCode.K))
		{
			this.EngineCondition = false;
		}
	}

	private void Test_CheckRescSignalCondition()
	{
		if (Input.GetKeyDown(KeyCode.J))
		{
			this.RescSignalCondition = true;
		}
		if (Input.GetKeyDown(KeyCode.K))
		{
			this.RescSignalCondition = false;
		}
	}

	private void Test_CheckRadioCondition()
	{
		if (Input.GetKeyDown(KeyCode.J))
		{
			this.RadioCondition = true;
		}
		if (Input.GetKeyDown(KeyCode.K))
		{
			this.RadioCondition = false;
		}
	}

	private void Text_CheckCraneCondition()
	{
		if (Input.GetKeyDown(KeyCode.O))
		{
			this.CraneCondition = true;
		}
		if (Input.GetKeyDown(KeyCode.P))
		{
			this.CraneCondition = false;
		}
	}

    */
	private void RunThroughStartUp()
	{
		if (bootTime < TimeDuringTotalBoot)
		{
			bootTime += Time.deltaTime;
			if (bootTime < timeDuringPOST)
			{
				postPhase = true;
				bootPhase = false;
			}
			if (bootTime > timeDuringPOST && bootTime < timeDuringTotalBoot)
			{
				postPhase = false;
				bootPhase = true;	
			}
			if (bootTime > timeDuringPOST && bootTime > timeDuringTotalBoot)
			{
				postPhase = false;
				bootPhase = false;
				activeHud = 3;
			}
		}
		else
		{
			hudLock = false;
		}
	}

	private void CheckRadioContact()
	{
		if (radioContact == true && radioConnection == false)
		{
			EstablishRadioConnection();
			this.RadioCondition = true;
		}
		if (radioContact == false)
		{
			connectionBuildUp = 0;
			radioLevel = 0;
			radioConnection = false;
		}
	}

	private void EstablishRadioConnection()
	{
		connectionBuildUp += Time.deltaTime;
		//f(x) = (x^2)-((1/4)*x^3)+((1/35000)*x^8)
		radioLevel =  (Mathf.Pow(connectionBuildUp, 2))
			- (((float) 1f/4f) * (Mathf.Pow(connectionBuildUp, 3)))
			+ (((float) 1f/35000f) * (Mathf.Pow(connectionBuildUp, 8)));
		Debug.Log("raw radio level: " + radioLevel + " <- " + connectionBuildUp);
		if (radioLevel > 6)
		{
			radioLevel = 5;
			radioConnection = true;
			this.RescSignalCondition = true;
		}
	}

	private void AscertainCourse()
	{
		float yRotation = ship.transform.eulerAngles.y;
		course = (short) Mathf.Abs(((int) yRotation) % 360);
		displayedCourse = FillWithNought((uint) course, 3);

	}

	private void AscertainSpeed()
	{
		float pastWay = Vector3.Distance(ship.transform.position, lastPosition);
		float pastTime = Time.deltaTime;
		speed = pastWay / pastTime;
		displayedSpeed = FillWithNought((uint) (speed * 25), 3);
		//Debug.Log("past way: " + pastWay);
		//Debug.Log("speed: " + speed);
		lastPosition = ship.transform.position;
	}

	private void AscertainDepth()
	{
		depth = lastPosition.y;
		displayedDepth = FillWithNought((uint) Mathf.Abs(depth * 25), 3);
	}

	private void AscertainTime()
	{

		UpdateTime();
		DepositTime();
	}

	private void UpdateTime()
	{
		//passedTime = new TimeSpan((DateTime.Now - startTime).Ticks * 3); //3x faster
		passedTime = DateTime.Now - startTime;
	}

	private void DepositTime()
	{
		passedTimeLabel
		= FillWithNought((byte) (passedTime.TotalHours % 25), 2) + ":"
			+ FillWithNought((byte) (passedTime.TotalMinutes % 61) , 2) + ":"
				+ FillWithNought((byte) (passedTime.TotalSeconds % 61), 2);

	}

	private void PutOxygenLevelLabel()
	{
		oxygenLevelLabel = FillWithNought(oxygenLevel, 3);
	}

	private void PutBatteryLevelLabel()
	{
		batteryLevelLabel = FillWithNought(batteryLevel, 3);
	}

	private void PutPressureLevelLabel()
	{
		pressureLevelLabel = FillWithNought(pressureLevel, 3);
	}

	private void PutHullLevelLabel()
	{
		hullLevelLabel = FillWithNought(hullLevel, 3);
	}

	private void PutBoardPcConditionLabel()
	{
		boardPcConditionLabel = TranslateBoolean(boardPcCondition);
	}

	private void PutAutoPilotConditionLabel()
	{
		autoPilotConditionLabel = TranslateBoolean(autoPilotCondition);
	}

	private void PutEngineConditionLabel()
	{
		engineConditionLabel = TranslateBoolean(engineCondition);
	}

	private void PutRescSignalConditionLabel()
	{
		rescSignalConditionLabel = TranslateBoolean(rescSignalCondition);
	}

	private void PutRadioConditionLabel()
	{
		radioConditionLabel = TranslateBoolean(radioCondition);
	}


	private string FillWithNought(uint number, byte digitCount)
	{
		string noughtFilled = String.Empty;

		if (number < 10 && digitCount == 2)
		{
			noughtFilled = "0" + number;
		}
		else if (number < 10 && digitCount == 3)
		{
			noughtFilled = "00" + number;
		}
		else if (number < 100 && digitCount == 3)
		{
			noughtFilled = "0" + number;
		}
		else
		{
			noughtFilled = number.ToString();
		}

		return noughtFilled;
	}

	private string TranslateBoolean(bool value)
	{
		return value ? "ON" : "OFF";
	}
}
