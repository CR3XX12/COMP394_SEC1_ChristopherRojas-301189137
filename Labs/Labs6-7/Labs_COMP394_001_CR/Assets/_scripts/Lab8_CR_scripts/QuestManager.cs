using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class QuestManager : MonoBehaviour {
    [SerializeField] Quest startingQuest = null;
    [SerializeField] Text objectiveSummary = null;

    QuestStatus activeQuest;

    void Start() {
        if (startingQuest != null)
            StartQuest(startingQuest);
    }

    public void StartQuest(Quest quest) {
        activeQuest = new QuestStatus(quest);
        UpdateObjectiveSummaryText();
        Debug.LogFormat("Started quest {0}", activeQuest.questData.name);
    }

    void UpdateObjectiveSummaryText() {
        objectiveSummary.text = activeQuest?.ToString() ?? "No active quest.";
    }

    public void UpdateObjectiveStatus(Quest quest, int objectiveNumber, Quest.Status status) {
        if (activeQuest == null || activeQuest.questData != quest)
            return;

        activeQuest.objectiveStatuses[objectiveNumber] = status;
        UpdateObjectiveSummaryText();
    }
}

public class QuestStatus {
    public Quest questData;
    public Dictionary<int, Quest.Status> objectiveStatuses;

    public QuestStatus(Quest questData) {
        this.questData = questData;
        objectiveStatuses = new Dictionary<int, Quest.Status>();
        foreach (var objective in questData.objectives)
            objectiveStatuses.Add(objectiveStatuses.Count, objective.initialStatus);
    }

    //public override string ToString() {
       // var output = "";
        //foreach (var obj in questData.objectives)
           // output += $"{obj.name} - {objectiveStatuses[obj.name]}\n";
       // return output;
    //}
}
