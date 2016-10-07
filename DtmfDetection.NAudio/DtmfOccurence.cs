﻿namespace DtmfDetection.NAudio
{
    using System;

    public class DtmfOccurence : IEquatable<DtmfOccurence>
    {
        public DtmfOccurence(DtmfTone dtmfTone, int channel, TimeSpan position, TimeSpan duration)
        {
            DtmfTone = dtmfTone;
            Channel = channel;
            Position = position;
            Duration = duration;
        }

        public DtmfTone DtmfTone { get; }

        public int Channel { get; }

        public TimeSpan Position { get; }

        public TimeSpan Duration { get; }

        public override string ToString() => $"{DtmfTone} ({Channel}) @ {Position} for {(int)Duration.TotalMilliseconds} ms";

        #region Comparison implementations

        public override bool Equals(object obj) => !ReferenceEquals(obj, null) && Equals(obj as DtmfOccurence);

        public bool Equals(DtmfOccurence other)
        {
            if (ReferenceEquals(other, null))
                return false;

            return DtmfTone == other.DtmfTone
                && Position == other.Position
                && Duration == other.Duration;
        }

        public override int GetHashCode() => new { DtmfTone, Position, Duration }.GetHashCode();

        public static bool operator ==(DtmfOccurence a, DtmfOccurence b) => ReferenceEquals(a, null) ? ReferenceEquals(b, null) : a.Equals(b);

        public static bool operator !=(DtmfOccurence a, DtmfOccurence b) => !(a == b);

        #endregion
    }
}