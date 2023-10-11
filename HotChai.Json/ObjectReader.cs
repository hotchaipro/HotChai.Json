﻿#region License
// Copyright (c) 2014, David Taylor
//
// Permission to use, copy, modify, and/or distribute this software for any 
// purpose with or without fee is hereby granted, provided that the above 
// copyright notice and this permission notice appear in all copies, unless 
// such copies are solely in the form of machine-executable object code 
// generated by a source language processor.
//
// THE SOFTWARE IS PROVIDED "AS IS" AND THE AUTHOR DISCLAIMS ALL WARRANTIES 
// WITH REGARD TO THIS SOFTWARE INCLUDING ALL IMPLIED WARRANTIES OF 
// MERCHANTABILITY AND FITNESS. IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR 
// ANY SPECIAL, DIRECT, INDIRECT, OR CONSEQUENTIAL DAMAGES OR ANY DAMAGES 
// WHATSOEVER RESULTING FROM LOSS OF USE, DATA OR PROFITS, WHETHER IN AN 
// ACTION OF CONTRACT, NEGLIGENCE OR OTHER TORTIOUS ACTION, ARISING OUT OF 
// OR IN CONNECTION WITH THE USE OR PERFORMANCE OF THIS SOFTWARE.
#endregion License
using System;
using System.Collections.Generic;

namespace HotChai.Json
{
    /// <summary>
    /// Reads a serialized object.
    /// </summary>
    public abstract class ObjectReader<TMemberKey>
    {
        private Stack<ObjectReaderState> _state;
        private TMemberKey _memberKey;

        protected ObjectReader()
        {
            this._state = new Stack<ObjectReaderState>();
            this._memberKey = this.InvalidMemberKey;
            this._state.Push(InitialState.State);
        }

        /// <summary>
        /// Gets the key of the current object member.
        /// </summary>
        public TMemberKey MemberKey
        {
            get { return this._memberKey; }

            protected set { this._memberKey = value; }
        }

        protected abstract TMemberKey InvalidMemberKey
        {
            get;
        }

        /// <summary>
        /// Reads the start of a serialized object.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the start of a serialized object was read; otherwise,
        /// <c>false</c> if the serialized object is null.
        /// </returns>
        public bool ReadStartObject()
        {
            this.MemberKey = InvalidMemberKey;

            return this.State.ReadStartObject(this);
        }

        /// <summary>
        /// Moves the reader to the next member of a serialized object.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the next member key was read, or <c>false</c> if the 
        /// serialized object has no more members.
        /// </returns>
        public bool MoveToNextMember()
        {
            return this.State.MoveToNextObjectMember(this);
        }

        /// <summary>
        /// Reads the end of a serialized object.
        /// </summary>
        public void ReadEndObject()
        {
            this.State.ReadEndObject(this);

            this.MemberKey = InvalidMemberKey;
        }

        /// <summary>
        /// Reads the start of a serialized array.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the start of a serialized array was read; otherwise,
        /// <c>false</c> if the serialized array is null.
        /// </returns>
        public bool ReadStartArray()
        {
            return this.State.ReadStartArray(this);
        }

        /// <summary>
        /// Moves the reader to the next value in a serialized array.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the reader moved to the next array value; otherwise,
        /// <c>false</c> if the end of the array was reached.
        /// </returns>
        public bool MoveToNextArrayValue()
        {
            return this.State.MoveToNextArrayValue(this);
        }

        /// <summary>
        /// Reads the end of a serialized object.
        /// </summary>
        public void ReadEndArray()
        {
            this.State.ReadEndArray(this);
        }

        /// <summary>
        /// Reads the current value as a <c>Boolean</c> type.
        /// </summary>
        /// <returns>The <c>Boolean</c> value.</returns>
        public bool ReadValueAsBoolean()
        {
            this.State.ReadPrimitiveValue(this);
            return this.ReadPrimitiveValueAsBoolean();
        }

        /// <summary>
        /// Reads the current value as an <c>Int32</c> type.
        /// </summary>
        /// <returns>The <c>Int32</c> value.</returns>
        public int ReadValueAsInt32()
        {
            this.State.ReadPrimitiveValue(this);
            return this.ReadPrimitiveValueAsInt32();
        }

        /// <summary>
        /// Reads the current value as a <c>UInt32</c> type.
        /// </summary>
        /// <returns>The <c>UInt32</c> value.</returns>
        public uint ReadValueAsUInt32()
        {
            this.State.ReadPrimitiveValue(this);
            return this.ReadPrimitiveValueAsUInt32();
        }

        /// <summary>
        /// Reads the current value as an <c>Int64</c> type.
        /// </summary>
        /// <returns>The <c>Int64</c> value.</returns>
        public long ReadValueAsInt64()
        {
            this.State.ReadPrimitiveValue(this);
            return this.ReadPrimitiveValueAsInt64();
        }

        /// <summary>
        /// Reads the current value as a <c>UInt64</c> type.
        /// </summary>
        /// <returns>The <c>UInt64</c> value.</returns>
        public ulong ReadValueAsUInt64()
        {
            this.State.ReadPrimitiveValue(this);
            return this.ReadPrimitiveValueAsUInt64();
        }

        /// <summary>
        /// Reads the current value as a <c>Single</c> type.
        /// </summary>
        /// <returns>The <c>Single</c> value.</returns>
        public float ReadValueAsSingle()
        {
            this.State.ReadPrimitiveValue(this);
            return this.ReadPrimitiveValueAsSingle();
        }

        /// <summary>
        /// Reads the current value as a <c>Double</c> type.
        /// </summary>
        /// <returns>The <c>Double</c> value.</returns>
        public double ReadValueAsDouble()
        {
            this.State.ReadPrimitiveValue(this);
            return this.ReadPrimitiveValueAsDouble();
        }

        /// <summary>
        /// Reads the current value as an array of <c>Byte</c>.
        /// </summary>
        /// <returns>The array of <c>Byte</c> value.</returns>
        public byte[] ReadValueAsBytes(
            int byteQuota)
        {
            this.State.ReadPrimitiveValue(this);
            return this.ReadPrimitiveValueAsBytes(byteQuota);
        }

        /// <summary>
        /// Reads the current value as a <c>String</c> type.
        /// </summary>
        /// <returns>The <c>String</c> value.</returns>
        public string ReadValueAsString(
            int byteQuota)
        {
            this.State.ReadPrimitiveValue(this);
            return this.ReadPrimitiveValueAsString(byteQuota);
        }

        #region State Machine

        private abstract class ObjectReaderState
        {
            protected ObjectReaderState()
            {
            }

            public virtual bool ReadStartObject(
                ObjectReader<TMemberKey> reader)
            {
                throw new InvalidOperationException();
            }

            public virtual bool MoveToNextObjectMember(
                ObjectReader<TMemberKey> reader)
            {
                throw new InvalidOperationException();
            }

            public virtual void ReadEndObject(
                ObjectReader<TMemberKey> reader)
            {
                throw new InvalidOperationException();
            }

            public virtual bool ReadStartArray(
                ObjectReader<TMemberKey> reader)
            {
                throw new InvalidOperationException();
            }

            public virtual bool MoveToNextArrayValue(
                ObjectReader<TMemberKey> reader)
            {
                throw new InvalidOperationException();
            }

            public virtual void ReadEndArray(
                ObjectReader<TMemberKey> reader)
            {
                throw new InvalidOperationException();
            }

            public virtual void ReadPrimitiveValue(
                ObjectReader<TMemberKey> reader)
            {
                throw new InvalidOperationException();
            }

            public abstract void Skip(
                ObjectReader<TMemberKey> reader);
        }

        private sealed class InitialState : ObjectReaderState
        {
            internal static readonly InitialState State = new InitialState();

            private InitialState()
            {
            }

            public override bool ReadStartObject(
                ObjectReader<TMemberKey> reader)
            {
                if (reader.ReadStartObjectToken())
                {
                    // Start of a new object
                    reader.PushState(StartObjectState.State);
                    return true;
                }
                else
                {
                    // No object (null)
                    return false;
                }
            }

            public override bool ReadStartArray(
                ObjectReader<TMemberKey> reader)
            {
                if (reader.ReadStartArrayToken())
                {
                    // Start of a new array
                    reader.PushState(StartArrayState.State);
                    return true;
                }
                else
                {
                    // No array (null)
                    return false;
                }
            }

            public override void Skip(
                ObjectReader<TMemberKey> reader)
            {
                MemberValueType type = reader.PeekValueType();
                if (type == MemberValueType.Object)
                {
                    ReadStartObject(reader);
                }
                else if (type == MemberValueType.Array)
                {
                    ReadStartArray(reader);
                }
                else
                {
                    throw new NotSupportedException("Unsupported value type.");
                }
            }
        }

        private sealed class StartObjectState : ObjectReaderState
        {
            internal static readonly StartObjectState State = new StartObjectState();

            private StartObjectState()
            {
            }

            public override bool MoveToNextObjectMember(
                ObjectReader<TMemberKey> reader)
            {
                // Try to read the first member key
                if (reader.ReadFirstObjectMemberKey())
                {
                    // Next member key
                    reader.SetState(MemberKeyState.State);
                    return true;
                }
                else
                {
                    // No more members (end of object)
                    reader.SetState(EndObjectState.State);
                    return false;
                }
            }

            public override void Skip(
                ObjectReader<TMemberKey> reader)
            {
                MoveToNextObjectMember(reader);
            }
        }

        private sealed class MemberKeyState : ObjectReaderState
        {
            public static readonly MemberKeyState State = new MemberKeyState();

            private MemberKeyState()
            {
            }

            public override bool ReadStartObject(
                ObjectReader<TMemberKey> reader)
            {
                reader.SetState(MemberValueState.State);

                return InitialState.State.ReadStartObject(reader);
            }

            public override bool ReadStartArray(
                ObjectReader<TMemberKey> reader)
            {
                reader.SetState(MemberValueState.State);

                if (reader.ReadStartArrayToken())
                {
                    // Start of a new array
                    reader.PushState(StartArrayState.State);
                    return true;
                }
                else
                {
                    // No array (null)
                    return false;
                }
            }

            public override void ReadPrimitiveValue(
                ObjectReader<TMemberKey> reader)
            {
                reader.SetState(MemberValueState.State);
            }

            public override bool MoveToNextObjectMember(
                ObjectReader<TMemberKey> reader)
            {
                // Skip the current value
                reader.SkipValue();

                // Move to the next member
                return MemberValueState.State.MoveToNextObjectMember(reader);
            }

            public override void Skip(
                ObjectReader<TMemberKey> reader)
            {
                MemberValueType type = reader.PeekValueType();
                if (type == MemberValueType.Object)
                {
                    ReadStartObject(reader);
                }
                else if (type == MemberValueType.Array)
                {
                    ReadStartArray(reader);
                }
                else if (type == MemberValueType.Primitive)
                {
                    ReadPrimitiveValue(reader);
                    reader.SkipPrimitiveValue();
                }
                else
                {
                    throw new NotSupportedException("Unsupported value type.");
                }
            }
        }

        private sealed class MemberValueState : ObjectReaderState
        {
            public static readonly MemberValueState State = new MemberValueState();

            private MemberValueState()
            {
            }

            public override bool MoveToNextObjectMember(
                ObjectReader<TMemberKey> reader)
            {
                // Try to read the next member key
                if (reader.ReadNextObjectMemberKey())
                {
                    // Next member key
                    reader.SetState(MemberKeyState.State);
                    return true;
                }
                else
                {
                    // No more members (end of object)
                    reader.SetState(EndObjectState.State);
                    return false;
                }
            }

            public override void Skip(
                ObjectReader<TMemberKey> reader)
            {
                MoveToNextObjectMember(reader);
            }
        }

        private sealed class EndObjectState : ObjectReaderState
        {
            public static readonly EndObjectState State = new EndObjectState();

            private EndObjectState()
            {
            }

            public override void ReadEndObject(
                ObjectReader<TMemberKey> reader)
            {
                reader.ReadEndObjectToken();
                reader.PopState();
            }

            public override void Skip(
                ObjectReader<TMemberKey> reader)
            {
                ReadEndObject(reader);
            }
        }

        private sealed class StartArrayState : ObjectReaderState
        {
            public static readonly StartArrayState State = new StartArrayState();

            private StartArrayState()
            {
            }

            public override bool MoveToNextArrayValue(
                ObjectReader<TMemberKey> reader)
            {
                // Check for the end of the array
                if (reader.ReadToFirstArrayValue())
                {
                    reader.SetState(StartArrayValueState.State);
                    return true;
                }
                else
                {
                    reader.SetState(EndArrayState.State);
                    return false;
                }
            }

            public override void Skip(
                ObjectReader<TMemberKey> reader)
            {
                MoveToNextArrayValue(reader);
            }
        }

        private sealed class StartArrayValueState : ObjectReaderState
        {
            public static readonly StartArrayValueState State = new StartArrayValueState();

            private StartArrayValueState()
            {
            }

            public override bool ReadStartObject(
                ObjectReader<TMemberKey> reader)
            {
                reader.SetState(EndArrayValueState.State);

                return InitialState.State.ReadStartObject(reader);
            }

            public override bool ReadStartArray(
                ObjectReader<TMemberKey> reader)
            {
                reader.SetState(EndArrayValueState.State);

                if (reader.ReadStartArrayToken())
                {
                    // Start of a new array
                    reader.PushState(StartArrayState.State);
                    return true;
                }
                else
                {
                    // No array (null)
                    return false;
                }
            }

            public override void ReadPrimitiveValue(
                ObjectReader<TMemberKey> reader)
            {
                reader.SetState(EndArrayValueState.State);
            }

            public override void Skip(
                ObjectReader<TMemberKey> reader)
            {
                MemberValueType type = reader.PeekValueType();
                if (type == MemberValueType.Object)
                {
                    ReadStartObject(reader);
                }
                else if (type == MemberValueType.Array)
                {
                    ReadStartArray(reader);
                }
                else if (type == MemberValueType.Primitive)
                {
                    ReadPrimitiveValue(reader);
                    reader.SkipPrimitiveValue();
                }
                else
                {
                    throw new NotSupportedException("Unsupported value type.");
                }
            }
        }

        private sealed class EndArrayValueState : ObjectReaderState
        {
            public static readonly EndArrayValueState State = new EndArrayValueState();

            private EndArrayValueState()
            {
            }

            public override bool MoveToNextArrayValue(
                ObjectReader<TMemberKey> reader)
            {
                // Check for the end of the array
                if (reader.ReadToNextArrayValue())
                {
                    reader.SetState(StartArrayValueState.State);
                    return true;
                }
                else
                {
                    reader.SetState(EndArrayState.State);
                    return false;
                }
            }

            public override void Skip(
                ObjectReader<TMemberKey> reader)
            {
                MoveToNextArrayValue(reader);
            }
        }

        private sealed class EndArrayState : ObjectReaderState
        {
            public static readonly EndArrayState State = new EndArrayState();

            private EndArrayState()
            {
            }

            public override void ReadEndArray(
                ObjectReader<TMemberKey> reader)
            {
                reader.ReadEndArrayToken();
                reader.PopState();
            }

            public override void Skip(
                ObjectReader<TMemberKey> reader)
            {
                ReadEndArray(reader);
            }
        }

        private ObjectReaderState State
        {
            get { return this._state.Peek(); }
        }

        private void PushState(
            ObjectReaderState state)
        {
            if (null == state)
            {
                throw new ArgumentNullException("state");
            }

            this._state.Push(state);
        }

        private void PopState()
        {
            if (this._state.Count <= 1)
            {
                throw new InvalidOperationException();
            }

            this._state.Pop();
        }

        private void SetState(
            ObjectReaderState state)
        {
            PopState();
            PushState(state);
        }

        private bool SkipValue()
        {
            int depth = this._state.Count;

            do
            {
                this.State.Skip(this);
            }
            while (this._state.Count > depth);

            return true;
        }

        #endregion State Machine

        /// <summary>
        /// Reads the start of a serialized object at the current position.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the start of the serialized object was read, or <c>false</c> if 
        /// a null object value was read.
        /// </returns>
        protected abstract bool ReadStartObjectToken();

        /// <summary>
        /// Reads the first serialized object member key at the current position.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the member key was read, or <c>false</c> if 
        /// an end object token was read.
        /// </returns>
        /// <remarks>
        /// The default implementation calls ReadNextObjectMemberKey().
        /// </remarks>
        protected virtual bool ReadFirstObjectMemberKey()
        {
            return ReadNextObjectMemberKey();
        }

        /// <summary>
        /// Reads the next serialized object member key at the current position.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the member key was read, or <c>false</c> if 
        /// an end object token was read.
        /// </returns>
        protected abstract bool ReadNextObjectMemberKey();

        /// <summary>
        /// Reads the end of the serialized object at the current position.
        /// </summary>
        protected abstract void ReadEndObjectToken();

        /// <summary>
        /// Reads the start of a serialized array at the current position.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the start of the array was read, or <c>false</c> if 
        /// a null array value was read.
        /// </returns>
        protected abstract bool ReadStartArrayToken();

        /// <summary>
        /// Advances the reader to the first array value following the current position.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the reader was advanced, or <c>false</c> if 
        /// the end of the array was encountered.
        /// </returns>
        /// <remarks>
        /// The default implementation calls ReadToNextArrayValue().
        /// </remarks>
        protected virtual bool ReadToFirstArrayValue()
        {
            return ReadToNextArrayValue();
        }

        /// <summary>
        /// Advances the reader to the next array value following the current position.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the reader was advanced, or <c>false</c> if 
        /// the end of the array was encountered.
        /// </returns>
        protected abstract bool ReadToNextArrayValue();

        /// <summary>
        /// Reads the end of the serialized array at the current position.
        /// </summary>
        protected abstract void ReadEndArrayToken();

        /// <summary>
        /// Reads the current value as a <c>Boolean</c> type.
        /// </summary>
        /// <returns>The <c>Boolean</c> value.</returns>
        protected abstract bool ReadPrimitiveValueAsBoolean();

        /// <summary>
        /// Reads the current value as an <c>Int32</c> type.
        /// </summary>
        /// <returns>The <c>Int32</c> value.</returns>
        protected abstract int ReadPrimitiveValueAsInt32();

        /// <summary>
        /// Reads the current value as a <c>UInt32</c> type.
        /// </summary>
        /// <returns>The <c>UInt32</c> value.</returns>
        protected abstract uint ReadPrimitiveValueAsUInt32();

        /// <summary>
        /// Reads the current value as an <c>Int64</c> type.
        /// </summary>
        /// <returns>The <c>Int64</c> value.</returns>
        protected abstract long ReadPrimitiveValueAsInt64();

        /// <summary>
        /// Reads the current value as a <c>UInt64</c> type.
        /// </summary>
        /// <returns>The <c>UInt64</c> value.</returns>
        protected abstract ulong ReadPrimitiveValueAsUInt64();

        /// <summary>
        /// Reads the current value as a <c>Single</c> type.
        /// </summary>
        /// <returns>The <c>Single</c> value.</returns>
        protected abstract float ReadPrimitiveValueAsSingle();

        /// <summary>
        /// Reads the current value as a <c>Double</c> type.
        /// </summary>
        /// <returns>The <c>Double</c> value.</returns>
        protected abstract double ReadPrimitiveValueAsDouble();

        /// <summary>
        /// Reads the current value as an array of <c>Byte</c> type.
        /// </summary>
        /// <returns>The array of <c>Byte</c> value.</returns>
        protected abstract byte[] ReadPrimitiveValueAsBytes(int quota);

        /// <summary>
        /// Reads the current value as a <c>String</c> type.
        /// </summary>
        /// <returns>The <c>String</c> value.</returns>
        protected abstract string ReadPrimitiveValueAsString(int quota);

        /// <summary>
        /// Returns the <c>MemberType</c> of the value at the current 
        /// reader position, without advancing the reader.
        /// </summary>
        /// <returns>The <c>MemberType</c>.</returns>
        protected abstract MemberValueType PeekValueType();

        /// <summary>
        /// Skips the primitive value at the current reader position.
        /// </summary>
        protected abstract void SkipPrimitiveValue();
    }

    public enum MemberValueType
    {
        Object = 1,
        Array = 2,
        Primitive = 3,
    }
}
