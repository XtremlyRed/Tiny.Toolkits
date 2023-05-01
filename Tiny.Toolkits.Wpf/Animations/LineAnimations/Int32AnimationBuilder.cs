using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media.Animation;

namespace Tiny.Toolkits
{
    /// <summary>																											
    /// a class of <see cref="Int32AnimationBuilder{T}"/>																											
    /// </summary>																											
    /// <typeparam name="T">dependencyObject type</typeparam>																											
    public class Int32AnimationBuilder<T> : AnimationBuilderBase<Int32AnimationBuilder<T>, T> where T : DependencyObject
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Int32? fromValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Int32? byValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Int32? toValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private bool? boolValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private IEasingFunction easingFunction;

        /// <summary>                                                                                                                            
        /// animation's starting value.                                                                                                          
        /// </summary>                                                                                                                           
        /// <param name="fromValue"></param>                                                                                                     
        /// <returns></returns>                                                                                                                  
        public Int32AnimationBuilder<T> From(Int32? fromValue)
        {
            this.fromValue = fromValue;
            return this;
        }
        /// <summary>                                                                                                                            
        /// the total amount by which the animation changes its starting value.                                                                  
        /// </summary>                                                                                                                           
        /// <param name="byValue"></param>                                                                                                       
        /// <returns></returns>                                                                                                                  
        public Int32AnimationBuilder<T> By(Int32? byValue)
        {
            this.byValue = byValue;
            return this;
        }

        /// <summary>                                                                                                                            
        /// the animation's ending value.                                                                                                        
        /// </summary>                                                                                                                           
        /// <param name="toValue"></param>                                                                                                       
        /// <returns></returns>                                                                                                                  
        public Int32AnimationBuilder<T> To(Int32? toValue)
        {
            this.toValue = toValue;
            return this;
        }


        /// <summary>                                                                                                                            
        /// a value that specifies whether the animation's value accumulates when it repeats.                                                    
        /// </summary>                                                                                                                           
        /// <param name="boolValue"></param>                                                                                                     
        /// <returns></returns>                                                                                                                  
        public Int32AnimationBuilder<T> IsCumulative(bool boolValue)
        {
            this.boolValue = boolValue;
            return this;
        }


        /// <summary>                                                                                                                            
        /// the easing function applied to this animation.                                                                                       
        /// </summary>                                                                                                                           
        /// <param name="easingFunction"></param>                                                                                                
        /// <returns></returns>                                                                                                                  
        public Int32AnimationBuilder<T> EasingFunction(IEasingFunction easingFunction)
        {
            this.easingFunction = easingFunction;
            return this;
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private AnimationPlayer player;
        /// <summary> 																										
        /// build animation player.  																										
        /// </summary>       																										
        public IAnimationPlayer BuildAnimation()
        {
            Int32Animation animation = new();
            base.BuildAnimation(animation);
            if (fromValue.HasValue)
            {
                animation.From = fromValue;
            }

            if (byValue.HasValue)
            {
                animation.By = byValue;
            }

            if (toValue.HasValue)
            {
                animation.To = toValue;
            }

            if (boolValue.HasValue)
            {
                animation.IsCumulative = boolValue.Value;
            }

            if (easingFunction != null)
            {
                animation.EasingFunction = easingFunction;
            }

            return player = new AnimationPlayer(animation);
        }
    }
}
