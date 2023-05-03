using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media.Animation;

namespace Tiny.Toolkits
{
    /// <summary>																											      
    /// a class of <see cref="PointKeyFrameAnimationBuilder{T}"/>																		 
    /// </summary>																											      
    /// <typeparam name="T">dependencyObject type</typeparam>																			 
    public class PointKeyFrameAnimationBuilder<T> : AnimationBuilderBase<PointKeyFrameAnimationBuilder<T>, T> where T : DependencyObject
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private bool? boolValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private readonly List<PointKeyFrame> frames = new();


        /// <summary>                                                                                                                                       
        /// add new frame                                                                                                                                   
        /// </summary>                                                                                                                                      
        /// <param name="value"></param>                                                                                                                
        /// <param name="beginTime"></param>                                                                                                                 
        /// <returns></returns>                                                                                                                             
        public PointKeyFrameAnimationBuilder<T> Add(Point value, TimeSpan beginTime)
        {
            frames.Add(new LinearPointKeyFrame(value, beginTime));

            return this;
        }


        /// <summary>                                                                                                                                       
        /// a value that specifies whether the animation's value accumulates when it repeats.                                                               
        /// </summary>                                                                                                                                      
        /// <param name="boolValue"></param>                                                                                                                
        /// <returns></returns>                                                                                                                             
        public PointKeyFrameAnimationBuilder<T> IsCumulative(bool boolValue)
        {
            this.boolValue = boolValue;
            return this;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private AnimationPlayer player;

        /// <summary> 																										      
        /// build animation player.  																								 
        /// </summary>       																										 
        public IAnimationPlayer BuildAnimation()
        {
            PointAnimationUsingKeyFrames animation = new();

            base.BuildAnimation(animation);

            foreach (PointKeyFrame item in frames)
            {
                animation.KeyFrames.Add(item);
            }

            if (boolValue.HasValue)
            {
                animation.IsCumulative = boolValue.Value;
            }

            return player = new AnimationPlayer(animation);
        }
    }
}
