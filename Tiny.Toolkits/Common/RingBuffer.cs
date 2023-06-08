using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Tiny.Toolkits
{

    /// <summary>
    /// Annular Pool
    /// </summary>
    /// <typeparam name="Target"></typeparam>
    [DebuggerDisplay("{Count}")]
    public sealed class RingBuffer<Target>
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private readonly Target[] buffer;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private int readTotalPos;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private int writeTotalPos;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private int ReadPosition;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private int WritePosition;


        /// <summary>
        /// Capacity
        /// </summary>
        public readonly int Capacity;

        /// <summary>
        /// create a new <see cref="RingBuffer{Target}"/> by capacity
        /// </summary>
        /// <param name="capacity"></param>
        public RingBuffer(int capacity = 0)
        {
            int defaultCapacity = 1024;
            Capacity = capacity > defaultCapacity ? capacity : defaultCapacity;
            buffer = new Target[Capacity];
        }



        /// <summary>
        /// pool can read
        /// </summary>
        public bool CanRead => writeTotalPos > readTotalPos;

        /// <summary>
        /// pool can write
        /// </summary>
        public bool CanWrite => writeTotalPos - readTotalPos < Capacity;

        /// <summary>
        /// valid data length
        /// </summary>
        public int Count => writeTotalPos - readTotalPos;

        /// <summary>
        /// write  array data to pool
        /// </summary>
        /// <param name="writeBuffer">array data</param>
        /// <param name="offset">offset in array</param>
        /// <param name="length">length</param>
        /// <Exception cref="Exception"></Exception>
        public void Write(Target[] writeBuffer, int offset, int length)
        {

            if (writeTotalPos + Capacity - readTotalPos < length)
            {
                throw new Exception("Insufficient remaining writable space, unable to continue writing");
            }

            int currentWritePosition = WritePosition;

            if (Capacity - currentWritePosition >= length)
            {
                Array.ConstrainedCopy(writeBuffer, offset, buffer, currentWritePosition, length);

                WritePosition = currentWritePosition + length;
            }
            else
            {
                int currentRowCanWriteLength = Capacity - currentWritePosition;

                int copySurplusLength = length - currentRowCanWriteLength;

                Array.ConstrainedCopy(writeBuffer, offset, buffer, currentWritePosition, currentRowCanWriteLength);

                Array.ConstrainedCopy(writeBuffer, offset + currentRowCanWriteLength, buffer, 0, copySurplusLength);

                WritePosition = copySurplusLength;

            }

            writeTotalPos += length;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="readBuffer"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <Exception cref="Exception"></Exception>
        public void Read(Target[] readBuffer, int offset, int length)
        {
            if (length <= 0)
            {
                throw new Exception($"{nameof(length)} error, cannot read");
            }

            int surplusLength = readBuffer.Length - offset;

            if (surplusLength <= 0 || surplusLength < length)
            {
                throw new Exception($"{nameof(readBuffer)} Insufficient free space to write");
            }

            if (writeTotalPos - readTotalPos < length)
            {
                throw new Exception("The length of the readable data is not enough to continue reading");
            }

            int currentReadPosition = ReadPosition;

            if (Capacity - currentReadPosition >= length)
            {
                Array.ConstrainedCopy(buffer, currentReadPosition, readBuffer, offset, length);

                ReadPosition = currentReadPosition + length;
            }
            else
            {
                int currentRowCanReadLength = Capacity - currentReadPosition;

                int copySurplusLength = length - currentRowCanReadLength;

                Array.ConstrainedCopy(buffer, currentReadPosition, readBuffer, offset, currentRowCanReadLength);

                Array.ConstrainedCopy(buffer, 0, readBuffer, offset + currentRowCanReadLength, copySurplusLength);

                ReadPosition = copySurplusLength;

            }

            readTotalPos += length;

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


    public static class RingBufferExtensions
    {
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
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const int TrueSize = 1;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private const int FalseSize = 1;



        #region Read

        /// <summary>
        /// read a buffer array
        /// </summary>
        /// <param name="readCount"></param> 
        /// <returns></returns>
        public static byte[] ReadBytes(this RingBuffer<byte> ringBuffer, int readCount)
        {
            byte[] bytes = new byte[readCount];

            ringBuffer.Read(bytes, 0, bytes.Length);

            return bytes;

        }

        /// <summary>
        /// get byte value
        /// </summary> 
        /// <returns></returns>
        public static byte ReadByte(this RingBuffer<byte> ringBuffer)
        {
            byte[] bytes = new byte[ByteSize];

            ringBuffer.Read(bytes, 0, bytes.Length);

            return bytes[0];
        }
        /// <summary>
        /// get int16 value
        /// </summary> 
        /// <returns></returns>
        public static sbyte ReadSByte(this RingBuffer<byte> ringBuffer)
        {

            byte[] bytes = new byte[ShortSize];

            ringBuffer.Read(bytes, 0, bytes.Length);

            sbyte value = (sbyte)BitConverter.ToInt16(bytes, 0);

            return value;

        }
        /// <summary>
        /// get uint16 value
        /// </summary> 
        /// <returns></returns>
        public static ushort ReadUInt16(this RingBuffer<byte> ringBuffer)
        {

            byte[] bytes = new byte[UShortSize];

            ringBuffer.Read(bytes, 0, bytes.Length);

            ushort value = BitConverter.ToUInt16(bytes, 0);

            return value;

        }

        /// <summary>
        /// get int16 value
        /// </summary> 
        /// <returns></returns>
        public static short ReadInt16(this RingBuffer<byte> ringBuffer)
        {

            byte[] bytes = new byte[ShortSize];

            ringBuffer.Read(bytes, 0, bytes.Length);

            short value = BitConverter.ToInt16(bytes, 0);

            return value;

        }

        /// <summary>
        /// get uint32 value
        /// </summary> 
        /// <returns></returns>
        public static uint ReadUInt32(this RingBuffer<byte> ringBuffer)
        {
            byte[] bytes = new byte[UIntSize];

            ringBuffer.Read(bytes, 0, bytes.Length);

            uint value = BitConverter.ToUInt32(bytes, 0);

            return value;

        }

        /// <summary>
        /// get int32 value
        /// </summary> 
        /// <returns></returns>
        public static int ReadInt32(this RingBuffer<byte> ringBuffer)
        {
            byte[] bytes = new byte[IntSize];

            ringBuffer.Read(bytes, 0, bytes.Length);

            int value = BitConverter.ToInt32(bytes, 0);

            return value;

        }

        /// <summary>
        /// get uint64 value
        /// </summary> 
        /// <returns></returns>
        public static ulong ReadUInt64(this RingBuffer<byte> ringBuffer)
        {

            byte[] bytes = new byte[ULongSize];

            ringBuffer.Read(bytes, 0, bytes.Length);

            ulong value = BitConverter.ToUInt64(bytes, 0);

            return value;

        }

        /// <summary>
        /// get int64 value
        /// </summary> 
        /// <returns></returns>
        public static long ReadInt64(this RingBuffer<byte> ringBuffer)
        {

            byte[] bytes = new byte[LongSize];

            ringBuffer.Read(bytes, 0, bytes.Length);

            long value = BitConverter.ToInt64(bytes, 0);

            return value;

        }

        /// <summary>
        /// get float value
        /// </summary> 
        /// <returns></returns>
        public static float ReadFloat(this RingBuffer<byte> ringBuffer)
        {
            byte[] bytes = new byte[FloatSize];

            ringBuffer.Read(bytes, 0, bytes.Length);

            float value = BitConverter.ToSingle(bytes, 0);

            return value;

        }

        /// <summary>
        /// get double value
        /// </summary> 
        /// <returns></returns>
        public static double ReadDouble(this RingBuffer<byte> ringBuffer)
        {

            byte[] bytes = new byte[DoubleSize];

            ringBuffer.Read(bytes, 0, bytes.Length);

            double value = BitConverter.ToDouble(bytes, 0);

            return value;

        }

        /// <summary>
        /// get bool value
        /// </summary>
        /// 
        /// <returns></returns>
        public static bool ReadBoolean(this RingBuffer<byte> ringBuffer)
        {
            byte[] bytes = new byte[TrueSize];

            ringBuffer.Read(bytes, 0, bytes.Length);

            return bytes[0] == 1;

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
        public static void Write(this RingBuffer<byte> ringBuffer, byte[] buffer, int offset, int length)
        {
            if (buffer is null)
            {
                throw new ArgumentException(nameof(buffer));
            }
            if (buffer.Length == 0)
            {
                return;
            }
            ringBuffer.Write(buffer, offset, length);

        }

        /// <summary>
        /// write a byte array into the buffer
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        /// <Exception cref="ArgumentNullException"></Exception>
        public static void Write(this RingBuffer<byte> ringBuffer, byte[] buffer)
        {
            if (buffer is null)
            {
                throw new ArgumentException(nameof(buffer));
            }
            if (buffer.Length == 0)
            {
                return;
            }

            ringBuffer.Write(buffer, 0, buffer.Length);

        }

        /// <summary>
        /// write a int16 value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void Write(this RingBuffer<byte> ringBuffer, short value)
        {
            byte[] buffer = BitConverter.GetBytes(value);
            ringBuffer.Write(buffer, 0, buffer.Length);
        }

        /// <summary>
        /// write a sbyte value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void Write(this RingBuffer<byte> ringBuffer, sbyte value)
        {
            short shoutValue = value;
            byte[] buffer = BitConverter.GetBytes(shoutValue);
            ringBuffer.Write(buffer, 0, buffer.Length);
        }

        /// <summary>
        /// write a uint16 value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void Write(this RingBuffer<byte> ringBuffer, ushort value)
        {
            byte[] buffer = BitConverter.GetBytes(value);
            ringBuffer.Write(buffer, 0, buffer.Length);

        }

        /// <summary>
        /// write a int32 value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void Write(this RingBuffer<byte> ringBuffer, int value)
        {
            byte[] buffer = BitConverter.GetBytes(value);
            ringBuffer.Write(buffer, 0, buffer.Length);
        }

        /// <summary>
        /// write a uint32 value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void Write(this RingBuffer<byte> ringBuffer, uint value)
        {
            byte[] buffer = BitConverter.GetBytes(value);
            ringBuffer.Write(buffer, 0, buffer.Length);

        }

        /// <summary>
        /// write a int64 value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void Write(this RingBuffer<byte> ringBuffer, long value)
        {
            byte[] buffer = BitConverter.GetBytes(value);
            ringBuffer.Write(buffer, 0, buffer.Length);

        }

        /// <summary>
        /// write a uint64 value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void Write(this RingBuffer<byte> ringBuffer, ulong value)
        {
            byte[] buffer = BitConverter.GetBytes(value);
            ringBuffer.Write(buffer, 0, buffer.Length);

        }

        /// <summary>
        /// write a float value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void Write(this RingBuffer<byte> ringBuffer, float value)
        {
            byte[] buffer = BitConverter.GetBytes(value);
            ringBuffer.Write(buffer, 0, buffer.Length);

        }
        /// <summary>
        /// write a double value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void Write(this RingBuffer<byte> ringBuffer, double value)
        {
            byte[] buffer = BitConverter.GetBytes(value);
            ringBuffer.Write(buffer, 0, buffer.Length);

        }

        /// <summary>
        /// write  a byte value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void Write(this RingBuffer<byte> ringBuffer, byte value)
        {
            ringBuffer.Write(new[] { value }, 0, 1);
        }

        /// <summary>
        /// write a bool value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void Write(this RingBuffer<byte> ringBuffer, bool value)
        {
            const byte True = 1;
            const byte False = 0;
            ringBuffer.Write(new[] { value ? True : False }, 0, 1);

        }

        #endregion

    }
}
