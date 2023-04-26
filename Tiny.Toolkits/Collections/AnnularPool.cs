using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Tiny.Toolkits
{
    /// <summary>
    /// Annular Pool
    /// </summary>
    /// <typeparam name="Target"></typeparam>
    public class AnnularPool<Target>
    {
        /// <summary>
        /// Capacity
        /// </summary>
        public readonly int Capacity;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private Target[] buffer;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private int readTotalPos;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private int writeTotalPos;

        /// <summary>
        /// create a new <see cref="AnnularPool{Target}"/> by capacity
        /// </summary>
        /// <param name="capacity"></param>
        public AnnularPool(int capacity = 0)
        {
            int defaultCapacity = 1024;
            Capacity = capacity > defaultCapacity ? capacity : defaultCapacity;
            buffer = new Target[Capacity];
        }

        /// <summary>
        /// current read position
        /// </summary>
        public int ReadPosition { get; private set; }

        /// <summary>
        /// current write position
        /// </summary>
        public int WritePosition { get; private set; }

        /// <summary>
        /// pool can read
        /// </summary>
        public bool CanRead => writeTotalPos > readTotalPos;

        /// <summary>
        /// pool can write
        /// </summary>
        public bool CanWrite => writeTotalPos - readTotalPos < Capacity;

        /// <summary>
        /// pool can write length
        /// </summary>
        public int CanWriteLength => writeTotalPos + Capacity - readTotalPos;

        /// <summary>
        /// pool can read length
        /// </summary>
        public int CanReadLength => writeTotalPos - readTotalPos;

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
                BufferCopy(ref writeBuffer, offset, ref buffer, currentWritePosition, length);

                WritePosition = currentWritePosition + length;
            }
            else
            {
                int currentRowCanWriteLength = Capacity - currentWritePosition;

                int copySurplusLength = length - currentRowCanWriteLength;

                BufferCopy(ref writeBuffer, offset, ref buffer, currentWritePosition, currentRowCanWriteLength);

                BufferCopy(ref writeBuffer, offset + currentRowCanWriteLength, ref buffer, 0, copySurplusLength);

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
                BufferCopy(ref buffer, currentReadPosition, ref readBuffer, offset, length);

                ReadPosition = currentReadPosition + length;
            }
            else
            {
                int currentRowCanReadLength = Capacity - currentReadPosition;

                int copySurplusLength = length - currentRowCanReadLength;

                BufferCopy(ref buffer, currentReadPosition, ref readBuffer, offset, currentRowCanReadLength);

                BufferCopy(ref buffer, 0, ref readBuffer, offset + currentRowCanReadLength, copySurplusLength);

                ReadPosition = copySurplusLength;

            }

            readTotalPos += length;

        }

        /// <summary>
        /// array copy
        /// </summary>
        /// <param name="sourceArray"></param>
        /// <param name="sourceIndex"></param>
        /// <param name="destinationArray"></param>
        /// <param name="destinationIndex"></param>
        /// <param name="length"></param>
        protected virtual void BufferCopy(ref Target[] sourceArray, int sourceIndex, ref Target[] destinationArray, int destinationIndex, int length)
        {
            Array.ConstrainedCopy(sourceArray, sourceIndex, destinationArray, destinationIndex, length);
        }
    }
}
