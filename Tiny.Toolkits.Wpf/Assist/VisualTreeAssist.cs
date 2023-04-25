using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;

namespace Tiny.Toolkits.Wpf
{
    /// <summary>
    /// visual tree assist
    /// </summary>
    public static partial class AssistFactory
    {
        /// <summary>
        /// 查找元素的子元素
        /// </summary>
        /// <typeparam name="Target">子元素类型</typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Target FindVisualChild<Target>(DependencyObject obj) where Target : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child is not null and Target)
                {
                    return (Target)child;
                }
                else
                {
                    Target childOfChild = FindVisualChild<Target>(child);
                    if (childOfChild != null)
                    {
                        return childOfChild;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// find visual children from <paramref name="depObj"/>
        /// </summary>
        /// <typeparam name="Target"></typeparam>
        /// <param name="depObj"></param>
        /// <returns></returns>
        public static IEnumerable<Target> FindVisualChildren<Target>(DependencyObject depObj) where Target : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child is not null and Target)
                    {
                        yield return (Target)child;
                    }

                    foreach (Target childOfChild in FindVisualChildren<Target>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        /// <summary>
        /// find visual children from <paramref name="dependency"/>
        /// </summary>
        /// <typeparam name="Target"></typeparam>
        /// <param name="dependency"></param>
        /// <returns></returns>
        public static List<Target> FindVisualChildrenEx<Target>(DependencyObject dependency) where Target : DependencyObject
        {
            try
            {
                List<Target> TList = new() { };
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(dependency); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(dependency, i);
                    if (child is not null and Target)
                    {
                        TList.Add((Target)child);
                        List<Target> childOfChildren = FindVisualChildrenEx<Target>(child);
                        if (childOfChildren != null)
                        {
                            TList.AddRange(childOfChildren);
                        }
                    }
                    else
                    {
                        List<Target> childOfChildren = FindVisualChildrenEx<Target>(child);
                        if (childOfChildren != null)
                        {
                            TList.AddRange(childOfChildren);
                        }
                    }
                }
                return TList;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// find visual parent from <paramref name="dependency"/>
        /// </summary>
        /// <typeparam name="Target"></typeparam>
        /// <param name="dependency"></param>
        /// <returns></returns>
        public static Target FindParent<Target>(DependencyObject dependency) where Target : DependencyObject
        {
            while (true)
            {
                DependencyObject dobj = VisualTreeHelper.GetParent(dependency);
                if (dobj is null)
                {
                    return default;
                }

                if (dobj is Target target)
                {
                    return target;
                }

                dependency = dobj;
            }
        }

        /// <summary>
        /// find visual parent from <paramref name="dependency"/>
        /// </summary>
        /// <typeparam name="Target"></typeparam>
        /// <param name="dependency"></param>
        /// <param name="elementName"></param>
        /// <returns></returns>
        public static Target FindParent<Target>(DependencyObject dependency, string elementName) where Target : DependencyObject
        {
            DependencyObject dobj = VisualTreeHelper.GetParent(dependency);
            if (dobj != null)
            {
                if (dobj is Target && ((System.Windows.FrameworkElement)dobj).Name.Equals(elementName))
                {
                    return (Target)dobj;
                }

                return FindParent<Target>(dobj, elementName);
            }
            return null;
        }

        /// <summary>
        /// get visual handle
        /// </summary>
        /// <param name="visual"></param>
        /// <returns></returns>
        public static IntPtr GetHandle(this Visual visual)
        {
            return (PresentationSource.FromVisual(visual) as HwndSource)?.Handle ?? IntPtr.Zero;
        }

        /// <summary>
        /// 查找指定名称的元素
        /// </summary>
        /// <typeparam name="Target">元素类型</typeparam>
        /// <param name="obj"></param>
        /// <param name="elementName">元素名称，及xaml中的Name</param>
        /// <returns></returns>
        public static Target FindVisualElement<Target>(DependencyObject obj, string elementName) where Target : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is Target && ((System.Windows.FrameworkElement)child).Name.Equals(elementName))
                {
                    return (Target)child;
                }
                else
                {
                    IEnumerator j = FindVisualChildren<Target>(child).GetEnumerator();
                    while (j.MoveNext())
                    {
                        Target childOfChild = (Target)j.Current;

                        if (childOfChild != null && !(childOfChild as FrameworkElement).Name.Equals(elementName))
                        {
                            FindVisualElement<Target>(childOfChild, elementName);
                        }
                        else
                        {
                            return childOfChild;
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 命中测试。根据当前选中元素，查找视觉树父节点与子节点，看是否存在指定类型的元素
        /// </summary>
        /// <typeparam name="Target">想命中的元素类型</typeparam>
        /// <param name="dp">当前选中元素</param>
        /// <returns>true：命中成功</returns>
        public static bool HitTest<Target>(DependencyObject dp) where Target : DependencyObject
        {
            return FindParent<Target>(dp) != null || FindVisualChild<Target>(dp) != null;
        }

        /// <summary>
        /// find equal element
        /// </summary>
        /// <typeparam name="Target"></typeparam>
        /// <param name="source"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        public static Target FindEqualElement<Target>(DependencyObject source, DependencyObject element) where Target : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(source); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(source, i);
                if (child != null && child is Target && child == element)
                {
                    return (Target)child;
                }
                else
                {
                    Target childOfChild = FindVisualChild<Target>(child);
                    if (childOfChild != null)
                    {
                        return childOfChild;
                    }
                }
            }
            return null;
        }
    }
}
