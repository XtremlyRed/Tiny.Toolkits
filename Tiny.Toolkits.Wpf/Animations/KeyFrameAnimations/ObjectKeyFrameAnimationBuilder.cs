using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media.Animation;

namespace Tiny.Toolkits
{
    /// <summary>																											      
    /// a class of <see cref="ObjectKeyFrameAnimationBuilder{T}"/>																		 
    /// </summary>																											      
    /// <typeparam name="T">dependencyObject type</typeparam>																			 
    public class ObjectKeyFrameAnimationBuilder<T> : AnimationBuilderBase<ObjectKeyFrameAnimationBuilder<T>, T> where T : DependencyObject
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private readonly List<ObjectKeyFrame> frames = new();


        /// <summary>                                                                                                                                       
        /// add new frame                                                                                                                                   
        /// </summary>                                                                                                                                      
        /// <param name="value"></param>                                                                                                                
        /// <param name="beginTime"></param>                                                                                                                 
        /// <returns></returns>                                                                                                                             
        public ObjectKeyFrameAnimationBuilder<T> Add(Object value, TimeSpan beginTime)
        {
            frames.Add(new DiscreteObjectKeyFrame(value, beginTime));

            return this;
        }




        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private AnimationPlayer player;

        /// <summary> 																										      
        /// build animation player.  																								 
        /// </summary>       																										 
        public IAnimationPlayer BuildAnimation()
        {
            ObjectAnimationUsingKeyFrames animation = new();

            base.BuildAnimation(animation);

            foreach (ObjectKeyFrame item in frames)
            {
                animation.KeyFrames.Add(item);
            }


            return player = new AnimationPlayer(animation);
        }
    }
}
