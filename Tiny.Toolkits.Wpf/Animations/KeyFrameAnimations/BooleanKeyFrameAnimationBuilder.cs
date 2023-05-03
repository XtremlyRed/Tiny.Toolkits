using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media.Animation;

namespace Tiny.Toolkits
{
    /// <summary>																											      
    /// a class of <see cref="BooleanKeyFrameAnimationBuilder{T}"/>																		 
    /// </summary>																											      
    /// <typeparam name="T">dependencyObject type</typeparam>																			 
    public class BooleanKeyFrameAnimationBuilder<T> : AnimationBuilderBase<BooleanKeyFrameAnimationBuilder<T>, T> where T : DependencyObject
    { 
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private readonly List<BooleanKeyFrame> frames = new();


        /// <summary>                                                                                                                                       
        /// add new frame                                                                                                                                   
        /// </summary>                                                                                                                                      
        /// <param name="value"></param>                                                                                                                
        /// <param name="beginTime"></param>                                                                                                                 
        /// <returns></returns>                                                                                                                             
        public BooleanKeyFrameAnimationBuilder<T> Add(Boolean value, TimeSpan beginTime )
        {
            frames.Add(new DiscreteBooleanKeyFrame(value, beginTime));
            return this;
        }




        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private AnimationPlayer player;

        /// <summary> 																										      
        /// build animation player.  																								 
        /// </summary>       																										 
        public IAnimationPlayer BuildAnimation()
        {
            BooleanAnimationUsingKeyFrames animation = new();

            base.BuildAnimation(animation);

            foreach (BooleanKeyFrame item in frames)
            {
                animation.KeyFrames.Add(item);
            }


            return player = new AnimationPlayer(animation);
        }
    }
}
