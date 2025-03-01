using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Animations;

[CreateAssetMenu(fileName = "NewConversation", menuName = "ScriptableObjects/Conversation", order = 2)]
public class Conversation : ScriptableObject
{

    public ConversationEntry[] entries;
   

    [System.Serializable]
    public class ConversationEntry
    {
        public string txtName;
        public string txtShow;
        public string txtPS;
 
    }

   
   

}
