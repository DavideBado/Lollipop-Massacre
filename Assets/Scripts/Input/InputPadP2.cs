using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WindowsInput;

public class InputPadP2 : MonoBehaviour
{
	InputSimulator m_InputSimulator = new InputSimulator();

	public void Right()
	{
		m_InputSimulator.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.RIGHT);
	}

	public void Left()
	{
		m_InputSimulator.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.LEFT);
	}
	
	public void Up()
	{
		m_InputSimulator.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.UP);
	}

	public void Down()
	{
		m_InputSimulator.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.DOWN);
	}

	public void Submit()
	{
		m_InputSimulator.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.RCONTROL);
	}

	public void Canc()
	{
		m_InputSimulator.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.NUMPAD9);
	}
}
