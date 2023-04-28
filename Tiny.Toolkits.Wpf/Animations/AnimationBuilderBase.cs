using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Windows;
using System.Windows.Media.Animation;

namespace Tiny.Toolkits
{
    /// <summary>
    ///  a class of <see cref="AnimationBuilderBase{T, TD}"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TD"></typeparam>
    public abstract class AnimationBuilderBase<T, TD> where T : AnimationBuilderBase<T, TD> where TD : DependencyObject
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private DependencyObject dependencyObject;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Expression<Func<TD, double>> propertySelector;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Action completeCallback;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private FillBehavior? fillBehavior;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private TimeSpan? timeSpanValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private bool? autoReverse;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private double? speedRatio;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private RepeatBehavior? repeatBehavior;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private string name;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private double? decelerationRatio;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private TimeSpan? beginTime;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private double? accelerationRatio;


        /// <summary>
        ///   the length of time for which this timeline plays, not counting repetitions.
        /// </summary>
        /// <param name="timeSpanValue"></param>
        /// <returns></returns>
        public T Duration(TimeSpan timeSpanValue)
        {
            this.timeSpanValue = timeSpanValue;
            return (T)this;
        }


        /// <summary>
        ///   the length of time for which this timeline plays, not counting repetitions.
        /// </summary>
        /// <param name="time_Ms"></param>
        /// <returns></returns>
        public T Duration(int time_Ms)
        {
            timeSpanValue = TimeSpan.FromMilliseconds(time_Ms);
            return (T)this;
        }

        /// <summary>
        ///   a value that specifies how the System.Windows.Media.Animation.Timeline behaves after it reaches the end of its active period.
        /// </summary>
        /// <param name="fillBehavior"></param>
        /// <returns></returns>
        public T FillBehavior(FillBehavior fillBehavior)
        {
            this.fillBehavior = fillBehavior;
            return (T)this;
        }

        /// <summary>
        /// Occurs when this timeline has completely finished playing: it will no longer enter its active period.
        /// </summary>
        /// <param name="completeCallback"></param>
        /// <returns></returns>
        public T Complete(Action completeCallback)
        {
            this.completeCallback = completeCallback;
            return (T)this;
        }

        /// <summary>
        /// Makes the specified System.Windows.Media.Animation.Timeline target the dependency object.
        /// </summary>
        /// <param name="dependencyObject"></param>
        /// <returns></returns>
        internal T Target(DependencyObject dependencyObject)
        {
            this.dependencyObject = dependencyObject;
            return (T)this;
        }


        /// <summary>
        /// Makes the specified System.Windows.Media.Animation.Timeline target the specified dependency property.
        /// </summary>
        /// <param name="propertySelector"></param>
        /// <returns></returns>
        public T Property(Expression<Func<TD, double>> propertySelector)
        {
            this.propertySelector = propertySelector;
            return (T)this;
        }

        /// <summary>
        ///   a value that indicates whether the timeline plays in reverse after it completes a forward iteration.
        /// </summary>
        /// <param name="autoReverse"></param>
        /// <returns></returns>
        public T AutoReverse(bool autoReverse)
        {
            this.autoReverse = autoReverse;
            return (T)this;
        }

        /// <summary>
        ///   the rate, relative to its parent, at which time progresses for this System.Windows.Media.Animation.Timeline.
        /// </summary>
        /// <param name="speedRatio"></param>
        /// <returns></returns>
        public T SpeedRatio(double speedRatio)
        {
            this.speedRatio = speedRatio;
            return (T)this;
        }

        /// <summary>
        ///    the repeating behavior of this timeline.
        /// </summary>
        /// <param name="repeatBehavior"></param>
        /// <returns></returns>
        public T RepeatBehavior(RepeatBehavior repeatBehavior)
        {
            this.repeatBehavior = repeatBehavior;
            return (T)this;
        }

        /// <summary>
        ///   the name of this System.Windows.Media.Animation.Timeline.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public T Name(string name)
        {
            this.name = name;
            return (T)this;
        }
        /// <summary>
        ///   a value specifying the percentage of the timeline's System.Windows.Media.Animation.Timeline.Duration  spent decelerating the passage of time from its maximum rate to zero.
        /// </summary>
        /// <param name="decelerationRatio"></param>
        /// <returns></returns>
        public T DecelerationRatio(double decelerationRatio)
        {
            this.decelerationRatio = decelerationRatio;
            return (T)this;
        }

        /// <summary>
        ///   the time at which this System.Windows.Media.Animation.Timeline should begin.
        /// </summary>
        /// <param name="beginTime"></param>
        /// <returns></returns>
        public T BeginTime(TimeSpan beginTime)
        {
            this.beginTime = beginTime;
            return (T)this;
        }

        /// <summary>
        ///   a value specifying the percentage of the timeline's System.Windows.Media.Animation.Timeline.Duration spent accelerating the passage of time from zero to its maximum rate.
        /// </summary>
        /// <param name="accelerationRatio"></param>
        /// <returns></returns>
        public T AccelerationRatio(double accelerationRatio)
        {
            this.accelerationRatio = accelerationRatio;
            return (T)this;
        }


        /// <summary>
        /// Build animation, set timeline attributes, and add animation effects
        /// </summary>
        /// <param name="timeline"></param>
        /// <exception cref="ArgumentNullException"></exception>
        protected void BuildAnimation(Timeline timeline)
        {
            if (dependencyObject is null)
            {
                throw new ArgumentNullException(nameof(dependencyObject));
            }
            if (propertySelector is null)
            {
                throw new ArgumentNullException(nameof(propertySelector));
            }

            Storyboard.SetTarget(timeline, dependencyObject);

            string propertyName = TinyTools.GetPropertyName(propertySelector);

            Storyboard.SetTargetProperty(timeline, new PropertyPath(propertyName));

            if (timeSpanValue.HasValue)
            {
                timeline.Duration = timeSpanValue.Value;
            }
            if (fillBehavior.HasValue)
            {
                timeline.FillBehavior = fillBehavior.Value;
            }
            if (completeCallback != null)
            {
                timeline.Completed += (s, e) => completeCallback();
            }
            if (autoReverse.HasValue)
            {
                timeline.AutoReverse = autoReverse.Value;
            }
            if (speedRatio.HasValue)
            {
                timeline.SpeedRatio = speedRatio.Value;
            }
            if (repeatBehavior.HasValue)
            {
                timeline.RepeatBehavior = repeatBehavior.Value;
            }
            if (string.IsNullOrEmpty(name) == false)
            {
                timeline.Name = name;
            }
            if (decelerationRatio.HasValue)
            {
                timeline.DecelerationRatio = decelerationRatio.Value;
            }
            if (beginTime.HasValue)
            {
                timeline.BeginTime = beginTime.Value;
            }
            if (accelerationRatio.HasValue)
            {
                timeline.AccelerationRatio = accelerationRatio.Value;
            }
        }
    }
}
