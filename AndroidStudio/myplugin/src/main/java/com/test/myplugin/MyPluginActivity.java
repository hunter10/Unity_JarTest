package com.test.myplugin;

/**
 * Created by hunte_epfwgye on 2018-01-02.
 */

import com.unity3d.player.UnityPlayerActivity;

public class MyPluginActivity extends UnityPlayerActivity
{
    public static int GetStaticInt(int a) {return a+a;}
    public static String GetStaticString(String str) {return "Static GetString() : " + str;}
    public int GetInt(int a){return a+a;}
    public String GetString(String str)
    {
        return "GetString() : " + str;
    }
}
