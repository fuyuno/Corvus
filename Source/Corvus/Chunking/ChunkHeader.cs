﻿using System.Collections.Generic;

namespace Corvus.Chunking
{
    public class ChunkHeader
    {
        private readonly ChunkBasicHeader _basicHeader;
        private readonly ChunkMessageHeader _messageHeader;

        public ChunkHeader(byte fmt, ushort csid, byte msgTypeId, int msgStreamId, byte[] body)
        {
            _basicHeader = new ChunkBasicHeader(fmt, csid);
            _messageHeader = new ChunkMessageHeader(fmt, (uint) body.Length, msgTypeId, msgStreamId);
        }

        public byte[] GetBytes()
        {
            var bytes = new List<byte>();
            bytes.AddRange(_basicHeader.GetBytes());
            bytes.AddRange(_messageHeader.GetBytes());
            // FIXME: Extended timestamp.
            return bytes.ToArray();
        }
    }
}