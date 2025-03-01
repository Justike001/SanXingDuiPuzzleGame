using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAlone : MonoBehaviour
{
    private DialogManager dialogManager;
    public Conversation conversation;
    // Start is called before the first frame update
    void Start()
    {
        dialogManager = GetComponent<DialogManager>();
        dialogManager.StartDialogue(conversation, () => { });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
