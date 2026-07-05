using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TalkBar : MonoBehaviour
{
    public TextMeshProUGUI talkUI;
    public Animator animator;
    public Image Image;

    private bool end, _end;

    private int _talkIndex = 0;
    private List<string> _talkTexts;

    private float _talkTime;
    public void Init(bool startOrEnd)
    {
        if (startOrEnd)
        {
            _talkTexts = new List<string>
            {
                "父亲死在这片海...",
                "他最后一个离船...",
                "却再也没有回来...",
                "有人说他是个疯子...",
                "有人说他太固执...",
                "不肯放弃船...",
                "也有人说...",
                "如果他早点撤离...",
                "一切都不会发生...",
                "今天...",
                "我要下去看看",
                //"这片海域据说受到了神秘的诅咒，请勿触碰岩壁，否则可能触发穿越次元壁的打击。"
            };
        }
        else
        {
            end = true;
            _talkTexts = new List<string>
            {
                "报道说，",
                "父亲是个疯子。",
                "可海底留下的，",
                "是另一个故事。",
                "断锚嵌进岩缝。",
                "绞盘烧毁。",
                "锁杆被压到底。",
                "舱门在他身后变形。",
                "他不是为了救回那艘船。",
                "他只是要让它停住。",
                "停到救生艇放下。",
                "停到其他人能离开。",
                "黑暗里，",
                "鱼群开始向上游去。",
                "我放开父亲的断锚，",
                "握住自己的锚链。",
                "父亲的锚留在海底。",
                "我的锚，",
                "带我回家。",
                "Fin"
            };
        }
        _talkIndex = -1;
    }
    public void TalkTick()
    {
        _talkIndex++;

        if (_talkIndex >= _talkTexts.Count)
        {
            if (end == true)
            {
                Image.gameObject.SetActive(true);
                _end = true;
            }
            else gameObject.SetActive(false);
        }
        animator.SetTrigger("Update");
    }
    public void TalkGoon_AnimationEvent()
    {
        try
        {
            talkUI.text = _talkTexts[_talkIndex];
        }
        catch { }
    }
    private void Update()
    {
        if (_end && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("StartGame");
        }

        if (_talkTime <= 0 && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            _talkTime = 0.5f;

            TalkTick();

        }
        else
        {
            _talkTime -= Time.deltaTime;
        }
    }
}
