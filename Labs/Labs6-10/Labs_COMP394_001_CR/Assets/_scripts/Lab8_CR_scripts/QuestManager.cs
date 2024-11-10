using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

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
        Debug.LogFormat("Started quest {0}", activeQuest.questData.questName);
    }

    void UpdateObjectiveSummaryText() {
    string text = activeQuest?.ToString() ?? "No active quest.";
    Debug.Log("Updating UI with text: " + text);
    objectiveSummary.text = text;
}


    public void UpdateObjectiveStatus(Quest quest, int objectiveNumber, Quest.Status status) {
        if (activeQuest == null || activeQuest.questData != quest)
            return;
            Debug.Log($"Updating objective {objectiveNumber} to status {status}");

        // Update the objective status by its integer index
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
        
        // Initialize the objectiveStatuses dictionary using integer indices
        for (int i = 0; i < questData.objectives.Count; i++) {
            objectiveStatuses[i] = questData.objectives[i].initialStatus;
        }
    }

    public override string ToString() {
    var output = new System.Text.StringBuilder();
    
    for (int i = 0; i < questData.objectives.Count; i++) {
        var objective = questData.objectives[i];
        var status = objectiveStatuses[i];
        
        output.AppendFormat("{0} - {1}\n", objective.name, status);
    }
    
    output.AppendLine();
    output.AppendFormat("Status: {0}", questStatus.ToString());
    return output.ToString();
}


    // Determine the status of the entire quest
    public Quest.Status questStatus {
        get {
            for (int i = 0; i < questData.objectives.Count; i++) {
                var objective = questData.objectives[i];
                
                // Skip optional objectives in determining the overall status
                if (objective.optional) continue;

                // Check the status of each non-optional objective
                if (objectiveStatuses[i] == Quest.Status.Failed)
                    return Quest.Status.Failed;

                if (objectiveStatuses[i] != Quest.Status.Complete)
                    return Quest.Status.NotYetComplete;
            }

            // All non-optional objectives are complete
            return Quest.Status.Complete;
        }
    }
}
