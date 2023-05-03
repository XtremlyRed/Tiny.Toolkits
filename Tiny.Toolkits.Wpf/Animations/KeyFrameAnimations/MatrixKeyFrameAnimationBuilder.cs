using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Tiny.Toolkits
{
    /// <summary>																											      
    /// a class of <see cref="MatrixKeyFrameAnimationBuilder{T}"/>																		 
    /// </summary>																											      
    /// <typeparam name="T">dependencyObject type</typeparam>																			 
    public class MatrixKeyFrameAnimationBuilder<T> : AnimationBuilderBase<MatrixKeyFrameAnimationBuilder<T>, T> where T : DependencyObject
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private readonly List<MatrixKeyFrame> frames = new();


        /// <summary>                                                                                                                                       
        /// add new frame                                                                                                                                   
        /// </summary>                                                                                                                                      
        /// <param name="value"></param>                                                                                                                
        /// <param name="beginTime"></param>                                                                                                                 
        /// <returns></returns>                                                                                                                             
        public MatrixKeyFrameAnimationBuilder<T> Add(Matrix value, TimeSpan beginTime)
        {
            frames.Add(new DiscreteMatrixKeyFrame(value, beginTime));

            return this;
        }




        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private AnimationPlayer player;

        /// <summary> 																										      
        /// build animation player.  																								 
        /// </summary>       																										 
        public IAnimationPlayer BuildAnimation()
        {
            MatrixAnimationUsingKeyFrames animation = new();

            base.BuildAnimation(animation);

            foreach (MatrixKeyFrame item in frames)
            {
                animation.KeyFrames.Add(item);
            }

            return player = new AnimationPlayer(animation);
        }
    }
}
