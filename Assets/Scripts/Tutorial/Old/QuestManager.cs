using UnityEngine;
using System.Collections;
using System; 

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance = null;

    #region Actions
    public Action StartQuest;
    public Action GoalComplete;
    public Action QuestComplete;
    #endregion

    //Awake is always called before any Start functions
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
}
  