using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure; // Required in C#
using System.Linq;
using WindowsInput;

public class XInputTestCS : MonoBehaviour
{
	public int Damage = 0;
	public float Timer = 0f;
	InputSimulator inputSimulator = new InputSimulator();
	bool m_OnInput;
	public int ID;
	List<XInputTestCS> Cubi = new List<XInputTestCS>();
	bool playerIndexSet = false;
	public PlayerIndex playerIndex;
	PlayerIndex IndexForCheck;
	GamePadState state;
	GamePadState prevState;


	// Use this for initialization
	void Start()
	{
		Cubi = FindObjectsOfType<XInputTestCS>().ToList();
		// No need to initialize anything for the plugin
	}

	void FixedUpdate()
	{
		// SetVibration should be sent in a slower rate.
		// Set vibration according to triggers
		//GamePad.SetVibration(playerIndex, state.Triggers.Left, state.Triggers.Right);

		DamageFeedback(Damage);
	}

	// Update is called once per frame
	void Update()
	{
	if(Timer > 0)
	{
			Timer -= Time.deltaTime;
		}
		//CheckIndex();
		//// Find a PlayerIndex, for a single player game
		//// Will find the first controller that is connected ans use it
		//if (!playerIndexSet || !prevState.IsConnected)
		//{
		//	for (int i = 0; i < 4; ++i)
		//	{
		//		PlayerIndex testPlayerIndex = (PlayerIndex)i;
		//		GamePadState testState = GamePad.GetState(testPlayerIndex);
		//		if (testState.IsConnected)
		//		{
		//			Debug.Log(string.Format("GamePad found {0}", testPlayerIndex));
		//			if (IndexForCheck != testPlayerIndex || IndexForCheck == null)
		//			{
		//				playerIndex = testPlayerIndex;
		//				playerIndexSet = true;
		//			}

		//		}
		//	}
		//}

		prevState = state;
		state = GamePad.GetState(playerIndex);

		//// Detect if a button was pressed this frame
		//if (prevState.Buttons.A == ButtonState.Released && state.Buttons.A == ButtonState.Pressed)
		//{
		//	GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value, 1.0f);
		//}
		//// Detect if a button was released this frame
		//if (prevState.Buttons.A == ButtonState.Pressed && state.Buttons.A == ButtonState.Released)
		//{
		//	GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
		//}

		// Make the current object turn
		// transform.localRotation *= Quaternion.Euler(0.0f, state.ThumbSticks.Left.X * 25.0f * Time.deltaTime, 0.0f);
		//Debug.Log("dpad" + state.DPad.Down);
		GamePadDPad m_dPad = state.DPad;

        #region Movimento in game
        if (state.ThumbSticks.Left.X > 0 && (-0.3f < state.ThumbSticks.Left.Y && state.ThumbSticks.Left.Y < 0.3f)/* m_dPad.Right.Equals(ButtonState.Pressed) && m_OnInput == true*/ && GetComponent<EventSystemCustom>() == null)
        {
            SendMessage("Right");
            m_OnInput = false;
        }
        if (state.ThumbSticks.Left.X < 0 && (-0.3f < state.ThumbSticks.Left.Y && state.ThumbSticks.Left.Y < 0.3f)/*m_dPad.Left.Equals(ButtonState.Pressed) && m_OnInput == true*/  && GetComponent<EventSystemCustom>() == null)
        {
            SendMessage("Left");
            m_OnInput = false;
        }
        if (state.ThumbSticks.Left.Y > 0 && (-0.3f < state.ThumbSticks.Left.X && state.ThumbSticks.Left.X < 0.3f)/*m_dPad.Up.Equals(ButtonState.Pressed) && m_OnInput == true*/  && GetComponent<EventSystemCustom>() == null)
        {
            SendMessage("Up");
            m_OnInput = false;
        }
        if (state.ThumbSticks.Left.Y < 0 && (-0.3f < state.ThumbSticks.Left.X && state.ThumbSticks.Left.X < 0.3f)/*m_dPad.Down.Equals(ButtonState.Pressed) && m_OnInput == true*/  && GetComponent<EventSystemCustom>() == null)
        {
            SendMessage("Down");
            m_OnInput = false;
        }
        #endregion

        #region Movimento in menu
        if (state.ThumbSticks.Left.X > 0/* m_dPad.Right.Equals(ButtonState.Pressed) && m_OnInput == true*/  && GetComponent<EventSystemCustom>() != null && m_OnInput == true)
        {

            SendMessage("Right");
            m_OnInput = false;
        }
        if (state.ThumbSticks.Left.X < 0/*m_dPad.Left.Equals(ButtonState.Pressed) && m_OnInput == true*/ && GetComponent<EventSystemCustom>() != null && m_OnInput == true)
        {
            SendMessage("Left");
            m_OnInput = false;
        }
        if (state.ThumbSticks.Left.Y > 0/*m_dPad.Up.Equals(ButtonState.Pressed) && m_OnInput == true*/  && GetComponent<EventSystemCustom>() != null && m_OnInput == true)
        {
            SendMessage("Up");
            m_OnInput = false;
        }
        if (state.ThumbSticks.Left.Y < 0/*m_dPad.Down.Equals(ButtonState.Pressed) && m_OnInput == true*/ && GetComponent<EventSystemCustom>() != null && m_OnInput == true)
        {
            SendMessage("Down");
            m_OnInput = false;
        }
        #endregion

        #region Rotazione
        if (state.ThumbSticks.Right.X > 0/* m_dPad.Right.Equals(ButtonState.Pressed)*/ && m_OnInput == true)
        {

            SendMessage("Right");

            m_OnInput = false;
        }
        if (state.ThumbSticks.Right.X < 0/*m_dPad.Left.Equals(ButtonState.Pressed)*/ && m_OnInput == true)
        {
            SendMessage("Left");
            m_OnInput = false;
        }
        if (state.ThumbSticks.Right.Y > 0/*m_dPad.Up.Equals(ButtonState.Pressed)*/ && m_OnInput == true)
        {
            SendMessage("Up");
            m_OnInput = false;
        }
        if (state.ThumbSticks.Right.Y < 0/*m_dPad.Down.Equals(ButtonState.Pressed)*/ && m_OnInput == true)
        {
            SendMessage("Down");
            m_OnInput = false;
        } 
        #endregion
        if (state.ThumbSticks.Right.Y == 0 && state.ThumbSticks.Right.X == 0 && state.ThumbSticks.Left.Y == 0 && state.ThumbSticks.Left.X == 0)
		{
			m_OnInput = true;
		}
		if (prevState.Buttons.A == ButtonState.Released && state.Buttons.A == ButtonState.Pressed)
		{
			SendMessage("Submit");
			SendMessage("BasicAttack");
		}

		if (prevState.Buttons.B == ButtonState.Released && state.Buttons.B == ButtonState.Pressed)
		{
			SendMessage("Canc");
            SendMessage("Switch_Down");

        }

		if (prevState.Buttons.Y == ButtonState.Released && state.Buttons.Y == ButtonState.Pressed)
		{
			SendMessage("Switch_Up");
		}

        if (prevState.Buttons.X == ButtonState.Released && state.Buttons.X == ButtonState.Pressed)
		{
			SendMessage("Ability");
		}

		if (prevState.Buttons.RightShoulder == ButtonState.Released && state.Buttons.RightShoulder == ButtonState.Pressed)
		{
			SendMessage("BasicAttack");
		}

        if (prevState.Buttons.LeftShoulder == ButtonState.Released && state.Buttons.LeftShoulder == ButtonState.Pressed)
		{
			SendMessage("TeleportMe");
		}        

        if (state.Triggers.Right > 0 && prevState.Triggers.Right == 0)
		{
			SendMessage("Ability");
		}

		if (state.Triggers.Left > 0)
		{
			SendMessage("Preview");
		}

		if (prevState.Buttons.Start == ButtonState.Released && state.Buttons.Start == ButtonState.Pressed && GetComponent<Agent>() != null && GetComponent<Agent>().MyTurn == true)
		{
			inputSimulator.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_P);
		}
	}

	//void OnGUI()
	//{
	//    string text = "Use left stick to turn the cube, hold A to change color\n";
	//    text += string.Format("IsConnected {0} Packet #{1}\n", state.IsConnected, state.PacketNumber);
	//    text += string.Format("\tTriggers {0} {1}\n", state.Triggers.Left, state.Triggers.Right);
	//    text += string.Format("\tD-Pad {0} {1} {2} {3}\n", state.DPad.Up, state.DPad.Right, state.DPad.Down, state.DPad.Left);
	//    text += string.Format("\tButtons Start {0} Back {1} Guide {2}\n", state.Buttons.Start, state.Buttons.Back, state.Buttons.Guide);
	//    text += string.Format("\tButtons LeftStick {0} RightStick {1} LeftShoulder {2} RightShoulder {3}\n", state.Buttons.LeftStick, state.Buttons.RightStick, state.Buttons.LeftShoulder, state.Buttons.RightShoulder);
	//    text += string.Format("\tButtons A {0} B {1} X {2} Y {3}\n", state.Buttons.A, state.Buttons.B, state.Buttons.X, state.Buttons.Y);
	//    text += string.Format("\tSticks Left {0} {1} Right {2} {3}\n", state.ThumbSticks.Left.X, state.ThumbSticks.Left.Y, state.ThumbSticks.Right.X, state.ThumbSticks.Right.Y);
	//    GUI.Label(new Rect(0, 0, Screen.width, Screen.height), text);
	//}

	void CheckIndex()
	{
		foreach (XInputTestCS _tester in Cubi)
		{
			if (_tester != this)
			{
				IndexForCheck = _tester.playerIndex;
			}
		}

	}

	public void DamageFeedback(int _damage)
	{


		if (Timer > 0)
		{

			if (_damage == 1)
			{
				GamePad.SetVibration(playerIndex, 1, 0);
			}
			else if (_damage == 2)
			{
				GamePad.SetVibration(playerIndex, 0, 1);
			}
			else if (_damage > 2)
			{
				GamePad.SetVibration(playerIndex, 1, 1);
			}
		} 
		
		else
		{
			GamePad.SetVibration(playerIndex, 0, 0);
		}


	}
}

