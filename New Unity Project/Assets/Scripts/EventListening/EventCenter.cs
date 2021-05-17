using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCenter
{
    //声明了一个字典 键是枚举类型也就是一个名字  值是委托
    public static Dictionary<EventType, Delegate> m_EventTable = new Dictionary<EventType, Delegate>();
    //No parameters
    public static void AddListener(EventType eventType, CallBack callBack)
    {
        //判断字典里面是否存在这个枚举的值
        if (!m_EventTable.ContainsKey(eventType))
        {
            //如果不存在则添加这个空值进入，但是有名字
            m_EventTable.Add(eventType, null);
        }
        //如果存在这个值，将其赋值给委托
        Delegate d = m_EventTable[eventType];
        //如果委托不为空且值类型不相同，则报错
        if (d != null && d.GetType() != callBack.GetType())
        {
            throw new Exception(string.Format("尝试为事件{0}添加不同类型的委托，当前事件所对应的委托类型为{1},要添加的委托类型为{2}", eventType, d.GetType(), callBack.GetType()));
        }
        //反之将值存入
        m_EventTable[eventType] = (CallBack)m_EventTable[eventType] + callBack;
    }
    //Single parameters
    public static void AddListener<T>(EventType eventType, CallBack<T> callBack)
    {
        //判断字典里面是否存在这个枚举的值
        if (!m_EventTable.ContainsKey(eventType))
        {
            //如果不存在则添加这个空值进入，但是有名字
            m_EventTable.Add(eventType, null);
        }
        //如果存在这个值，将其赋值给委托
        Delegate d = m_EventTable[eventType];
        //如果委托不为空且值类型不相同，则报错
        if (d != null && d.GetType() != callBack.GetType())
        {
            throw new Exception(string.Format("尝试为事件{0}添加不同类型的委托，当前事件所对应的委托类型为{1},要添加的委托类型为{2}", eventType, d.GetType(), callBack.GetType()));
        }
        //反之将值存入
        m_EventTable[eventType] = (CallBack<T>)m_EventTable[eventType] + callBack;
    }

    public static void RemoveListener(EventType eventType, CallBack callBack)
    {
        //判断字典中有这个键没有
        if (m_EventTable.ContainsKey(eventType))
        {
            //若有则获得这个键的委托
            Delegate d = m_EventTable[eventType];
            //如果委托是空，则报错没有存入委托值
            if (d == null)
            {
                throw new Exception(string.Format("移除监听错误:事件{0}没有对应的委托", eventType));
            }
            //继续判断委托类型是否与声明的相同，否则报错
            else if (d.GetType() != callBack.GetType())
            {
                throw new Exception(string.Format("移除监听错误：尝试为事件{0}移除不同类型的委托，当前委托类型为{1},要移除的委托类型为{2}", eventType, d.GetType(), callBack.GetType()));

            }
        }
        else
        {
            //字典中没有这个键，报错
            throw new Exception(string.Format("移除监听错误，没有时间码{0}", eventType));
        }
        //若都没有错，则移除这个类型
        m_EventTable[eventType] = (CallBack)m_EventTable[eventType] - callBack;
        if (m_EventTable[eventType] == null)
        {
            m_EventTable.Remove(eventType);
        }
    }


    public static void RemoveListener<T>(EventType eventType, CallBack<T> callBack)
    {
        //判断字典中有这个键没有
        if (m_EventTable.ContainsKey(eventType))
        {
            //若有则获得这个键的委托
            Delegate d = m_EventTable[eventType];
            //如果委托是空，则报错没有存入委托值
            if (d == null)
            {
                throw new Exception(string.Format("移除监听错误:事件{0}没有对应的委托", eventType));
            }
            //继续判断委托类型是否与声明的相同，否则报错
            else if (d.GetType() != callBack.GetType())
            {
                throw new Exception(string.Format("移除监听错误：尝试为事件{0}移除不同类型的委托，当前委托类型为{1},要移除的委托类型为{2}", eventType, d.GetType(), callBack.GetType()));

            }
        }
        else
        {
            //字典中没有这个键，报错
            throw new Exception(string.Format("移除监听错误，没有时间码{0}", eventType));
        }
        //若都没有错，则移除这个类型
        m_EventTable[eventType] = (CallBack<T>)m_EventTable[eventType] - callBack;
        if (m_EventTable[eventType] == null)
        {
            m_EventTable.Remove(eventType);
        }
    }
    //no parameters
    public static void Broadcast(EventType eventType)
    {
        Delegate d;
        //获得这个类型的值 传给d
        if (m_EventTable.TryGetValue(eventType, out d))
        {
            //将d类型转换
            CallBack callBack = d as CallBack;
            if (callBack != null)
            {
                //若委托不为空，则执行委托
                callBack();
            }
            else
            {
                //反之报错
                throw new Exception(string.Format("广播事件错误: 时间{0}对应委托具有不同的类型", eventType));
            }
        }
    }


    public static void Broadcast<T>(EventType eventType, T arg)
    {
        Delegate d;
        //获得这个类型的值 传给d
        if (m_EventTable.TryGetValue(eventType, out d))
        {
            //将d类型转换
            CallBack<T> callBack = d as CallBack<T>;
            if (callBack != null)
            {
                //若委托不为空，则执行委托
                callBack(arg);
            }
            else
            {
                //反之报错
                throw new Exception(string.Format("广播事件错误: 时间{0}对应委托具有不同的类型", eventType));
            }
        }
    }
}
