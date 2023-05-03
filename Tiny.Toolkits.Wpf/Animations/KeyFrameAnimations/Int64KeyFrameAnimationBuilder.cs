using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media.Animation;

namespace Tiny.Toolkits
{
    /// <summary>																											      
    /// a class of <see cref="Int64KeyFrameAnimationBuilder{T}"/>																		 
    /// </summary>																											      
    /// <typeparam name="T">dependencyObject type</typeparam>																			 
    public class Int64KeyFrameAnimationBuilder<T> : AnimationBuilderBase<Int64KeyFrameAnimationBuilder<T>, T> where T : DependencyObject
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private bool? boolValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private readonly List<Int64KeyFrame> frames = new();


        /// <summary>                                                                                                                                       
        /// add new frame                                                                                                                                   
        /// </summary>                                                                                                                                      
        /// <param name="value"></param>                                                                                                                
        /// <param name="beginTime"></param>                                                                                                                 
        /// <returns></returns>                                                                                                                             
        public Int64KeyFrameAnimationBuilder<T> Add(Int64 value, TimeSpan beginTime)
        {
            frames.Add(new LinearInt64KeyFrame(value, beginTime));

            return this;
        }


        /// <summary>                                                                                                                                       
        /// a value that specifies whether the animation's value accumulates when it repeats.                                                               
        /// </summary>                                                                                                                                      
        /// <param name="boolValue"></param>                                                                                                                
        /// <returns></returns>                                                                                                                             
        public Int64KeyFrameAnimationBuilder<T> IsCumulative(bool boolValue)
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
            Int64AnimationUsingKeyFrames animation = new();

            base.BuildAnimation(animation);

            foreach (Int64KeyFrame item in frames)
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
