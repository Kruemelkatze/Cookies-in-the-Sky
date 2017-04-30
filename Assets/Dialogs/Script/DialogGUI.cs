using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DialogGUI : MonoBehaviour
{
    private VIDE_Assign dialog;
    private string InitialDialog;

    public bool UseInitialDialog = true;
    public List<string> PendingDialogs;

    public bool HasDialog
    {
        get
        {
            return PendingDialogs.Any();

        }
    }

    // Use this for initialization
    void Start()
    {
        dialog = GetComponent<VIDE_Assign>();
        PendingDialogs = new List<string>();

        InitialDialog = dialog.assignedDialogue;
        if (UseInitialDialog)
            PendingDialogs.Add(dialog.assignedDialogue);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player") && PendingDialogs.Any())
            StartConversation();
    }

    void StartConversation()
    {
        if (!VIDE_Data.inScene)
        {
            Debug.LogError("No VIDE_Data component in scene!");
            return;
        }

        VIDE_Data.EndDialogue();
        
        var nextDialogName = PendingDialogs.First();
        dialog.AssignNew(nextDialogName);

        if (!VIDE_Data.isLoaded && dialog.assignedDialogue != null)
        {
            //... and use it to begin the conversation
            Grid.DiagGui.Begin(dialog);
        }

    }

    public void DeactivateCurrentDialog()
    {
        PendingDialogs.RemoveAt(0);
    }

    public void Reactivate()
    {
        PendingDialogs.Add(InitialDialog);
    }
}
