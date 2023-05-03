using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;

namespace Tiny.Toolkits
{
    /// <summary>																											      
    /// a class of <see cref="ThicknessKeyFrameAnimationBuilder{T}"/>																		 
    /// </summary>																											      
    /// <typeparam name="T">dependencyObject type</typeparam>																			 
    public class ThicknessKeyFrameAnimationBuilder<T> : AnimationBuilderBase<ThicknessKeyFrameAnimationBuilder<T>, T> where T : DependencyObject
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private bool? boolValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private readonly List<ThicknessKeyFrame> frames = new();


        /// <summary>                                                                                                                                       
        /// add new frame                                                                                                                                   
        /// </summary>                                                                                                                                      
        /// <param name="value"></param>                                                                                                                
        /// <param name="beginTime"></param>                                                                                                                  
        /// <returns></returns>                                                                                                                             
        public ThicknessKeyFrameAnimationBuilder<T> Add(Thickness value, TimeSpan beginTime)
        {
            frames.Add(new LinearThicknessKeyFrame(value, beginTime));

            return this;
        }


        /// <summary>                                                                                                                                       
        /// a value that specifies whether the animation's value accumulates when it repeats.                                                               
        /// </summary>                                                                                                                                      
        /// <param name="boolValue"></param>                                                                                                                
        /// <returns></returns>                                                                                                                             
        public ThicknessKeyFrameAnimationBuilder<T> IsCumulative(bool boolValue)
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
            ThicknessAnimationUsingKeyFrames animation = new();

            base.BuildAnimation(animation);

            foreach (ThicknessKeyFrame item in frames)
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
