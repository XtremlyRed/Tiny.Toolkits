using System.Diagnostics;
using System.Windows;
using System.Windows.Media.Animation;

namespace Tiny.Toolkits
{
    /// <summary>																											
    /// a class of <see cref="SizeAnimationBuilder{T}"/>																											
    /// </summary>																											
    /// <typeparam name="T">dependencyObject type</typeparam>																											
    public class SizeAnimationBuilder<T> : AnimationBuilderBase<SizeAnimationBuilder<T>, T> where T : DependencyObject
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Size? fromValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Size? byValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Size? toValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private bool? boolValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private IEasingFunction easingFunction;

        /// <summary>                                                                                                                            
        /// animation's starting value.                                                                                                          
        /// </summary>                                                                                                                           
        /// <param name="fromValue"></param>                                                                                                     
        /// <returns></returns>                                                                                                                  
        public SizeAnimationBuilder<T> From(Size? fromValue)
        {
            this.fromValue = fromValue;
            return this;
        }
        /// <summary>                                                                                                                            
        /// the total amount by which the animation changes its starting value.                                                                  
        /// </summary>                                                                                                                           
        /// <param name="byValue"></param>                                                                                                       
        /// <returns></returns>                                                                                                                  
        public SizeAnimationBuilder<T> By(Size? byValue)
        {
            this.byValue = byValue;
            return this;
        }

        /// <summary>                                                                                                                            
        /// the animation's ending value.                                                                                                        
        /// </summary>                                                                                                                           
        /// <param name="toValue"></param>                                                                                                       
        /// <returns></returns>                                                                                                                  
        public SizeAnimationBuilder<T> To(Size? toValue)
        {
            this.toValue = toValue;
            return this;
        }


        /// <summary>                                                                                                                            
        /// a value that specifies whether the animation's value accumulates when it repeats.                                                    
        /// </summary>                                                                                                                           
        /// <param name="boolValue"></param>                                                                                                     
        /// <returns></returns>                                                                                                                  
        public SizeAnimationBuilder<T> IsCumulative(bool boolValue)
        {
            this.boolValue = boolValue;
            return this;
        }


        /// <summary>                                                                                                                            
        /// the easing function applied to this animation.                                                                                       
        /// </summary>                                                                                                                           
        /// <param name="easingFunction"></param>                                                                                                
        /// <returns></returns>                                                                                                                  
        public SizeAnimationBuilder<T> EasingFunction(IEasingFunction easingFunction)
        {
            this.easingFunction = easingFunction;
            return this;
        }
        /// <summary> 																										
        /// begin animation.  																										
        /// </summary>       																										
        public void Begin()
        {
            SizeAnimation animation = new();
            base.BuildAnimation(animation);
            if (fromValue.HasValue) { animation.From = fromValue; }
            if (byValue.HasValue) { animation.By = byValue; }
            if (toValue.HasValue) { animation.To = toValue; }
            if (boolValue.HasValue) { animation.IsCumulative = boolValue.Value; }
            if (easingFunction != null) { animation.EasingFunction = easingFunction; }
            Storyboard storyboard = new();
            storyboard.Children.Add(animation);
            storyboard.Begin();
        }
    }
}
