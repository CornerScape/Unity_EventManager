#if UNIT_TEST
using System;
using Szn.Framework.UtilPackage.EventUtil;
using UnityEngine;

public class EventTest : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        Action none = () => Debug.LogError("None");
        Action<string> one = InS =>
        {
            Debug.LogError(InS + "-0");
        };
        Action<string> one1  = InS =>
        {
            Debug.LogError(InS + "-1");
        };
        Action<string> one2  = InS =>
        {
            Debug.LogError(InS + "-2");
        };
        Action<string> one3  = InS =>
        {
            Debug.LogError(InS + "-3");
        };
        Action<string> one4  = InS =>
        {
            Debug.LogError(InS + "-4");
        };
        
        Action<string, string> two = (InS, InS1) => Debug.LogError(InS + "+" + InS1);
        Action<string, string, string> three = (InS, InS1, InS2) => Debug.LogError(InS + "+" + InS1 + "+" + InS2);
        Action<string, string, string, string> four = (InS, InS1, InS2, InS3) =>
            Debug.LogError(InS + "+" + InS1 + "+" + InS2 + "+" + InS3);

        EventManager.Instance.Register(EventKey.None, none, true);
        EventManager.Instance.Trigger(EventKey.None);
        
        EventManager.Instance.Register(EventKey.One, one, true);
        EventManager.Instance.Trigger(EventKey.One, "0");
        
        EventManager.Instance.Register(EventKey.One, one1, true);
        EventManager.Instance.Trigger(EventKey.One, "1");
        
        EventManager.Instance.Register(EventKey.One, one2);
        EventManager.Instance.Trigger(EventKey.One, "2");
        
        EventManager.Instance.Register(EventKey.One, one3);
        EventManager.Instance.Trigger(EventKey.One, "3");
        
        EventManager.Instance.Register(EventKey.One, one4);
        EventManager.Instance.Trigger(EventKey.One, "4");
        
        EventManager.Instance.Unregister(EventKey.One, one2);
        EventManager.Instance.Unregister(EventKey.One, one3);
        
        EventManager.Instance.Trigger(EventKey.One, "5");
        

        EventManager.Instance.Register(EventKey.Two, two, true);
        EventManager.Instance.Trigger(EventKey.Two, "one", "two");

        EventManager.Instance.Register(EventKey.Three, three, true);
        EventManager.Instance.Trigger(EventKey.Three, "one", "two", "three");

        EventManager.Instance.Register(EventKey.Four, four, true);
        EventManager.Instance.Trigger(EventKey.Four, "one", "two", "three", "Four");
    }
}
#endif