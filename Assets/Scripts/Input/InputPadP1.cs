using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WindowsInput;

public class InputPadP1 : MonoBehaviour
{
	InputSimulator m_InputSimulator = new InputSimulator();

	public void Right()
	{
		m_InputSimulator.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_D);
	}

	public void Left()
	{
		m_InputSimulator.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_A);
	}
	
	public void Up()
	{
		m_InputSimulator.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_W);
	}

	public void Down()
	{
		m_InputSimulator.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_S);
	}

	public void Submit()
	{
		m_InputSimulator.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.SPACE);
	}

	public void Canc()
	{
		m_InputSimulator.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_Q);
	}
}
