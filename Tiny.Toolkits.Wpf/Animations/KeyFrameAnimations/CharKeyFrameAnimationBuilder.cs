using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media.Animation;

namespace Tiny.Toolkits
{
    /// <summary>																											      
    /// a class of <see cref="CharKeyFrameAnimationBuilder{T}"/>																		 
    /// </summary>																											      
    /// <typeparam name="T">dependencyObject type</typeparam>																			 
    public class CharKeyFrameAnimationBuilder<T> : AnimationBuilderBase<CharKeyFrameAnimationBuilder<T>, T> where T : DependencyObject
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private readonly List<CharKeyFrame> frames = new();


        /// <summary>                                                                                                                                       
        /// add new frame                                                                                                                                   
        /// </summary>                                                                                                                                      
        /// <param name="value"></param>                                                                                                                
        /// <param name="beginTime"></param>                                                                                                                 
        /// <returns></returns>                                                                                                                             
        public CharKeyFrameAnimationBuilder<T> Add(Char value, TimeSpan beginTime)
        {
            frames.Add(new DiscreteCharKeyFrame(value, beginTime));

            return this;
        }



        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private AnimationPlayer player;

        /// <summary> 																										      
        /// build animation player.  																								 
        /// </summary>       																										 
        public IAnimationPlayer BuildAnimation()
        {
            CharAnimationUsingKeyFrames animation = new();

            base.BuildAnimation(animation);

            foreach (CharKeyFrame item in frames)
            {
                animation.KeyFrames.Add(item);
            }



            return player = new AnimationPlayer(animation);
        }
    }
}
