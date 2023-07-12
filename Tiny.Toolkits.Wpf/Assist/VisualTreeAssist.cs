using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;

namespace Tiny.Toolkits
{
    /// <summary>
    /// visual tree assist
    /// </summary>
    public static partial class WpfAssist
    {
        /// <summary>
        /// Find child elements of an element
        /// </summary>
        /// <typeparam name="Target">Child element type</typeparam>
        /// <param name="dependencyObject"></param>
        /// <returns></returns>
        public static Target FindVisualChild<Target>(DependencyObject dependencyObject) where Target : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(dependencyObject); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(dependencyObject, i);
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
        /// find visual children from <paramref name="dependencyObject"/>
        /// </summary>
        /// <typeparam name="Target"></typeparam>
        /// <param name="dependencyObject"></param>
        /// <returns></returns>
        public static IEnumerable<Target> FindVisualChildren<Target>(this DependencyObject dependencyObject) where Target : DependencyObject
        {
            if (dependencyObject != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(dependencyObject); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(dependencyObject, i);
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
        /// find visual parent from <paramref name="dependencyObject"/>
        /// </summary>
        /// <typeparam name="Target"></typeparam>
        /// <param name="dependencyObject"></param>
        /// <returns></returns>
        public static Target FindParent<Target>(this DependencyObject dependencyObject) where Target : DependencyObject
        {
            while (true)
            {
                DependencyObject dobj = VisualTreeHelper.GetParent(dependencyObject);
                if (dobj is null)
                {
                    return default;
                }

                if (dobj is Target target)
                {
                    return target;
                }

                dependencyObject = dobj;
            }
        }

        /// <summary>
        /// find visual parent from <paramref name="dependencyObject"/>
        /// </summary>
        /// <typeparam name="Target"></typeparam>
        /// <param name="dependencyObject"></param>
        /// <returns></returns>
        public static DependencyObject FindParent(this DependencyObject dependencyObject, Type parentType)
        {
            while (true)
            {
                DependencyObject dobj = VisualTreeHelper.GetParent(dependencyObject);
                if (dobj is null)
                {
                    return default;
                }

                var currentType = dobj.GetType();

                if (currentType == parentType || currentType.BaseType == parentType)
                {
                    return dobj;
                }

                dependencyObject = dobj;
            }
        }


        /// <summary>
        /// find visual parent from <paramref name="dependencyObject"/>
        /// </summary>
        /// <typeparam name="Target"></typeparam>
        /// <param name="dependencyObject"></param>
        /// <param name="elementName"></param>
        /// <returns></returns>
        public static Target FindParent<Target>(this DependencyObject dependencyObject, string elementName) where Target : DependencyObject
        {
            DependencyObject dobj = VisualTreeHelper.GetParent(dependencyObject);
            return dobj != null
                ? dobj is Target && ((FrameworkElement)dobj).Name.Equals(elementName)
                    ? (Target)dobj
                    : FindParent<Target>(dobj, elementName)
                : null;
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
        /// Find an element with a specified name
        /// </summary>
        /// <typeparam name="Target">Element Type</typeparam>
        /// <param name="dependencyObject"></param>
        /// <param name="elementName">Element name in xaml</param>
        /// <returns></returns>
        public static Target FindVisualElement<Target>(DependencyObject dependencyObject, string elementName) where Target : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(dependencyObject); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(dependencyObject, i);
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
        /// Hit test. Find the parent and child nodes of the visual tree based on the currently selected element to see if there are elements of the specified type
        /// </summary>
        /// <typeparam name="Target">The type of element you want to hit</typeparam>
        /// <param name="dependencyObject">Currently selected element</param>
        /// <returns>true：Successfully hit</returns>
        public static bool HitTest<Target>(DependencyObject dependencyObject) where Target : DependencyObject
        {
            return FindParent<Target>(dependencyObject) != null || FindVisualChild<Target>(dependencyObject) != null;
        }

        /// <summary>
        /// find equal dependencyObjectRight
        /// </summary>
        /// <typeparam name="Target"></typeparam>
        /// <param name="dependencyObjectLeft"></param>
        /// <param name="dependencyObjectRight"></param>
        /// <returns></returns>
        public static Target FindEqualElement<Target>(DependencyObject dependencyObjectLeft, DependencyObject dependencyObjectRight) where Target : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(dependencyObjectLeft); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(dependencyObjectLeft, i);
                if (child != null && child is Target && child == dependencyObjectRight)
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
