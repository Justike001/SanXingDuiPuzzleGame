using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class TypingEffect : MonoBehaviour
{
    // 引用DialogManager中的UI元素
    public TMP_Text dialogueText; // 用来显示对话的Text组件
    public float typingSpeed = 0.075f; // 每个字符显示的间隔
    private Coroutine typingCoroutine;
    private bool keyEnd=false;
    private DialogManager dialogManager;

    private void Start()
    {
        dialogManager = this.gameObject.GetComponent<DialogManager>();
    }
    // 启动打字机效果，接收对话文本及黄色高亮索引
    public void StartTyping(string textToType)
    {
        // 如果有正在运行的打字机效果，先停止它
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        // 启动新的打字机效果协程
        typingCoroutine = StartCoroutine(ShowText(textToType));
    }

    // 打字机效果实现，支持黄色高亮
    private IEnumerator ShowText(string textToShow)
    {
        // 用StringBuilder优化性能
        StringBuilder sb = new StringBuilder();

        // 如果没有需要高亮的字符，直接显示文本
        
        

        // 遍历输入的文本并逐个字符显示
        for (int i = 0; i < textToShow.Length; i++)
        {
            char currentChar = textToShow[i];

            // 只有在yellowIndices不为空时才执行高亮处理
           
            sb.Append(currentChar); // 将当前字符添加到字符串构建器中
            dialogueText.text = sb.ToString(); // 更新Text组件内容
            yield return new WaitForSeconds(typingSpeed); // 控制打字速度
        }

        // 如果文本结束时还处于高亮状态，关闭高亮
        
       
        dialogManager.SetTextComplete(true);
      
    }
}
