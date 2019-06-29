using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.EventSystems;

namespace Tutorial
{
    abstract class QuestBase : MonoBehaviour
    {
        public Sprite MyStartMessage;
        public Sprite MyCompletetMessage;
        public Image QuestMessage;

        public virtual bool GoalCheck()
        {
            return true;
        }

        private void QuestCheck(QuestState _questState)
        {
            switch (_questState)
            {
                case QuestState.StartQuest:
                    {
                        QuestMessage.sprite = MyStartMessage;
                        QuestMessage.enabled = true;
                    }
                    break;
                case QuestState.RunQuest:
                    {
                        QuestMessage.enabled = false;
                        if(GoalCheck())
                        {
                            QuestManager.instance.GoalComplete();
                        }
                    }
                    break;
                case QuestState.CompleteQuest:
                    {
                        if (MyCompletetMessage != null)
                        {
                            QuestMessage.sprite = MyCompletetMessage;
                            QuestMessage.enabled = true;
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        enum QuestState
        {
            StartQuest,
            RunQuest,
            CompleteQuest
        }
    }
}
