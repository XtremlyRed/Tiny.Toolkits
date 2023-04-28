using System.Windows;
using System.Windows.Media.Animation;
namespace Tiny.Toolkits
{

    /// <summary>
    ///  a class of <see cref="AnimationAssist"/>
    /// </summary>
    public static class AnimationAssist
    {
        /// <summary>																											
        /// Attach <see cref="ThicknessAnimation"/> to dependencyObject object																											
        /// </summary>																											
        /// <typeparam name="T">dependencyObject type</typeparam>																											
        public static ThicknessAnimationBuilder<T> WithThicknessAnimation<T>(this T target) where T : DependencyObject
        {
            ThicknessAnimationBuilder<T> builder = new();
            return builder.Target(target);
        }
        /// <summary>																											
        /// Attach <see cref="QuaternionAnimation"/> to dependencyObject object																											
        /// </summary>																											
        /// <typeparam name="T">dependencyObject type</typeparam>																											
        public static QuaternionAnimationBuilder<T> WithQuaternionAnimation<T>(this T target) where T : DependencyObject
        {
            QuaternionAnimationBuilder<T> builder = new();
            return builder.Target(target);
        }
        /// <summary>																											
        /// Attach <see cref="ByteAnimation"/> to dependencyObject object																											
        /// </summary>																											
        /// <typeparam name="T">dependencyObject type</typeparam>																											
        public static ByteAnimationBuilder<T> WithByteAnimation<T>(this T target) where T : DependencyObject
        {
            ByteAnimationBuilder<T> builder = new();
            return builder.Target(target);
        }
        /// <summary>																											
        /// Attach <see cref="ColorAnimation"/> to dependencyObject object																											
        /// </summary>																											
        /// <typeparam name="T">dependencyObject type</typeparam>																											
        public static ColorAnimationBuilder<T> WithColorAnimation<T>(this T target) where T : DependencyObject
        {
            ColorAnimationBuilder<T> builder = new();
            return builder.Target(target);
        }
        /// <summary>																											
        /// Attach <see cref="DecimalAnimation"/> to dependencyObject object																											
        /// </summary>																											
        /// <typeparam name="T">dependencyObject type</typeparam>																											
        public static DecimalAnimationBuilder<T> WithDecimalAnimation<T>(this T target) where T : DependencyObject
        {
            DecimalAnimationBuilder<T> builder = new();
            return builder.Target(target);
        }
        /// <summary>																											
        /// Attach <see cref="DoubleAnimation"/> to dependencyObject object																											
        /// </summary>																											
        /// <typeparam name="T">dependencyObject type</typeparam>																											
        public static DoubleAnimationBuilder<T> WithDoubleAnimation<T>(this T target) where T : DependencyObject
        {
            DoubleAnimationBuilder<T> builder = new();
            return builder.Target(target);
        }
        /// <summary>																											
        /// Attach <see cref="Int16Animation"/> to dependencyObject object																											
        /// </summary>																											
        /// <typeparam name="T">dependencyObject type</typeparam>																											
        public static Int16AnimationBuilder<T> WithInt16Animation<T>(this T target) where T : DependencyObject
        {
            Int16AnimationBuilder<T> builder = new();
            return builder.Target(target);
        }
        /// <summary>																											
        /// Attach <see cref="Int32Animation"/> to dependencyObject object																											
        /// </summary>																											
        /// <typeparam name="T">dependencyObject type</typeparam>																											
        public static Int32AnimationBuilder<T> WithInt32Animation<T>(this T target) where T : DependencyObject
        {
            Int32AnimationBuilder<T> builder = new();
            return builder.Target(target);
        }
        /// <summary>																											
        /// Attach <see cref="Int64Animation"/> to dependencyObject object																											
        /// </summary>																											
        /// <typeparam name="T">dependencyObject type</typeparam>																											
        public static Int64AnimationBuilder<T> WithInt64Animation<T>(this T target) where T : DependencyObject
        {
            Int64AnimationBuilder<T> builder = new();
            return builder.Target(target);
        }
        /// <summary>																											
        /// Attach <see cref="Point3DAnimation"/> to dependencyObject object																											
        /// </summary>																											
        /// <typeparam name="T">dependencyObject type</typeparam>																											
        public static Point3DAnimationBuilder<T> WithPoint3DAnimation<T>(this T target) where T : DependencyObject
        {
            Point3DAnimationBuilder<T> builder = new();
            return builder.Target(target);
        }
        /// <summary>																											
        /// Attach <see cref="PointAnimation"/> to dependencyObject object																											
        /// </summary>																											
        /// <typeparam name="T">dependencyObject type</typeparam>																											
        public static PointAnimationBuilder<T> WithPointAnimation<T>(this T target) where T : DependencyObject
        {
            PointAnimationBuilder<T> builder = new();
            return builder.Target(target);
        }
        /// <summary>																											
        /// Attach <see cref="RectAnimation"/> to dependencyObject object																											
        /// </summary>																											
        /// <typeparam name="T">dependencyObject type</typeparam>																											
        public static RectAnimationBuilder<T> WithRectAnimation<T>(this T target) where T : DependencyObject
        {
            RectAnimationBuilder<T> builder = new();
            return builder.Target(target);
        }
        /// <summary>																											
        /// Attach <see cref="Rotation3DAnimation"/> to dependencyObject object																											
        /// </summary>																											
        /// <typeparam name="T">dependencyObject type</typeparam>																											
        public static Rotation3DAnimationBuilder<T> WithRotation3DAnimation<T>(this T target) where T : DependencyObject
        {
            Rotation3DAnimationBuilder<T> builder = new();
            return builder.Target(target);
        }
        /// <summary>																											
        /// Attach <see cref="SingleAnimation"/> to dependencyObject object																											
        /// </summary>																											
        /// <typeparam name="T">dependencyObject type</typeparam>																											
        public static SingleAnimationBuilder<T> WithSingleAnimation<T>(this T target) where T : DependencyObject
        {
            SingleAnimationBuilder<T> builder = new();
            return builder.Target(target);
        }
        /// <summary>																											
        /// Attach <see cref="SizeAnimation"/> to dependencyObject object																											
        /// </summary>																											
        /// <typeparam name="T">dependencyObject type</typeparam>																											
        public static SizeAnimationBuilder<T> WithSizeAnimation<T>(this T target) where T : DependencyObject
        {
            SizeAnimationBuilder<T> builder = new();
            return builder.Target(target);
        }
        /// <summary>																											
        /// Attach <see cref="Vector3DAnimation"/> to dependencyObject object																											
        /// </summary>																											
        /// <typeparam name="T">dependencyObject type</typeparam>																											
        public static Vector3DAnimationBuilder<T> WithVector3DAnimation<T>(this T target) where T : DependencyObject
        {
            Vector3DAnimationBuilder<T> builder = new();
            return builder.Target(target);
        }
        /// <summary>																											
        /// Attach <see cref="VectorAnimation"/> to dependencyObject object																											
        /// </summary>																											
        /// <typeparam name="T">dependencyObject type</typeparam>																											
        public static VectorAnimationBuilder<T> WithVectorAnimation<T>(this T target) where T : DependencyObject
        {
            VectorAnimationBuilder<T> builder = new();
            return builder.Target(target);
        }
    }
}
