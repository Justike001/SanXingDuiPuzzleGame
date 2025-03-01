using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using static Conversation;
using static System.Net.Mime.MediaTypeNames;


public class DialogManager : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text PSText;
    public TMP_Text dialogueText;
    public delegate void DialogueEndEvent();

    private DialogueEndEvent onEndEvent;
    private Conversation currentConversation;
    public int currentEntryIndex;
    public TypingEffect typingEffect;


    public GameObject DialogPanel;

    private bool isTextComplete = false;




    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        
        
        if (Input.GetMouseButtonDown(0) )
        {
            HandlePageNext();
        }
        
    }



    public void StartDialogue(Conversation conversation, DialogueEndEvent endDelegate)
    {
        DialogPanel.gameObject.SetActive(true);
        currentConversation = conversation;
        currentEntryIndex = 0;
        onEndEvent += endDelegate;
        DisplayNextEntry();
    }

    public void StartPrompt(Conversation conversation)
    {
        DialogPanel.gameObject.SetActive(true);
        currentEntryIndex = 0;
        Conversation.ConversationEntry entry=conversation.entries[0];
        if (entry.txtName != null)
            nameText.text = entry.txtName;
        else
            nameText.text = "";

        if (entry.txtPS != null)
            PSText.text = entry.txtPS;
        else
            PSText.text = "";

        string textshow = entry.txtShow;
        dialogueText.text = "<color=#16BEF5>" + textshow + "</color>";
    }

    public void DisplayNextEntry()
    {

        this.gameObject.SetActive(true);

        if (currentEntryIndex >= currentConversation.entries.Length)
        {
            EndDialogue();
            DialogPanel.gameObject.SetActive(false);
            return;
        }

        if (currentEntryIndex < currentConversation.entries.Length)
        {
            Conversation.ConversationEntry entry = currentConversation.entries[currentEntryIndex];
            if (entry.txtName != null)
                nameText.text = entry.txtName;
            else
                nameText.text = "";

            if (entry.txtPS != null)
                PSText.text = entry.txtPS;
            else
                PSText.text = "";
          
            dialogueText.text = "";

            // 调用StartTyping，并传递高亮索引
            typingEffect.StartTyping(entry.txtShow);

        }
        else
        {
            // 对话结束，处理后续操作
            Debug.Log("对话结束");
        }
    }

    private void EndDialogue()
    {

        onEndEvent?.Invoke();
        onEndEvent = null;
    }

    

   

    // 设置文本是否已完成显示
    public void SetTextComplete(bool isComplete)
    {
        isTextComplete = isComplete;
        
    }

    public void HandlePageNext()
    {
        PageAfterVideoOrAnimation(currentConversation.entries[currentEntryIndex]);
    }

    private void PageAfterVideoOrAnimation(Conversation.ConversationEntry entry)
    {
        currentEntryIndex++;
        DisplayNextEntry();
    }

    // 播放视频并等待其完成
   
}
