using UnityEngine.EventSystems;
using UnityEngine;
 
public class EventSystemCustom : EventSystem
{

    protected override void OnEnable()
    {
        base.OnEnable();
    }

    protected override void Update()
    {
        EventSystem originalCurrent = EventSystem.current;
        current = this;
        base.Update();
        current = originalCurrent;
        if (currentSelectedGameObject == null)
        {
            SetSelectedGameObject(firstSelectedGameObject);
        }
        Debug.Log(gameObject.name + currentSelectedGameObject.name);
        currentSelectedGameObject.GetComponent<MyEventSystemProvider>().eventSystem = this;

    }

  
}