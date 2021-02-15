//------------------------------------------------------------------------------
// <auto-generated />
// This file was automatically generated by the UpdateVendors tool.
//------------------------------------------------------------------------------
using System;
using System.Net.Sockets;
using System.Threading.Tasks;
using Mono.Unix;

namespace OpenTelemetry.Instrumentation.Vendors.StatsdClient.Transport
{
    internal class UnixDomainSocketTransport : ITransport
    {
        private static readonly TimeSpan NoBufferSpaceAvailableWait = TimeSpan.FromMilliseconds(10);
        private readonly Socket _socket;
        private readonly int _noBufferSpaceAvailableRetryCount;
        private readonly UnixEndPoint _endPoint;

        public UnixDomainSocketTransport(
            UnixEndPoint endPoint,
            TimeSpan? bufferFullBlockDuration)
        {
            if (bufferFullBlockDuration.HasValue)
            {
                _noBufferSpaceAvailableRetryCount = (int)(bufferFullBlockDuration.Value.TotalMilliseconds
                    / NoBufferSpaceAvailableWait.TotalMilliseconds);
            }

            try
            {
                _socket = new Socket(AddressFamily.Unix, SocketType.Dgram, ProtocolType.Unspecified);
            }
            catch (SocketException e)
            {
                throw new NotSupportedException($"Unix domain socket is not supported on your operating system.", e);
            }

            // When closing, wait 2 seconds to send data.
            _socket.LingerState = new LingerOption(true, 2);
            _endPoint = endPoint;
        }

        public TransportType TransportType => TransportType.UDS;

        public string TelemetryClientTransport => "uds";

        /// <summary>
        /// Send the buffer.
        /// Must be thread safe.
        /// </summary>
        public bool Send(byte[] buffer, int length)
        {
            for (int i = 0; i < 1 + _noBufferSpaceAvailableRetryCount; ++i)
            {
                try
                {
                    _socket.SendTo(buffer, 0, length, SocketFlags.None, _endPoint);
                    return true;
                }
                catch (SocketException e) when (e.SocketErrorCode == SocketError.NoBufferSpaceAvailable)
                {
                    Task.Delay(NoBufferSpaceAvailableWait).Wait();
                }
                catch (SocketException)
                {
                    return false;
                }
            }

            return false;
        }

        public void Dispose()
        {
            _socket.Dispose();
        }
    }
}
