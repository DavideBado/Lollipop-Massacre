using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public List<GamePlayInput> GPInputs = new List<GamePlayInput>();
    public GamePlayInput GPInput;
    public MenuInput MNInput;
    public InputBase currentInput;

    public void ChangeInput(InputMgrType _input)
    {
        switch (_input)
        {
            case InputMgrType.MenuInput:
                currentInput = MNInput;
                break;
            case InputMgrType.GameplayInput:
                currentInput = GPInput;
                break;
            default:
                break;
        }
        ActiveInput(currentInput);
    }

 

    public void Setup()
    {
        MNInput = GetComponent<MenuInput>();
        foreach (GamePlayInput _gpinput in GPInputs)
        {
            if(_gpinput.InputID == 1)
            {
                GPInput = _gpinput;
            }
        }
    }

    public void ActiveInput(InputBase _input)
    {
        _input.enabled = true;
        currentInput = _input;

    }

    public void DeactiveInput(InputBase _input)
    {
        if (_input != null)
        {
            _input.enabled = false;
        }
    }
}

public enum InputMgrType
{
    MenuInput,
    GameplayInput
}
