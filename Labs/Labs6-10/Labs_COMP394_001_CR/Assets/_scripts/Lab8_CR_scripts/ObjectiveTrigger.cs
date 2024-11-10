using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectiveTrigger {
    public Quest quest;
    public Quest.Status statusToApply;
    public int objectiveNumber;

    public void Invoke() {
        var manager = Object.FindObjectOfType<QuestManager>();
        manager.UpdateObjectiveStatus(quest, objectiveNumber, statusToApply);
    }
}

