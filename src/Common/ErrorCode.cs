﻿using System;
using System.Diagnostics.Tracing;
using System.Globalization;

namespace Common
{
    public class ErrorCode : IEquatable<ErrorCode>
    {
        public static readonly ErrorCode Empty = new ErrorCode(0);

        public int Id { get; }

        public string? Name { get; }

        public string? Message { get; }


        public static implicit operator ErrorCode(int i)
        {
            return new ErrorCode(i);
        }

        public static bool operator ==(ErrorCode? left, ErrorCode? right)
        {
            if (left == null && right == null)
            {
                return true;
            }

            if (left == null || right == null)
            {
                return false;
            }

            return left.Equals(right);
        }

        public static bool operator !=(ErrorCode? left, ErrorCode? right)
        {
            return !(left == right);
        }

        public ErrorCode(int id, string? name = null, string? message = null)
        {
            Id = id;
            Name = name;
            Message = message;
        }

        public override string ToString()
        {
            return Name ?? Id.ToString(CultureInfo.InvariantCulture);
        }

        public bool Equals(ErrorCode? other)
        {
            if(ReferenceEquals(other,null))
            {
                return false;
            }

            return Id == other.Id;
        }

        public override bool Equals(object? obj)
        {
            if (obj is ErrorCode eventCode)
            {
                return Equals(eventCode);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public static ErrorCode FromInt32(int code)
        {
            return new ErrorCode(code);
        }
    }
}
