using System; 
using System.Diagnostics; 
namespace Tiny.Toolkits
{
    /// <summary>
    /// Byte Buffer class
    /// </summary>
    [DebuggerDisplay("capacity:{capacity}")]
    [DebuggerNonUserCode]
    public class ByteBuffer
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private readonly byte[] container;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private int writeOffset = 0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private int readOffset = 0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private readonly int capacity = 0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const int SByteSize = sizeof(sbyte);
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const int ByteSize = sizeof(byte);
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const int UShortSize = sizeof(ushort);
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const int ShortSize = sizeof(short);
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const int UIntSize = sizeof(uint);
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const int IntSize = sizeof(int);
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const int ULongSize = sizeof(ulong);
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const int LongSize = sizeof(long);
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const int FloatSize = sizeof(float);
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const int DoubleSize = sizeof(double);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private readonly byte[] ushortArray = new byte[UShortSize];
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private readonly byte[] shortArray = new byte[ShortSize];
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private readonly byte[] uintArray = new byte[UIntSize];
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private readonly byte[] intArray = new byte[IntSize];
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private readonly byte[] ulongArray = new byte[ULongSize];
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private readonly byte[] longArray = new byte[LongSize];
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private readonly byte[] floatArray = new byte[FloatSize];
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private readonly byte[] doubleArray = new byte[DoubleSize];
        /// <summary>
        ///  Create a Buffer of specified size
        /// </summary>
        /// <param name="capacity">Buffer of specified size</param>
        /// <returns></returns>
        public static ByteBuffer Allocate(int capacity)
        {
            return new ByteBuffer(capacity);
        }

        /// <summary>
        ///  Create a new Buffer of specified size
        /// </summary>
        /// <param name="capacity">Buffer of specified size</param>
        /// <returns></returns>
        public ByteBuffer(int capacity)
        {
            this.capacity = capacity;
            container = new byte[capacity];
        }

        /// <summary>
        /// create a new buffer by exist buffer
        /// </summary>
        /// <param name="existBuffer"></param>
        public ByteBuffer(ref byte[] existBuffer)
        {
            capacity = existBuffer?.Length ?? 0;
            container = existBuffer;
        }

        /// <summary>
        /// reset write offset and read offset
        /// </summary>
        public void Reset()
        {
            writeOffset = readOffset = 0;
        }

        #region Read

        /// <summary>
        /// read a buffer array
        /// </summary>
        /// <param name="readCount"></param> 
        /// <returns></returns>
        public byte[] ReadBytes(int readCount)
        {

            byte[] bytes = new byte[readCount];

            Buffer.BlockCopy(container, readOffset, bytes, 0, readCount);

            readOffset += readCount;

            return bytes;

        }

        /// <summary>
        /// get byte value
        /// </summary> 
        /// <returns></returns>
        public byte ReadByte()
        {

            byte @byte = container[readOffset];

            readOffset += ByteSize;

            return @byte;

        }

        /// <summary>
        /// get uint16 value
        /// </summary> 
        /// <returns></returns>
        public ushort ReadUInt16()
        {

            Buffer.BlockCopy(container, readOffset, ushortArray, 0, UShortSize);

            readOffset += UShortSize;

            ushort value = BitConverter.ToUInt16(ushortArray, 0);

            return value;

        }

        /// <summary>
        /// get int16 value
        /// </summary> 
        /// <returns></returns>
        public short ReadInt16()
        {

            Buffer.BlockCopy(container, readOffset, shortArray, 0, ShortSize);

            readOffset += ShortSize;
            short value = BitConverter.ToInt16(shortArray, 0);
            return value;

        }

        /// <summary>
        /// get int16 value
        /// </summary> 
        /// <returns></returns>
        public sbyte ReadSByte()
        {

            Buffer.BlockCopy(container, readOffset, shortArray, 0, ShortSize);

            readOffset += ShortSize;
            sbyte value = (sbyte)BitConverter.ToInt16(shortArray, 0);
            return value;

        }

        /// <summary>
        /// get uint32 value
        /// </summary> 
        /// <returns></returns>
        public uint ReadUInt32()
        {

            Buffer.BlockCopy(container, readOffset, uintArray, 0, UIntSize);

            readOffset += UIntSize;
            uint value = BitConverter.ToUInt32(uintArray, 0);

            return value;

        }

        /// <summary>
        /// get int32 value
        /// </summary> 
        /// <returns></returns>
        public int ReadInt32()
        {

            Buffer.BlockCopy(container, readOffset, intArray, 0, IntSize);

            readOffset += IntSize;
            int value = BitConverter.ToInt32(intArray, 0);

            return value;

        }

        /// <summary>
        /// get uint64 value
        /// </summary> 
        /// <returns></returns>
        public ulong ReadUInt64()
        {

            Buffer.BlockCopy(container, readOffset, ulongArray, 0, ULongSize);

            readOffset += ULongSize;
            ulong value = BitConverter.ToUInt64(ulongArray, 0);

            return value;

        }

        /// <summary>
        /// get int64 value
        /// </summary> 
        /// <returns></returns>
        public long ReadInt64()
        {

            Buffer.BlockCopy(container, readOffset, longArray, 0, LongSize);

            readOffset += LongSize;
            long value = BitConverter.ToInt64(longArray, 0);

            return value;

        }

        /// <summary>
        /// get float value
        /// </summary> 
        /// <returns></returns>
        public float ReadFloat()
        {

            Buffer.BlockCopy(container, readOffset, floatArray, 0, FloatSize);

            readOffset += FloatSize;
            float value = BitConverter.ToSingle(floatArray, 0);

            return value;

        }

        /// <summary>
        /// get double value
        /// </summary> 
        /// <returns></returns>
        public double ReadDouble()
        {

            Buffer.BlockCopy(container, readOffset, doubleArray, 0, DoubleSize);

            readOffset += DoubleSize;
            double value = BitConverter.ToDouble(doubleArray, 0);

            return value;

        }

        /// <summary>
        /// get bool value
        /// </summary>
        /// 
        /// <returns></returns>
        public bool ReadBoolean()
        {
            const byte True = 1;

            byte value = container[readOffset];

            readOffset++;

            return value == True;

        }

        #endregion

        #region  Write

        /// <summary>
        /// write a byte array into the buffer
        /// </summary>
        /// <param name="buffer">byte array</param>
        /// <param name="offset">offset of the byte array</param>
        /// <param name="length">write count</param>
        /// <returns></returns>
        /// <Exception cref="ArgumentNullException"></Exception>
        public void Write(byte[] buffer, int offset, int length)
        {
            if (buffer is null || buffer.Length == 0)
            {
                throw new ArgumentException(nameof(buffer));
            }

            Buffer.BlockCopy(buffer, offset, container, writeOffset, length);

            writeOffset += length;

        }

        /// <summary>
        /// write a byte array into the buffer
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        /// <Exception cref="ArgumentNullException"></Exception>
        public void Write(byte[] buffer)
        {
            if (buffer is null || buffer.Length == 0)
            {
                throw new ArgumentException(nameof(buffer));
            }

            int length = buffer.Length;

            Buffer.BlockCopy(buffer, 0, container, writeOffset, buffer.Length);
            writeOffset += length;

        }

        /// <summary>
        /// write a int16 value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public void Write(short value)
        {

            byte[] buffer = BitConverter.GetBytes(value);
            Buffer.BlockCopy(buffer, 0, container, writeOffset, ShortSize);
            writeOffset += ShortSize;

        }

        /// <summary>
        /// write a sbyte value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public void Write(sbyte value)
        {

            short value1 = value;
            byte[] buffer = BitConverter.GetBytes(value1);
            Buffer.BlockCopy(buffer, 0, container, writeOffset, ShortSize);
            writeOffset += ShortSize;

        }

        /// <summary>
        /// write a uint16 value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public void Write(ushort value)
        {

            byte[] buffer = BitConverter.GetBytes(value);
            Buffer.BlockCopy(buffer, 0, container, writeOffset, UShortSize);
            writeOffset += UShortSize;

        }

        /// <summary>
        /// write a int32 value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public void Write(int value)
        {

            byte[] buffer = BitConverter.GetBytes(value);
            Buffer.BlockCopy(buffer, 0, container, writeOffset, IntSize);
            writeOffset += IntSize;

        }

        /// <summary>
        /// write a uint32 value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public void Write(uint value)
        {

            byte[] buffer = BitConverter.GetBytes(value);
            Buffer.BlockCopy(buffer, 0, container, writeOffset, UIntSize);
            writeOffset += UIntSize;

        }

        /// <summary>
        /// write a int64 value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public void Write(long value)
        {

            byte[] buffer = BitConverter.GetBytes(value);
            Buffer.BlockCopy(buffer, 0, container, writeOffset, LongSize);
            writeOffset += LongSize;

        }

        /// <summary>
        /// write a uint64 value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public void Write(ulong value)
        {

            byte[] buffer = BitConverter.GetBytes(value);
            Buffer.BlockCopy(buffer, 0, container, writeOffset, ULongSize);
            writeOffset += ULongSize;

        }

        /// <summary>
        /// write a float value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public void Write(float value)
        {

            byte[] buffer = BitConverter.GetBytes(value);
            Buffer.BlockCopy(buffer, 0, container, writeOffset, FloatSize);
            writeOffset += FloatSize;

        }
        /// <summary>
        /// write a double value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public void Write(double value)
        {

            byte[] buffer = BitConverter.GetBytes(value);
            Buffer.BlockCopy(buffer, 0, container, writeOffset, DoubleSize);
            writeOffset += DoubleSize;

        }

        /// <summary>
        /// write  a byte value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public void Write(byte value)
        {

            container[writeOffset] = value;
            writeOffset++;

        }

        /// <summary>
        /// write a bool value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public void Write(bool value)
        {
            const byte True = 1;
            const byte False = 0;

            container[writeOffset] = value ? True : False;
            writeOffset++;

        }

        #endregion

    }
}