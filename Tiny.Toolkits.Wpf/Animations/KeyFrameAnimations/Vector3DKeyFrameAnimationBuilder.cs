using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;

namespace Tiny.Toolkits
{
    /// <summary>																											      
    /// a class of <see cref="Vector3DKeyFrameAnimationBuilder{T}"/>																		 
    /// </summary>																											      
    /// <typeparam name="T">dependencyObject type</typeparam>																			 
    public class Vector3DKeyFrameAnimationBuilder<T> : AnimationBuilderBase<Vector3DKeyFrameAnimationBuilder<T>, T> where T : DependencyObject
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private bool? boolValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private readonly List<Vector3DKeyFrame> frames = new();


        /// <summary>                                                                                                                                       
        /// add new frame                                                                                                                                   
        /// </summary>                                                                                                                                      
        /// <param name="value"></param>                                                                                                                
        /// <param name="beginTime"></param>                                                                                                                 
        /// <returns></returns>                                                                                                                             
        public Vector3DKeyFrameAnimationBuilder<T> Add(Vector3D value, TimeSpan beginTime )
        {
            frames.Add(new LinearVector3DKeyFrame(value, beginTime));

            return this;
        }


        /// <summary>                                                                                                                                       
        /// a value that specifies whether the animation's value accumulates when it repeats.                                                               
        /// </summary>                                                                                                                                      
        /// <param name="boolValue"></param>                                                                                                                
        /// <returns></returns>                                                                                                                             
        public Vector3DKeyFrameAnimationBuilder<T> IsCumulative(bool boolValue)
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
            Vector3DAnimationUsingKeyFrames animation = new();

            base.BuildAnimation(animation);

            foreach (Vector3DKeyFrame item in frames)
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
