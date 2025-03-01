using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class TypingEffect : MonoBehaviour
{
    // ����DialogManager�е�UIԪ��
    public TMP_Text dialogueText; // ������ʾ�Ի���Text���
    public float typingSpeed = 0.075f; // ÿ���ַ���ʾ�ļ��
    private Coroutine typingCoroutine;
    private bool keyEnd=false;
    private DialogManager dialogManager;

    private void Start()
    {
        dialogManager = this.gameObject.GetComponent<DialogManager>();
    }
    // �������ֻ�Ч�������նԻ��ı�����ɫ��������
    public void StartTyping(string textToType)
    {
        // ������������еĴ��ֻ�Ч������ֹͣ��
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        // �����µĴ��ֻ�Ч��Э��
        typingCoroutine = StartCoroutine(ShowText(textToType));
    }

    // ���ֻ�Ч��ʵ�֣�֧�ֻ�ɫ����
    private IEnumerator ShowText(string textToShow)
    {
        // ��StringBuilder�Ż�����
        StringBuilder sb = new StringBuilder();

        // ���û����Ҫ�������ַ���ֱ����ʾ�ı�
        
        

        // ����������ı�������ַ���ʾ
        for (int i = 0; i < textToShow.Length; i++)
        {
            char currentChar = textToShow[i];

            // ֻ����yellowIndices��Ϊ��ʱ��ִ�и�������
           
            sb.Append(currentChar); // ����ǰ�ַ���ӵ��ַ�����������
            dialogueText.text = sb.ToString(); // ����Text�������
            yield return new WaitForSeconds(typingSpeed); // ���ƴ����ٶ�
        }

        // ����ı�����ʱ�����ڸ���״̬���رո���
        
       
        dialogManager.SetTextComplete(true);
      
    }
}
