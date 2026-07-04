using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct StoryData
{
    public int storyIndex;
    public string name;
    public string location;
    public string text;
    public string characterText;
}

public class StoryManager
{
    private int _storyIndex = 0;

    #region 文案数据
    private List<string>_openingScript = new List<string>()
    {
        "父亲死在这片海。",
        "他最后一个离船，\r\n却再也没有回来。\r\n",
        "有人说他是个疯子，\r\n有人说他太固执，\r\n不肯放弃船。\r\n",
        "也有人说，\r\n如果他早点撤离，\r\n一切都不会发生。\r\n",
        "今天，\r\n我要下去看看。\r\n",
    };
    private List<StoryData> _storyDatas = new List<StoryData>()
    {
        new StoryData
        {
            storyIndex = 0,
            name = "残破船名牌",
            location = "浅海残骸区",
            text = "字迹被海水磨掉了一半，还能看见父亲船名的最后几个字母。",
            characterText = "我找到你了"
        },
        new StoryData
        {
            storyIndex = 1,
            name = "父亲的航海日志",
            location = "浅海残骸区",
            text = "风暴比预报提前了六小时。\r\n回港航线被暗流截断。\r\n强行返航，船会横在浪里。\r\n我去绞盘舱。\r\n",
            characterText = "报道只说他拒绝返航。可那条路，可能已经回不去了。"
        },
        new StoryData
        {
            storyIndex = 2,
            name = "海底断锚",
            location = "浅海残骸区",
            text = "它不是掉在这里的，\r\n它是被打进这里的。\r\n",
            characterText = "这是父亲的锚。\r\n如果这只锚曾经拉住过什么，\r\n那一定是很重的东西。\r\n"
        },
        new StoryData
        {
            storyIndex = 3,
            name = "手动锁杆",
            location = "烧毁的锚链绞盘旁边",
            text = "手动锁杆被压到了底。\r\n固定销弯曲变形。\r\n这不是机器自己完成的。\r\n有人用尽全力，\r\n把锚链锁住了。\r\n",
            characterText = "它曾经承受过远超极限的拉力。\r\n自动刹车失效后，\r\n有人仍试图让锚链停住。\r\n, “所以你回到了这里。”"
        },
        new StoryData
        {
            storyIndex = 4,
            name = "烧毁的锚链绞盘零件",
            location = "沉船内部，靠近机舱",
            text = "锚链绞盘：\r\n用于收放和锁住船锚的机器。\r\n如果刹车失效，\r\n锚链会被海流拖着继续滑出，\r\n船也无法稳定。\r\n, 它曾经承受过远超极限的拉力。\r\n自动刹车失效后，\r\n有人仍试图让锚链停住。\r\n",
            characterText = "他不是不想走，他是走不了了。"
        },
    };
    private List<string> _endingScript = new List<string>()
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
        "我的锚，",
        "带我回家。"
    };
    #endregion

    /// <summary>
    /// 单例实例
    /// </summary>
    private static StoryManager _instance;

    /// <summary>
    /// 获取管理器
    /// </summary>
    /// <returns></returns>
    public static StoryManager GetStoryManager()
    {
        if (_instance == null) _instance = new StoryManager();
        return _instance;
    }

    public StoryData PushStory()
    {
        _storyIndex++;
        return _storyDatas[_storyIndex - 1];
    }
    public void ClearStory()
    {
        _storyIndex = 0;
    }
    public string CoreTip() => "船是家。锚链是回家的路。";
    public List<string> EndingScript => _endingScript;
    public List<string> OpeningScript => _openingScript;
}
