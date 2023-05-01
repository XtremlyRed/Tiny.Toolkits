using System.Diagnostics;
using System.Windows;
using System.Windows.Media.Animation;

namespace Tiny.Toolkits
{
    /// <summary>																											
    /// a class of <see cref="PointAnimationBuilder{T}"/>																											
    /// </summary>																											
    /// <typeparam name="T">dependencyObject type</typeparam>																											
    public class PointAnimationBuilder<T> : AnimationBuilderBase<PointAnimationBuilder<T>, T> where T : DependencyObject
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Point? fromValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Point? byValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Point? toValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private bool? boolValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private IEasingFunction easingFunction;

        /// <summary>                                                                                                                            
        /// animation's starting value.                                                                                                          
        /// </summary>                                                                                                                           
        /// <param name="fromValue"></param>                                                                                                     
        /// <returns></returns>                                                                                                                  
        public PointAnimationBuilder<T> From(Point? fromValue)
        {
            this.fromValue = fromValue;
            return this;
        }
        /// <summary>                                                                                                                            
        /// the total amount by which the animation changes its starting value.                                                                  
        /// </summary>                                                                                                                           
        /// <param name="byValue"></param>                                                                                                       
        /// <returns></returns>                                                                                                                  
        public PointAnimationBuilder<T> By(Point? byValue)
        {
            this.byValue = byValue;
            return this;
        }

        /// <summary>                                                                                                                            
        /// the animation's ending value.                                                                                                        
        /// </summary>                                                                                                                           
        /// <param name="toValue"></param>                                                                                                       
        /// <returns></returns>                                                                                                                  
        public PointAnimationBuilder<T> To(Point? toValue)
        {
            this.toValue = toValue;
            return this;
        }


        /// <summary>                                                                                                                            
        /// a value that specifies whether the animation's value accumulates when it repeats.                                                    
        /// </summary>                                                                                                                           
        /// <param name="boolValue"></param>                                                                                                     
        /// <returns></returns>                                                                                                                  
        public PointAnimationBuilder<T> IsCumulative(bool boolValue)
        {
            this.boolValue = boolValue;
            return this;
        }


        /// <summary>                                                                                                                            
        /// the easing function applied to this animation.                                                                                       
        /// </summary>                                                                                                                           
        /// <param name="easingFunction"></param>                                                                                                
        /// <returns></returns>                                                                                                                  
        public PointAnimationBuilder<T> EasingFunction(IEasingFunction easingFunction)
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
            PointAnimation animation = new();
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
