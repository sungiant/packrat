// ┌────────────────────────────────────────────────────────────────────────┐ \\
// │ __________                __                   __                      │ \\
// │ \______   \_____    ____ |  | ______________ _/  |_                    │ \\
// │  |     ___/\__  \ _/ ___\|  |/ /\_  __ \__  \\   __\                   │ \\
// │  |    |     / __ \\  \___|    <  |  | \// __ \|  |                     │ \\
// │  |____|    (____  /\___  >__|_ \ |__|  (____  /__|                     │ \\
// │                 \/     \/     \/            \/      v1.0.0             │ \\
// │                                                                        │ \\
// │ A library for packing data into common graphical data formats.         │ \\
// │                                                                        │ \\
// ├────────────────────────────────────────────────────────────────────────┤ \\
// │ Copyright © 2012 - 2020                                                │ \\
// ├────────────────────────────────────────────────────────────────────────┤ \\
// │ Author: Ash Pook (https://github.com/sungiant)                         │ \\
// ├────────────────────────────────────────────────────────────────────────┤ \\
// │ Permission is hereby granted, free of charge, to any person obtaining  │ \\
// │ a copy of this software and associated documentation files (the        │ \\
// │ "Software"), to deal in the Software without restriction, including    │ \\
// │ without limitation the rights to use, copy, modify, merge, publish,    │ \\
// │ distribute, sublicense, and/or sellcopies of the Software, and to      │ \\
// │ permit persons to whom the Software is furnished to do so, subject to  │ \\
// │ the following conditions:                                              │ \\
// │                                                                        │ \\
// │ The above copyright notice and this permission notice shall be         │ \\
// │ included in all copies or substantial portions of the Software.        │ \\
// │                                                                        │ \\
// │ THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,        │ \\
// │ EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF     │ \\
// │ MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. │ \\
// │ IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY   │ \\
// │ CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,   │ \\
// │ TORT OR OTHERWISE, ARISING FROM,OUT OF OR IN CONNECTION WITH THE       │ \\
// │ SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.                 │ \\
// └────────────────────────────────────────────────────────────────────────┘ \\
namespace Packrat
{
    using System;
    using System.Runtime.InteropServices;

    public interface IPackedReal {
        void PackFrom (Single x);
        void UnpackTo (out Single x);
    }

    public interface IPackedReal2 {
        void PackFrom (Single x, Single y);
        void UnpackTo (out Single x, out Single y);
    }

    public interface IPackedReal3 {
        void PackFrom (Single x, Single y, Single z);
        void UnpackTo (out Single x, out Single y, out Single z);
    }

    public interface IPackedReal4 {
        void PackFrom (Single x, Single y, Single z, Single w);
        void UnpackTo (out Single x, out Single y, out Single z, out Single w);
    }

    public interface IPackedValue<T> {
        T PackedValue { get; set; }
    }

    // ────────────────────────────────────────────────────────────────────────────────────────────────────────────── //
    [StructLayout (LayoutKind.Sequential), Serializable]
    public struct Alpha_8
        : IPackedValue<Byte>, IEquatable<Alpha_8>, IPackedReal
    {
        public override String      ToString        () { return packedValue.ToString ("X2"); }
        public override Int32       GetHashCode     () { return this.packedValue.GetHashCode(); }
        public override Boolean     Equals          (Object obj) { return ((obj is Alpha_8) && this.Equals((Alpha_8)obj)); }
        public Boolean              Equals          (Alpha_8 other) { return this.packedValue.Equals (other.packedValue); }

        public Byte PackedValue { get { return this.packedValue; } set { this.packedValue = value; } }

        public Alpha_8 (Byte packedValue) { this.packedValue = packedValue; }

        public static Boolean operator == (Alpha_8 a, Alpha_8 b) { return  a.Equals(b); }
        public static Boolean operator != (Alpha_8 a, Alpha_8 b) { return !a.Equals(b); }

        public Alpha_8 (Single zRealAlpha) { Pack (zRealAlpha, out this.packedValue); }
        
        public void PackFrom (Single zRealAlpha) { Pack (zRealAlpha, out this.packedValue); }
        public void UnpackTo (out Single zRealAlpha) { Unpack (this.packedValue, out zRealAlpha); }

        public static Byte Pack (Single zRealAlpha) { Byte r; Pack (zRealAlpha, out r); return r; }
        public static Single Unpack (Byte zPackedAlpha) { Single r; Unpack (zPackedAlpha, out r); return r; }

        public static void Pack (Single zAlpha, out Byte zPackedAlpha) {
            if (zAlpha < 0f || zAlpha > 1f)
                throw new ArgumentException ("A component of the input source is not unsigned and normalised.");

            zPackedAlpha = (Byte)Utils.PackUnsignedNormalisedValue (255f, zAlpha);
        }

        public static void Unpack (Byte zPackedAlpha, out Single zAlpha) {
            zAlpha = Utils.UnpackUnsignedNormalisedValue (0xff, zPackedAlpha);

            if (zAlpha < 0f || zAlpha > 1f)
                throw new Exception ("A the input source doesn't yield an unsigned normalised output: " + zPackedAlpha);
        }

        Byte packedValue;
    }

    // ────────────────────────────────────────────────────────────────────────────────────────────────────────────── //
    [StructLayout (LayoutKind.Sequential), Serializable]
    public struct Bgr565
        : IPackedValue<UInt16>, IEquatable<Bgr565>, IPackedReal3
    {
        public override String      ToString        () { return packedValue.ToString ("X4"); }
        public override Int32       GetHashCode     () { return this.packedValue.GetHashCode(); }
        public override Boolean     Equals          (Object obj) { return ((obj is Bgr565) && this.Equals((Bgr565)obj)); }
        public Boolean              Equals          (Bgr565 other) { return this.packedValue.Equals (other.packedValue); }

        public UInt16 PackedValue { get { return this.packedValue; } set { this.packedValue = value; } }

        public Bgr565 (UInt16 packedValue) { this.packedValue = packedValue; }

        public static Boolean operator == (Bgr565 a, Bgr565 b) { return  a.Equals(b); }
        public static Boolean operator != (Bgr565 a, Bgr565 b) { return !a.Equals(b); }

        public Bgr565 (Single zB, Single zG, Single zR) { Pack (zB, zG, zR, out this.packedValue); }

        public void PackFrom (Single zB, Single zG, Single zR) { Pack (zB, zG, zR, out this.packedValue); }
        public void UnpackTo (out Single zB, out Single zG, out Single zR) { Unpack (this.packedValue, out zB, out zG, out zR); }

        public static UInt16 Pack (Single zB, Single zG, Single zR) { UInt16 r; Pack (zB, zG, zR, out r); return r; }

        public static void Pack (Single zB, Single zG, Single zR, out UInt16 zPackedBgr) {
            if (zR < 0f || zR > 1f || zG < 0f || zG > 1f || zB < 0f || zB > 1f)
                throw new ArgumentException ("A component of the input source is not unsigned and normalised.");

            UInt32 b = Utils.PackUnsignedNormalisedValue (31f, zB);
            UInt32 g = Utils.PackUnsignedNormalisedValue (63f, zG) << 5;
            UInt32 r = Utils.PackUnsignedNormalisedValue (31f, zR) << 11;

            zPackedBgr = (UInt16)((r | g) | b);
        }

        public static void Unpack (UInt16 zPackedBgr, out Single zB, out Single zG, out Single zR) {
            zB = Utils.UnpackUnsignedNormalisedValue (0x1f, zPackedBgr);
            zG = Utils.UnpackUnsignedNormalisedValue (0x3f, (UInt32)(zPackedBgr >> 5));
            zR = Utils.UnpackUnsignedNormalisedValue (0x1f, (UInt32)(zPackedBgr >> 11));

            if (zR < 0f || zR > 1f || zG < 0f || zG > 1f || zB < 0f || zB > 1f)
                throw new Exception ("A the input source doesn't yield an unsigned normalised output: " + zPackedBgr);
        }

        UInt16 packedValue;
    }

    // ────────────────────────────────────────────────────────────────────────────────────────────────────────────── //
    [StructLayout (LayoutKind.Sequential), Serializable]
    public struct Bgra16
        : IPackedValue<UInt16>, IEquatable<Bgra16>, IPackedReal4
    {
        public override String      ToString        () { return packedValue.ToString ("X4"); } 
        public override Int32       GetHashCode     () { return this.packedValue.GetHashCode(); }
        public override Boolean     Equals          (Object obj) { return ((obj is Bgra16) && this.Equals((Bgra16)obj)); }
        public Boolean              Equals          (Bgra16 other) { return this.packedValue.Equals (other.packedValue); }

        public UInt16 PackedValue { get { return this.packedValue; } set { this.packedValue = value; } }

        public Bgra16 (UInt16 packedValue) { this.packedValue = packedValue; }

        public static Boolean operator == (Bgra16 a, Bgra16 b) { return  a.Equals(b); }
        public static Boolean operator != (Bgra16 a, Bgra16 b) { return !a.Equals(b); }

        public Bgra16 (Single zB, Single zG, Single zR, Single zA) { Pack (zB, zG, zR, zA, out this.packedValue); }

        public void PackFrom (Single zB, Single zG, Single zR, Single zA) { Pack (zB, zG, zR, zA, out this.packedValue); }
        public void UnpackTo (out Single zB, out Single zG, out Single zR, out Single zA) { Unpack (this.packedValue, out zB, out zG, out zR, out zA); }

        public static UInt16 Pack (Single zB, Single zG, Single zR, Single zA) { UInt16 r; Pack (zB, zG, zR, zA, out r); return r; }

        public static void Pack (Single zB, Single zG, Single zR, Single zA, out UInt16 zPackedBgra) {
            if (zR < 0f || zR > 1f || zG < 0f || zG > 1f || zB < 0f || zB > 1f || zA < 0f || zA > 1f )
                throw new ArgumentException ("A component of the input source is not unsigned and normalised.");

            UInt32 b = Utils.PackUnsignedNormalisedValue (15f, zB);
            UInt32 g = Utils.PackUnsignedNormalisedValue (15f, zG) << 4;
            UInt32 r = Utils.PackUnsignedNormalisedValue (15f, zR) << 8;
            UInt32 a = Utils.PackUnsignedNormalisedValue (15f, zA) << 12;

            zPackedBgra = (UInt16)(((r | g) | b) | a);
        }

        public static void Unpack (UInt16 zPackedBgra, out Single zB, out Single zG, out Single zR, out Single zA) {
            zB = Utils.UnpackUnsignedNormalisedValue (15, zPackedBgra);
            zG = Utils.UnpackUnsignedNormalisedValue (15, (UInt32)(zPackedBgra >> 4));
            zR = Utils.UnpackUnsignedNormalisedValue (15, (UInt32)(zPackedBgra >> 8));
            zA = Utils.UnpackUnsignedNormalisedValue (15, (UInt32)(zPackedBgra >> 12));

            if (zR < 0f || zR > 1f || zG < 0f || zG > 1f || zB < 0f || zB > 1f || zA < 0f || zA > 1f )
                throw new Exception ("A the input source doesn't yield an unsigned normalised output: " + zPackedBgra);
        }

        UInt16 packedValue;
    }

    // ────────────────────────────────────────────────────────────────────────────────────────────────────────────── //
    [StructLayout (LayoutKind.Sequential), Serializable]
    public struct Bgra5551
        : IPackedValue<UInt16>, IEquatable<Bgra5551>, IPackedReal4
    {
        public override String      ToString        () { return packedValue.ToString ("X4"); }
        public override Int32       GetHashCode     () { return this.packedValue.GetHashCode(); }
        public override Boolean     Equals          (Object obj) { return ((obj is Bgra5551) && this.Equals((Bgra5551)obj)); }
        public Boolean              Equals          (Bgra5551 other) { return this.packedValue.Equals (other.packedValue); }

        public UInt16 PackedValue { get { return this.packedValue; } set { this.packedValue = value; } }

        public Bgra5551 (UInt16 packedValue) { this.packedValue = packedValue; }

        public static Boolean operator == (Bgra5551 a, Bgra5551 b) { return  a.Equals(b); }
        public static Boolean operator != (Bgra5551 a, Bgra5551 b) { return !a.Equals(b); }

        public Bgra5551 (Single zB, Single zG, Single zR, Single zA) { Pack (zB, zG, zR, zA, out this.packedValue); }

        public void PackFrom (Single zB, Single zG, Single zR, Single zA) { Pack (zB, zG, zR, zA, out this.packedValue); }
        public void UnpackTo (out Single zB, out Single zG, out Single zR, out Single zA) { Unpack (this.packedValue, out zB, out zG, out zR, out zA); }

        public static UInt16 Pack (Single zB, Single zG, Single zR, Single zA) { UInt16 r; Pack (zB, zG, zR, zA, out r); return r; }

        public static void Pack (Single zB, Single zG, Single zR, Single zA, out UInt16 zPackedBgra) {
            if (zR < 0f || zR > 1f || zG < 0f || zG > 1f || zB < 0f || zB > 1f || zA < 0f || zA > 1f )
                throw new ArgumentException ("A component of the input source is not unsigned and normalised.");

            UInt32 b = Utils.PackUnsignedNormalisedValue (31f, zB);
            UInt32 g = Utils.PackUnsignedNormalisedValue (31f, zG) << 5;
            UInt32 r = Utils.PackUnsignedNormalisedValue (31f, zR) << 10;
            UInt32 a = Utils.PackUnsignedNormalisedValue (1f, zA) << 15;

            zPackedBgra = (UInt16)(((r | g) | b) | a);
        }

        public static void Unpack (UInt16 zPackedBgra, out Single zB, out Single zG, out Single zR, out Single zA) {
            zB = Utils.UnpackUnsignedNormalisedValue (0x1f, zPackedBgra);
            zG = Utils.UnpackUnsignedNormalisedValue (0x1f, (UInt32)(zPackedBgra >> 5));
            zR = Utils.UnpackUnsignedNormalisedValue (0x1f, (UInt32)(zPackedBgra >> 10));
            zA = Utils.UnpackUnsignedNormalisedValue (1, (UInt32)(zPackedBgra >> 15));

            if (zR < 0f || zR > 1f || zG < 0f || zG > 1f || zB < 0f || zB > 1f || zA < 0f || zA > 1f)
                throw new Exception ("A the input source doesn't yield an unsigned normalised output: " + zPackedBgra);
        }

        UInt16 packedValue;
    }

    // ────────────────────────────────────────────────────────────────────────────────────────────────────────────── //
    [StructLayout (LayoutKind.Sequential), Serializable]
    public struct Byte4
        : IPackedValue<UInt32>, IEquatable<Byte4>
    {
        public override String      ToString        () { return packedValue.ToString ("X8"); }
        public override Int32       GetHashCode     () { return this.packedValue.GetHashCode(); }
        public override Boolean     Equals          (Object obj) { return ((obj is Byte4) && this.Equals((Byte4)obj)); }
        public Boolean              Equals          (Byte4 other) { return this.packedValue.Equals (other.packedValue); }

        public UInt32 PackedValue { get { return this.packedValue; } set { this.packedValue = value; } }

        public Byte4 (UInt32 packedValue) { this.packedValue = packedValue; }

        public static Boolean operator == (Byte4 a, Byte4 b) { return  a.Equals(b); }
        public static Boolean operator != (Byte4 a, Byte4 b) { return !a.Equals(b); }

        public Byte4 (Single zX, Single zY, Single zZ, Single zW) { Pack (zX, zY, zZ, zW, out this.packedValue); }

        public void PackFrom (Single zX, Single zY, Single zZ, Single zW) { Pack (zX, zY, zZ, zW, out this.packedValue); }
        public void UnpackTo (out Single zX, out Single zY, out Single zZ, out Single zW) { Unpack (this.packedValue, out zX, out zY, out zZ, out zW); }

        public static UInt32 Pack (Single zX, Single zY, Single zZ, Single zW) { UInt32 r; Pack (zX, zY, zZ, zW, out r); return r; }

        public static void Pack (Single zX, Single zY, Single zZ, Single zW, out UInt32 zPackedXyzw) {
            UInt32 y = Utils.PackUnsigned (255f, zX);
            UInt32 x = Utils.PackUnsigned (255f, zY) << 8;
            UInt32 z = Utils.PackUnsigned (255f, zZ) << 0x10;
            UInt32 w = Utils.PackUnsigned (255f, zW) << 0x18;

            zPackedXyzw = (UInt32)(((y | x) | z) | w);
        }

        public static void Unpack (UInt32 zPackedXyzw, out Single zX, out Single zY, out Single zZ, out Single zW) {
            zX = zPackedXyzw & 0xff;
            zY = (zPackedXyzw >> 8) & 0xff;
            zZ = (zPackedXyzw >> 0x10) & 0xff;
            zW = (zPackedXyzw >> 0x18) & 0xff;
        }

        UInt32 packedValue;
    }

    // ────────────────────────────────────────────────────────────────────────────────────────────────────────────── //
    [StructLayout (LayoutKind.Sequential), Serializable]
    public struct NormalisedByte2
        : IPackedValue<UInt16>, IEquatable<NormalisedByte2>, IPackedReal2
    {
        public override String      ToString        () { return packedValue.ToString ("X4"); }
        public override Int32       GetHashCode     () { return this.packedValue.GetHashCode(); }
        public override Boolean     Equals          (Object obj) { return ((obj is NormalisedByte2) && this.Equals((NormalisedByte2)obj)); }
        public Boolean              Equals          (NormalisedByte2 other) { return this.packedValue.Equals (other.packedValue); }

        public UInt16 PackedValue { get { return this.packedValue; } set { this.packedValue = value; } }

        public NormalisedByte2 (UInt16 packedValue) { this.packedValue = packedValue; }

        public static Boolean operator == (NormalisedByte2 a, NormalisedByte2 b) { return  a.Equals(b); }
        public static Boolean operator != (NormalisedByte2 a, NormalisedByte2 b) { return !a.Equals(b); }

        public NormalisedByte2 (Single zX, Single zY) { Pack (zX, zY, out this.packedValue); }

        public void PackFrom (Single zX, Single zY) { Pack (zX, zY, out this.packedValue); }
        public void UnpackTo (out Single zX, out Single zY) { Unpack (this.packedValue, out zX, out zY); }

        public static UInt16 Pack (Single zX, Single zY) { UInt16 r; Pack (zX, zY, out r); return r; }

        public static void Pack (Single zX, Single zY, out UInt16 zPackedXy) {
            if (zX < -1f || zX > 1f || zY < -1f || zY > 1f)
                throw new ArgumentException ("A component of the input source is not normalised.");

            UInt32 x = Utils.PackSignedNormalised (0xff, zX);
            UInt32 y = Utils.PackSignedNormalised (0xff, zY) << 8;

            zPackedXy = (UInt16)(x | y);
        }

        public static void Unpack (UInt16 zPackedXy, out Single zX, out Single zY) {
            zX = Utils.UnpackSignedNormalised (0xff, zPackedXy);
            zY = Utils.UnpackSignedNormalised (0xff, (UInt32) (zPackedXy >> 8));

            if (zX < -1f || zX > 1f || zY < -1f || zY > 1f)
                throw new Exception ("A the input source doesn't yield a normalised output: " + zPackedXy);
        }

        UInt16 packedValue;
    }

    // ────────────────────────────────────────────────────────────────────────────────────────────────────────────── //
    [StructLayout (LayoutKind.Sequential), Serializable]
    public struct NormalisedByte4
        : IPackedValue<UInt32>, IEquatable<NormalisedByte4>, IPackedReal4
    {
        public override String      ToString        () { return packedValue.ToString ("X8"); }
        public override Int32       GetHashCode     () { return this.packedValue.GetHashCode(); }
        public override Boolean     Equals          (Object obj) { return ((obj is NormalisedByte4) && this.Equals((NormalisedByte4)obj)); }
        public Boolean              Equals          (NormalisedByte4 other) { return this.packedValue.Equals (other.packedValue); }

        public UInt32 PackedValue { get { return this.packedValue; } set { this.packedValue = value; } }

        public NormalisedByte4 (UInt32 packedValue) { this.packedValue = packedValue; }

        public static Boolean operator == (NormalisedByte4 a, NormalisedByte4 b) { return  a.Equals(b); }
        public static Boolean operator != (NormalisedByte4 a, NormalisedByte4 b) { return !a.Equals(b); }

        public NormalisedByte4 (Single zX, Single zY, Single zZ, Single zW) { Pack (zX, zY, zZ, zW, out this.packedValue); }

        public void PackFrom (Single zX, Single zY, Single zZ, Single zW) { Pack (zX, zY, zZ, zW, out this.packedValue); }
        public void UnpackTo (out Single zX, out Single zY, out Single zZ, out Single zW) { Unpack (this.packedValue, out zX, out zY, out zZ, out zW); }

        public static UInt32 Pack (Single zX, Single zY, Single zZ, Single zW) { UInt32 r; Pack (zX, zY, zZ, zW, out r); return r; }

        public static void Pack (Single zX, Single zY, Single zZ, Single zW, out UInt32 zPackedXyzw) {
            if (zX < -1f || zX > 1f || zY < -1f || zY > 1f || zZ < -1f || zZ > 1f || zW < -1f || zW > 1f)
                throw new ArgumentException ("A component of the input source is not normalised.");

            UInt32 x = Utils.PackSignedNormalised (0xff, zX);
            UInt32 y = Utils.PackSignedNormalised (0xff, zY) << 8;
            UInt32 z = Utils.PackSignedNormalised (0xff, zZ) << 16;
            UInt32 w = Utils.PackSignedNormalised (0xff, zW) << 24;

            zPackedXyzw = (((x | y) | z) | w);
        }

        public static void Unpack (UInt32 zPackedXyzw, out Single zX, out Single zY, out Single zZ, out Single zW) {
            zX = Utils.UnpackSignedNormalised (0xff, zPackedXyzw);
            zY = Utils.UnpackSignedNormalised (0xff, (UInt32) (zPackedXyzw >> 8));
            zZ = Utils.UnpackSignedNormalised (0xff, (UInt32) (zPackedXyzw >> 16));
            zW = Utils.UnpackSignedNormalised (0xff, (UInt32) (zPackedXyzw >> 24));

            if (zX < -1f || zX > 1f || zY < -1f || zY > 1f || zZ < -1f || zZ > 1f || zW < -1f || zW > 1f)
                throw new Exception ("A the input source doesn't yield a normalised output: " + zPackedXyzw);
        }

        UInt32 packedValue;
    }

    // ────────────────────────────────────────────────────────────────────────────────────────────────────────────── //
    [StructLayout (LayoutKind.Sequential), Serializable]
    public struct NormalisedShort2
        : IPackedValue<UInt32>, IEquatable<NormalisedShort2>, IPackedReal2
    {
        public override String      ToString        () { return packedValue.ToString ("X8"); }
        public override Int32       GetHashCode     () { return this.packedValue.GetHashCode(); }
        public override Boolean     Equals          (Object obj) { return ((obj is NormalisedShort2) && this.Equals((NormalisedShort2)obj)); }
        public Boolean              Equals          (NormalisedShort2 other) { return this.packedValue.Equals (other.packedValue); }

        public UInt32 PackedValue { get { return this.packedValue; } set { this.packedValue = value; } }

        public NormalisedShort2 (UInt32 packedValue) { this.packedValue = packedValue; }

        public static Boolean operator == (NormalisedShort2 a, NormalisedShort2 b) { return  a.Equals(b); }
        public static Boolean operator != (NormalisedShort2 a, NormalisedShort2 b) { return !a.Equals(b); }

        public NormalisedShort2 (Single zX, Single zY) { Pack (zX, zY, out this.packedValue); }

        public void PackFrom (Single zX, Single zY) { Pack (zX, zY, out this.packedValue); }
        public void UnpackTo (out Single zX, out Single zY) { Unpack (this.packedValue, out zX, out zY); }

        public static UInt32 Pack (Single zX, Single zY) { UInt32 r; Pack (zX, zY, out r); return r; }

        public static void Pack (Single zX, Single zY, out UInt32 zPackedXy) {
            if (zX < -1f || zX > 1f || zY < -1f || zY > 1f)
                throw new ArgumentException ("A component of the input source is not normalised.");

            UInt32 x = Utils.PackSignedNormalised (0xffff, zX);
            UInt32 y = Utils.PackSignedNormalised (0xffff, zY) << 16;

            zPackedXy = (x | y);
        }

        public static void Unpack (UInt32 zPackedXy, out Single zX, out Single zY) {
            zX = Utils.UnpackSignedNormalised (0xffff, zPackedXy);
            zY = Utils.UnpackSignedNormalised (0xffff, (UInt32) (zPackedXy >> 16));

            if (zX < -1f || zX > 1f || zY < -1f || zY > 1f)
                throw new Exception ("A the input source doesn't yield a normalised output: " + zPackedXy);
        }

        UInt32 packedValue;
    }

    // ────────────────────────────────────────────────────────────────────────────────────────────────────────────── //
    [StructLayout (LayoutKind.Sequential), Serializable]
    public struct NormalisedShort4
        : IPackedValue<UInt64>, IEquatable<NormalisedShort4>, IPackedReal4
    {
        public override String      ToString        () { return packedValue.ToString ("X8"); }
        public override Int32       GetHashCode     () { return this.packedValue.GetHashCode(); }
        public override Boolean     Equals          (Object obj) { return ((obj is NormalisedShort4) && this.Equals((NormalisedShort4)obj)); }
        public Boolean              Equals          (NormalisedShort4 other) { return this.packedValue.Equals (other.packedValue); }

        public UInt64 PackedValue { get { return this.packedValue; } set { this.packedValue = value; } }

        public NormalisedShort4 (UInt64 packedValue) { this.packedValue = packedValue; }

        public static Boolean operator == (NormalisedShort4 a, NormalisedShort4 b) { return  a.Equals(b); }
        public static Boolean operator != (NormalisedShort4 a, NormalisedShort4 b) { return !a.Equals(b); }

        public NormalisedShort4 (Single zX, Single zY, Single zZ, Single zW) { Pack (zX, zY, zZ, zW, out this.packedValue); }

        public void PackFrom (Single zX, Single zY, Single zZ, Single zW) { Pack (zX, zY, zZ, zW, out this.packedValue); }
        public void UnpackTo (out Single zX, out Single zY, out Single zZ, out Single zW) { Unpack (this.packedValue, out zX, out zY, out zZ, out zW); }

        public static UInt64 Pack (Single zX, Single zY, Single zZ, Single zW) { UInt64 r; Pack (zX, zY, zZ, zW, out r); return r; }

        public static void Pack (Single zX, Single zY, Single zZ, Single zW, out UInt64 zPackedXyzw) {
            if (zX < -1f || zX > 1f || zY < -1f || zY > 1f || zZ < -1f || zZ > 1f || zW < -1f || zW > 1f )
                throw new ArgumentException ("A component of the input source is not normalised.");

            UInt64 x = (UInt64) Utils.PackSignedNormalised (0xffff, zX);
            UInt64 y = ((UInt64) Utils.PackSignedNormalised (0xffff, zY)) << 16;
            UInt64 z = ((UInt64) Utils.PackSignedNormalised (0xffff, zZ)) << 32;
            UInt64 w = ((UInt64) Utils.PackSignedNormalised (0xffff, zW)) << 48;

            zPackedXyzw = (((x | y) | z) | w);
        }

        public static void Unpack (UInt64 zPackedXyzw, out Single zX, out Single zY, out Single zZ, out Single zW) {
            zX = Utils.UnpackSignedNormalised (0xffff, (UInt32) zPackedXyzw);
            zY = Utils.UnpackSignedNormalised (0xffff, (UInt32) (zPackedXyzw >> 16));
            zZ = Utils.UnpackSignedNormalised (0xffff, (UInt32) (zPackedXyzw >> 32));
            zW = Utils.UnpackSignedNormalised (0xffff, (UInt32) (zPackedXyzw >> 48));

            if (zX < -1f || zX > 1f || zY < -1f || zY > 1f || zZ < -1f || zZ > 1f || zW < -1f || zW > 1f )
                throw new Exception ("A the input source doesn't yield a normalised output: " + zPackedXyzw);
        }

        UInt64 packedValue;
    }

    // ────────────────────────────────────────────────────────────────────────────────────────────────────────────── //
    [StructLayout (LayoutKind.Sequential), Serializable]
    public struct Rg32
        : IPackedValue<UInt32>, IEquatable<Rg32>, IPackedReal2
    {
        public override String      ToString        () { return packedValue.ToString ("X8"); }
        public override Int32       GetHashCode     () { return this.packedValue.GetHashCode(); }
        public override Boolean     Equals          (Object obj) { return ((obj is Rg32) && this.Equals((Rg32)obj)); }
        public Boolean              Equals          (Rg32 other) { return this.packedValue.Equals (other.packedValue); }

        public UInt32 PackedValue { get { return this.packedValue; } set { this.packedValue = value; } }

        public Rg32 (UInt32 packedValue) { this.packedValue = packedValue; }

        public static Boolean operator == (Rg32 a, Rg32 b) { return  a.Equals(b); }
        public static Boolean operator != (Rg32 a, Rg32 b) { return !a.Equals(b); }

        public Rg32 (Single zR, Single zG) { Pack (zR, zG, out this.packedValue); }

        public void PackFrom (Single zR, Single zG) { Pack (zR, zG, out this.packedValue); }
        public void UnpackTo (out Single zR, out Single zG) { Unpack (this.packedValue, out zR, out zG); }

        public static UInt32 Pack (Single zR, Single zG) { UInt32 r; Pack (zR, zG, out r); return r; }

        public static void Pack (Single zR, Single zG, out UInt32 zPackedRg) {
            if (zR < -1f || zR > 1f || zG < -1f || zG > 1f)
                throw new ArgumentException ("A component of the input source is not normalised.");

            UInt32 x = Utils.PackUnsignedNormalisedValue (0xffff, zR);
            UInt32 y = Utils.PackUnsignedNormalisedValue (0xffff, zG) << 16;

            zPackedRg = (x | y);
        }

        public static void Unpack (UInt32 zPackedRg, out Single zR, out Single zG) {
            zR = Utils.UnpackUnsignedNormalisedValue (0xffff, zPackedRg);
            zG = Utils.UnpackUnsignedNormalisedValue (0xffff, (UInt32) (zPackedRg >> 16));

            if (zR < -1f || zR > 1f || zG < -1f || zG > 1f)
                throw new Exception ("A the input source doesn't yield a normalised output: " + zPackedRg);
        }

        UInt32 packedValue;
    }

    // ────────────────────────────────────────────────────────────────────────────────────────────────────────────── //
    [StructLayout (LayoutKind.Sequential), Serializable]
    public partial struct Rgba32
        : IPackedValue<UInt32>, IEquatable<Rgba32>, IPackedReal4
    {
        public Byte R {
            get { return unchecked ((Byte)packedValue); }
            set { packedValue = (packedValue & 0xffffff00) | value; }
        }

        public Byte G {
            get { return unchecked ((Byte)(packedValue >> 8)); }
            set { packedValue = (packedValue & 0xffff00ff) | ((UInt32)(value << 8)); }
        }

        public Byte B {
            get { return unchecked ((Byte)(packedValue >> 0x10)); }
            set { packedValue = (packedValue & 0xff00ffff) | ((UInt32)(value << 0x10)); }
        }

        public Byte A {
            get { return unchecked ((Byte)(packedValue >> 0x18)); }
            set { packedValue = (packedValue & 0xffffff) | ((UInt32)(value << 0x18)); }
        }

        public override String      ToString        () { return String.Format ("{{R:{0} G:{1} B:{2} A:{3}}}", R, G, B, A); }
        public override Int32       GetHashCode     () { return this.packedValue.GetHashCode(); }
        public override Boolean     Equals          (Object obj) { return ((obj is Rgba32) && this.Equals((Rgba32)obj)); }
        public Boolean              Equals          (Rgba32 other) { return this.packedValue.Equals (other.packedValue); }

        public UInt32 PackedValue { get { return this.packedValue; } set { this.packedValue = value; } }

        public Rgba32 (UInt32 packedValue) { this.packedValue = packedValue; }

        public static Boolean operator == (Rgba32 a, Rgba32 b) { return  a.Equals(b); }
        public static Boolean operator != (Rgba32 a, Rgba32 b) { return !a.Equals(b); }

        public Rgba32 (Single zR, Single zG, Single zB, Single zA) { Pack (zR, zG, zB, zA, out this.packedValue); }

        public void PackFrom (Single zR, Single zG, Single zB, Single zA) { Pack (zR, zG, zB, zA, out this.packedValue); }
        public void UnpackTo (out Single zR, out Single zG, out Single zB, out Single zA) { Unpack (this.packedValue, out zR, out zG, out zB, out zA); }

        public static UInt32 Pack (Single zR, Single zG, Single zB, Single zA) { UInt32 r; Pack (zR, zG, zB, zA, out r); return r; }

        public static void Pack (Single zR, Single zG, Single zB, Single zA, out UInt32 zPackedRgba) {
            if (zR < 0f || zR > 1f || zG < 0f || zG > 1f || zB < 0f || zB > 1f || zA < 0f || zA > 1f )
                throw new ArgumentException ("A component of the input source is not unsigned and normalised.");

            UInt32 r = Utils.PackUnsignedNormalisedValue (0xff, zR);
            UInt32 g = Utils.PackUnsignedNormalisedValue (0xff, zG) << 8;
            UInt32 b = Utils.PackUnsignedNormalisedValue (0xff, zB) << 16;
            UInt32 a = Utils.PackUnsignedNormalisedValue (0xff, zA) << 24;

            zPackedRgba = ((r | g) | b) | a;
        }

        public static void Unpack (UInt32 zPackedRgba, out Single zR, out Single zG, out Single zB, out Single zA) {
            zR = Utils.UnpackUnsignedNormalisedValue (0xff, zPackedRgba);
            zG = Utils.UnpackUnsignedNormalisedValue (0xff, (UInt32)(zPackedRgba >> 8));
            zB = Utils.UnpackUnsignedNormalisedValue (0xff, (UInt32)(zPackedRgba >> 16));
            zA = Utils.UnpackUnsignedNormalisedValue (0xff, (UInt32)(zPackedRgba >> 24));

            if (zR < 0f || zR > 1f || zG < 0f || zG > 1f || zB < 0f || zB > 1f || zA < 0f || zA > 1f )
                throw new Exception ("A the input source doesn't yield an unsigned normalised output: " + zPackedRgba);
        }

        UInt32 packedValue;
    }

    // ────────────────────────────────────────────────────────────────────────────────────────────────────────────── //
    [StructLayout (LayoutKind.Sequential), Serializable]
    public struct Rgba64
        : IPackedValue<UInt64>, IEquatable<Rgba64>, IPackedReal4
    {
        public override String      ToString        () { return packedValue.ToString ("X8"); }
        public override Int32       GetHashCode     () { return this.packedValue.GetHashCode(); }
        public override Boolean     Equals          (Object obj) { return ((obj is Rgba64) && this.Equals((Rgba64)obj)); }
        public Boolean              Equals          (Rgba64 other) { return this.packedValue.Equals (other.packedValue); }

        public UInt64 PackedValue { get { return this.packedValue; } set { this.packedValue = value; } }

        public Rgba64 (UInt64 packedValue) { this.packedValue = packedValue; }

        public static Boolean operator == (Rgba64 a, Rgba64 b) { return  a.Equals(b); }
        public static Boolean operator != (Rgba64 a, Rgba64 b) { return !a.Equals(b); }

        public Rgba64 (Single zR, Single zG, Single zB, Single zA) { Pack (zR, zG, zB, zA, out this.packedValue); }

        public void PackFrom (Single zR, Single zG, Single zB, Single zA) { Pack (zR, zG, zB, zA, out this.packedValue); }
        public void UnpackTo (out Single zR, out Single zG, out Single zB, out Single zA) { Unpack (this.packedValue, out zR, out zG, out zB, out zA); }

        public static UInt64 Pack (Single zR, Single zG, Single zB, Single zA) { UInt64 r; Pack (zR, zG, zB, zA, out r); return r; }

        public static void Pack (Single zR, Single zG, Single zB, Single zA, out UInt64 zPackedRgba) {
            if (zR < 0f || zR > 1f || zG < 0f || zG > 1f || zB < 0f || zB > 1f || zA < 0f || zA > 1f)
                throw new ArgumentException ("A component of the input source is not unsigned and normalised.");

            UInt64 r = (UInt64) Utils.PackUnsignedNormalisedValue (0xffff, zR);
            UInt64 g = ((UInt64) Utils.PackUnsignedNormalisedValue (0xffff, zG)) << 16;
            UInt64 b = ((UInt64) Utils.PackUnsignedNormalisedValue (0xffff, zB)) << 32;
            UInt64 a = ((UInt64) Utils.PackUnsignedNormalisedValue (0xffff, zA)) << 48;
            
            zPackedRgba = (((r | g) | b) | a);
        }

        public static void Unpack (UInt64 zPackedRgba, out Single zR, out Single zG, out Single zB, out Single zA) {
            zR = Utils.UnpackUnsignedNormalisedValue (0xffff, (UInt32) zPackedRgba);
            zG = Utils.UnpackUnsignedNormalisedValue (0xffff, (UInt32) (zPackedRgba >> 16));
            zB = Utils.UnpackUnsignedNormalisedValue (0xffff, (UInt32) (zPackedRgba >> 32));
            zA = Utils.UnpackUnsignedNormalisedValue (0xffff, (UInt32) (zPackedRgba >> 48));

            if (zR < 0f || zR > 1f || zG < 0f || zG > 1f || zB < 0f || zB > 1f || zA < 0f || zA > 1f)
                throw new Exception ("A the input source doesn't yield a unsigned normalised output: " + zPackedRgba);
        }

        UInt64 packedValue;
    }

    // ────────────────────────────────────────────────────────────────────────────────────────────────────────────── //
    [StructLayout (LayoutKind.Sequential), Serializable]
    public struct Rgba1010102
        : IPackedValue<UInt32>, IEquatable<Rgba1010102>, IPackedReal4
    {
        public override String      ToString        () { return packedValue.ToString ("X8"); }
        public override Int32       GetHashCode     () { return this.packedValue.GetHashCode(); }
        public override Boolean     Equals          (Object obj) { return ((obj is Rgba1010102) && this.Equals((Rgba1010102)obj)); }
        public Boolean              Equals          (Rgba1010102 other) { return this.packedValue.Equals (other.packedValue); }

        public UInt32 PackedValue { get { return this.packedValue; } set { this.packedValue = value; } }

        public Rgba1010102 (UInt32 packedValue) { this.packedValue = packedValue; }

        public static Boolean operator == (Rgba1010102 a, Rgba1010102 b) { return  a.Equals(b); }
        public static Boolean operator != (Rgba1010102 a, Rgba1010102 b) { return !a.Equals(b); }

        public Rgba1010102 (Single zR, Single zG, Single zB, Single zA) { Pack (zR, zG, zB, zA, out this.packedValue); }

        public void PackFrom (Single zR, Single zG, Single zB, Single zA) { Pack (zR, zG, zB, zA, out this.packedValue); }
        public void UnpackTo (out Single zR, out Single zG, out Single zB, out Single zA) { Unpack (this.packedValue, out zR, out zG, out zB, out zA); }

        public static UInt32 Pack (Single zR, Single zG, Single zB, Single zA) { UInt32 r; Pack (zR, zG, zB, zA, out r); return r; }

        public static void Pack (Single zR, Single zG, Single zB, Single zA, out UInt32 zPackedRgba) {
            if (zR < 0f || zR > 1f || zG < 0f || zG > 1f || zB < 0f || zB > 1f || zA < 0f || zA > 1f)
                throw new ArgumentException ("A component of the input source is not unsigned and normalised.");

            UInt32 r = Utils.PackUnsignedNormalisedValue (0xffff, zR);
            UInt32 g = Utils.PackUnsignedNormalisedValue (0xffff, zG) << 10;
            UInt32 b = Utils.PackUnsignedNormalisedValue (0xffff, zB) << 20;
            UInt32 a = Utils.PackUnsignedNormalisedValue (0xffff, zA) << 30;

            zPackedRgba = ((r | g) | b) | a;
        }

        public static void Unpack (UInt32 zPackedRgba, out Single zR, out Single zG, out Single zB, out Single zA) {
            zR = Utils.UnpackUnsignedNormalisedValue (0xffff, zPackedRgba);
            zG = Utils.UnpackUnsignedNormalisedValue (0xffff, (UInt32)(zPackedRgba >> 10));
            zB = Utils.UnpackUnsignedNormalisedValue (0xffff, (UInt32)(zPackedRgba >> 20));
            zA = Utils.UnpackUnsignedNormalisedValue (0xffff, (UInt32)(zPackedRgba >> 30));

            if (zR < 0f || zR > 1f || zG < 0f || zG > 1f || zB < 0f || zB > 1f || zA < 0f || zA > 1f)
                throw new Exception ("A the input source doesn't yield an unsigned normalised output: " + zPackedRgba);
        }

        UInt32 packedValue;
    }

    // ────────────────────────────────────────────────────────────────────────────────────────────────────────────── //
    [StructLayout (LayoutKind.Sequential), Serializable]
    public struct Short2
        : IPackedValue<UInt32>, IEquatable<Short2>, IPackedReal2
    {
        public override String      ToString        () { return packedValue.ToString ("X8"); }
        public override Int32       GetHashCode     () { return this.packedValue.GetHashCode(); }
        public override Boolean     Equals          (Object obj) { return ((obj is Short2) && this.Equals((Short2)obj)); }
        public Boolean              Equals          (Short2 other) { return this.packedValue.Equals (other.packedValue); }

        public UInt32 PackedValue { get { return this.packedValue; } set { this.packedValue = value; } }

        public Short2 (UInt32 packedValue) { this.packedValue = packedValue; }

        public static Boolean operator == (Short2 a, Short2 b) { return  a.Equals(b); }
        public static Boolean operator != (Short2 a, Short2 b) { return !a.Equals(b); }

        public Short2 (Single zX, Single zY) { Pack (zX, zY, out this.packedValue); }

        public void PackFrom (Single zX, Single zY) { Pack (zX, zY, out this.packedValue); }
        public void UnpackTo (out Single zX, out Single zY) { Unpack (this.packedValue, out zX, out zY); }

        public static UInt32 Pack (Single zX, Single zY) { UInt32 r; Pack (zX, zY, out r); return r; }

        public static void Pack (Single zX, Single zY, out UInt32 zPackedXy) {
            UInt32 x = Utils.PackSigned (0xffff, zX);
            UInt32 y = Utils.PackSigned (0xffff, zY) << 16;

            zPackedXy = (x | y);
        }

        public static void Unpack (UInt32 zPackedXy, out Single zX, out Single zY) {
            zX = (Int16) zPackedXy;
            zY = (Int16) (zPackedXy >> 16);
        }

        UInt32 packedValue;
    }

    // ────────────────────────────────────────────────────────────────────────────────────────────────────────────── //
    [StructLayout (LayoutKind.Sequential), Serializable]
    public struct Short4
        : IPackedValue<UInt64>, IEquatable<Short4>, IPackedReal4
    {
        public override String      ToString        () { return packedValue.ToString ("X8"); }
        public override Int32       GetHashCode     () { return this.packedValue.GetHashCode(); }
        public override Boolean     Equals          (Object obj) { return ((obj is Short4) && this.Equals((Short4)obj)); }
        public Boolean              Equals          (Short4 other) { return this.packedValue.Equals (other.packedValue); }

        public UInt64 PackedValue { get { return this.packedValue; } set { this.packedValue = value; } }

        public Short4 (UInt64 packedValue) { this.packedValue = packedValue; }

        public static Boolean operator == (Short4 a, Short4 b) { return  a.Equals(b); }
        public static Boolean operator != (Short4 a, Short4 b) { return !a.Equals(b); }

        public Short4 (Single zX, Single zY, Single zZ, Single zW) { Pack (zX, zY, zZ, zW, out this.packedValue); }

        public void PackFrom (Single zX, Single zY, Single zZ, Single zW) { Pack (zX, zY, zZ, zW, out this.packedValue); }
        public void UnpackTo (out Single zX, out Single zY, out Single zZ, out Single zW) { Unpack (this.packedValue, out zX, out zY, out zZ, out zW); }

        public static UInt64 Pack (Single zX, Single zY, Single zZ, Single zW) { UInt64 r; Pack (zX, zY, zZ, zW, out r); return r; }

        public static void Pack (Single zX, Single zY, Single zZ, Single zW, out UInt64 zPackedXyzw) {
            UInt64 x = (UInt64) Utils.PackSigned (0xffff, zX);
            UInt64 y = ((UInt64) Utils.PackSigned (0xffff, zY)) << 16;
            UInt64 z = ((UInt64) Utils.PackSigned (0xffff, zZ)) << 32;
            UInt64 w = ((UInt64) Utils.PackSigned (0xffff, zW)) << 48;

            zPackedXyzw = (((x | y) | z) | w);
        }

        public static void Unpack (UInt64 zPackedXyzw, out Single zX, out Single zY, out Single zZ, out Single zW) {
            zX = ((Int16) zPackedXyzw);
            zY = ((Int16) (zPackedXyzw >> 16));
            zZ = ((Int16) (zPackedXyzw >> 32));
            zW = ((Int16) (zPackedXyzw >> 48));
        }

        UInt64 packedValue;
    }

    // ────────────────────────────────────────────────────────────────────────────────────────────────────────────── //
    internal static class Utils {
        static Double ClampAndRound (Single value, Single min, Single max) {
            if (Single.IsNaN (value))
                return 0.0;

            if (Single.IsInfinity (value))
                return (Single.IsNegativeInfinity (value) ? ((Double)min) : ((Double)max));

            if (value < min)
                return (Double)min;

            if (value > max)
                return (Double)max;

            return Math.Round ((Double) value);
        }

        internal static UInt32 PackSigned (UInt32 bitmask, Single value) {
            Single max = bitmask >> 1;
            Single min = -max - 1f;
            return (((UInt32)((Int32)ClampAndRound (value, min, max))) & bitmask);
        }

        internal static UInt32 PackUnsigned (Single bitmask, Single value) {
            return (UInt32)ClampAndRound (value, 0f, bitmask);
        }

        internal static UInt32 PackSignedNormalised (UInt32 bitmask, Single value) {
            if (value > 1f || value < 0f)
                throw new ArgumentException ("Input value must be normalised.");

            Single max = bitmask >> 1;
            value *= max;
            UInt32 result = (((UInt32)((Int32)ClampAndRound (value, -max, max))) & bitmask);
            return result;
        }

        internal static Single UnpackSignedNormalised (UInt32 bitmask, UInt32 value) {
            UInt32 x = (UInt32)((bitmask + 1) >> 1);

            if ((value & x) != 0) {
                if ((value & bitmask) == x) return -1f;
                value |= ~bitmask;
            }
            else { value &= bitmask; }

            Single result = ((Single) value) / (bitmask >> 1);

            if (result > 1f || result < 0f)
                throw new ArgumentException ("Input value does not yield a normalised result.");

            return result;
        }

        internal static UInt32 PackUnsignedNormalisedValue (Single bitmask, Single value) {
            if (value > 1f || value < 0f)
                throw new ArgumentException ("Input value must be normalised.");

            value *= bitmask;
            UInt32 result = (UInt32)ClampAndRound (value, 0f, bitmask);
            return result;
        }

        internal static Single UnpackUnsignedNormalisedValue (UInt32 bitmask, UInt32 value) {
            value &= bitmask;
            Single result = (((Single)value) / ((Single)bitmask));

            if (result > 1f || result < 0f)
                throw new ArgumentException ("Input value does not yield a normalised result.");

            return result;
        }
    }

}
