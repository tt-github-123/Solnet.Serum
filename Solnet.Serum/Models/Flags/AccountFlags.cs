using Solnet.Programs.Abstract;
using System;
using System.Buffers.Binary;

namespace Solnet.Serum.Models.Flags
{
    /// <summary>
    /// Represents the account's flags.
    /// <remarks>
    /// According to this, the account can be a <see cref="Market"/>, an <see cref="OpenOrdersAccount"/>,
    /// an <see cref="EventQueue"/> or the Bids/Asks account for the order book.
    /// </remarks>
    /// </summary>
    public class AccountFlags
    {
        /// <summary>
        /// The flag which specifies the event type.
        /// </summary>
        public ByteFlag Flag;

        /// <summary>
        /// Whether the account is initialized or not.
        /// </summary>
        public bool IsInitialized => Flag.Bit0;
        
        /// <summary>
        /// Whether the account is a market account or not.
        /// </summary>
        public bool IsMarket => Flag.Bit1;

        /// <summary>
        /// Whether the account is an open orders account or not.
        /// </summary>
        public bool IsOpenOrders => Flag.Bit2;
        
        /// <summary>
        /// Whether the account is a request queue account or not.
        /// </summary>
        public bool IsRequestQueue => Flag.Bit3;

        /// <summary>
        /// Whether the account is an event queue account or not.
        /// </summary>
        public bool IsEventQueue => Flag.Bit4;
        
        /// <summary>
        /// Whether the account is a bids account or not.
        /// </summary>
        public bool IsBids => Flag.Bit5;

        /// <summary>
        /// Whether the account is an asks account or not.
        /// </summary>
        public bool IsAsks => Flag.Bit6;

        /// <summary>
        /// Initialize the account flags with the given bit mask.
        /// </summary>
        /// <param name="bitmask">The bit mask.</param>
        private AccountFlags(byte bitmask)
        {
            Flag = new ByteFlag(bitmask);
        }

        /// <summary>
        /// Deserialize a span of bytes into a <see cref="Market"/> instance.
        /// </summary>
        /// <param name="data">The data to deserialize into the structure.</param>
        /// <returns>The Market structure.</returns>
        internal static AccountFlags Deserialize(ReadOnlySpan<byte> data) 
            =>  new (data[0]);
    }
}