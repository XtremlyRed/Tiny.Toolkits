using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media.Animation;

namespace Tiny.Toolkits
{
    /// <summary>																											      
    /// a class of <see cref="StringKeyFrameAnimationBuilder{T}"/>																		 
    /// </summary>																											      
    /// <typeparam name="T">dependencyObject type</typeparam>																			 
    public class StringKeyFrameAnimationBuilder<T> : AnimationBuilderBase<StringKeyFrameAnimationBuilder<T>, T> where T : DependencyObject
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private readonly List<StringKeyFrame> frames = new();


        /// <summary>                                                                                                                                       
        /// add new frame                                                                                                                                   
        /// </summary>                                                                                                                                      
        /// <param name="value"></param>                                                                                                                
        /// <param name="beginTime"></param>                                                                                                                  
        /// <returns></returns>                                                                                                                             
        public StringKeyFrameAnimationBuilder<T> Add(String value, TimeSpan beginTime)
        {
            frames.Add(new DiscreteStringKeyFrame(value, beginTime));

            return this;
        }




        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private AnimationPlayer player;

        /// <summary> 																										      
        /// build animation player.  																								 
        /// </summary>       																										 
        public IAnimationPlayer BuildAnimation()
        {
            StringAnimationUsingKeyFrames animation = new();

            base.BuildAnimation(animation);

            foreach (StringKeyFrame item in frames)
            {
                animation.KeyFrames.Add(item);
            }

            return player = new AnimationPlayer(animation);
        }
    }
}
