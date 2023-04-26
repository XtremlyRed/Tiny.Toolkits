using System.ComponentModel;
using System.Diagnostics;

namespace Tiny.Toolkits
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TRef"></typeparam>

    [DebuggerDisplay("{value}")]
    public partial struct Ref<TRef>
    {
        /// <summary>
        /// create a <typeparamref name="TRef"/> object ref
        /// </summary>
        /// <param name="value"></param>
        public Ref(TRef value)
        {
            this.value = value;
        }

        /// <summary>
        /// current value
        /// </summary>
        public TRef Value => value;

        [DebuggerBrowsable(DebuggerBrowsableState.Never), EditorBrowsable(EditorBrowsableState.Never)]
        private TRef value;

        /// <summary>
        /// ref value
        /// </summary>
        /// <param name="value"></param>
        public void Modify(TRef value)
        {
            this.value = value;
        }

        /// <summary>
        /// explicit ref value
        /// </summary>
        /// <param name="ref"></param>
        public static explicit operator TRef(Ref<TRef> @ref)
        {
            return @ref.Value;
        }


        /// <summary>
        /// explicit ref value
        /// </summary>
        /// <param name="ref"></param>
        public static explicit operator Ref<TRef>(TRef @ref)
        {
            return new Ref<TRef>(@ref);
        }




        #region hide base function

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj"> The object to compare with the current object.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        /// <summary>
        ///  Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString()
        {
            return base.ToString();
        }


        #endregion


    }
}
