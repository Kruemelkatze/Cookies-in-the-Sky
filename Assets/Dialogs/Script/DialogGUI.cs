using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogGUI : MonoBehaviour
{
    private VIDE_Assign dialog;
    public bool isDeactivated;
    // Use this for initialization
    void Start()
    {
        dialog = GetComponent<VIDE_Assign>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isDeactivated && other.gameObject.layer == LayerMask.NameToLayer("Player"))
            StartConversation();
    }

    void StartConversation()
    {
        if (!VIDE_Data.inScene)
        {
            Debug.LogError("No VIDE_Data component in scene!");
            return;
        }

        if (!VIDE_Data.isLoaded && dialog.assignedDialogue != null)
        {
            //... and use it to begin the conversation
            Grid.DiagGui.Begin(dialog);
        }

    }
}
