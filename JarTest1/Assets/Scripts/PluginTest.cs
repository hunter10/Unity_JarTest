using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PluginTest : MonoBehaviour {

    string messge = "init";
    AndroidJavaClass myCls;
    AndroidJavaObject myObj;

    //// Use this for initialization
    void Start()
    {
        // 새로룬 오브젝트를 만들지 않고, com.unity3d.player.UnityPlayer의
        // static 멤버에 접근하기 위해 AndroidJavaClass를 사용한다.
        // (사실 Android UnityPlayer가 자동으로 인스턴스를 생성해준다)
        myCls = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        // 그리고 static 필드인 currentActivity를 접근한다.
        // 그리고 이경우 AndroidJavaObject를 사용한다.
        // 이유는 실제 필드 타입이 android.app.Activity이고
        // 이건 java.lang.Object를 상속받는다.
        // 그리고, non-primitive 타입은 무조껀 AndroidJavaObject로 접근해야한다.
        // 예외 : strings.
        myObj = myCls.GetStatic<AndroidJavaObject>("currentActivity");
    }
    void OnGUI()
    {
        // 이렇게 접근하는 방법은, static이나 non-static 모두
        // 동일한 방법으로 접근 가능하다
        if (GUI.Button(new Rect(100, 100, 100, 50), "StaticInt"))
        {
            messge += ("\n" + myObj.CallStatic<int>("GetStaticInt", 123).ToString());
        }

        if (GUI.Button(new Rect(100, 200, 100, 50), "StaticString"))
        {
            messge += ("\n" + myObj.CallStatic<string>("GetStaticString", "StaticString"));
        }

        if (GUI.Button(new Rect(100, 300, 100, 50), "Int"))
        {
            messge += ("\n" + myObj.Call<int>("GetInt", 456).ToString());
        }

        if (GUI.Button(new Rect(100, 400, 100, 50), "String"))
        {
            messge += ("\n" + myObj.Call<string>("GetString", "String"));
        }

        GUI.Label(new Rect(Screen.width / 2 - 350, Screen.height / 2 - 150, 700, 300), messge);
    }
}
