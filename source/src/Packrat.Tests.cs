// ┌────────────────────────────────────────────────────────────────────────┐ \\
// │ __________                __                   __                      │ \\
// │ \______   \_____    ____ |  | ______________ _/  |_                    │ \\
// │  |     ___/\__  \ _/ ___\|  |/ /\_  __ \__  \\   __\                   │ \\
// │  |    |     / __ \\  \___|    <  |  | \// __ \|  |                     │ \\
// │  |____|    (____  /\___  >__|_ \ |__|  (____  /__|                     │ \\
// │                 \/     \/     \/            \/                         │ \\
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
namespace Packrat.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    static class Settings { internal const UInt32 NumTests = 10000; }

    // Tests the Alpha_8 packed data type.
    [TestFixture]
    public class Alpha_8Tests
    {
        // Iterates over every possible Alpha_8 value and makes sure that
        // unpacking them and then re-packing that result yields the 
        // original packed value.
        [Test]
        public void TestAllPossibleValues_i () {   
            Byte packed = Byte.MinValue;
            while (packed < Byte.MaxValue) {
                ++packed;
                var packedObj = new Alpha_8 ();
                packedObj.PackedValue = packed;
                Single unpacked;
                packedObj.UnpackTo (out unpacked);
                var newPackedObj = new Alpha_8 (unpacked);
                Assert.That (newPackedObj.PackedValue, Is.EqualTo (packed));
            }
        }

        // For a given example, this test ensures that the ToString function
        // yields the expected string.
        [Test]
        public void TestMemberFn_ToString_i () {
            var testCase = new Alpha_8 ();
            testCase.PackFrom (0.656f);
            String s = testCase.ToString ();
            Assert.That (s, Is.EqualTo ("A7"));
        }

        // Makes sure that the hashing function is good by testing 
        // all scenarios and ensuring that there are no collisions.
        [Test]
        public void TestMemberFn_GetHashCode_i () {
            HashSet<Int32> hs = new HashSet<Int32>();
            Byte packed = Byte.MinValue;
            while (packed < Byte.MaxValue) {
                ++packed;
                var packedObj = new Alpha_8 ();
                packedObj.PackedValue = packed;
                Int32 hc = packedObj.GetHashCode ();
                Assert.That (!hs.Contains (hc));
                hs.Add (hc);
            }
        }
    }

    // ────────────────────────────────────────────────────────────────────────────────────────────────────────────── //
    // Tests the Bgr565 packed data type.
    [TestFixture]
    public class Bgr565Tests
    {
        // Iterates over every possible Bgr565 value and makes sure that
        // unpacking them and then re-packing that result yields the
        // original packed value.
        [Test]
        public void TestAllPossibleValues_i () {
            UInt16 packed = UInt16.MinValue;
            while (packed < UInt16.MaxValue) {
                ++packed;
                var packedObj = new Bgr565 ();
                packedObj.PackedValue = packed;
                Single realB, realG, realR = 0f;
                packedObj.UnpackTo (out realB, out realG, out realR);
                var newPackedObj = new Bgr565 (realB, realG, realR);
                Assert.That (newPackedObj.PackedValue, Is.EqualTo (packed));
            }
        }

        // For a given example, this test ensures that the ToString function
        // yields the expected string.
        [Test]
        public void TestMemberFn_ToString_i () {
            var testCase = new Bgr565 ();
            testCase.PackFrom (0.861f, 0.125f, 0.656f);
            String s = testCase.ToString ();
            Assert.That (s, Is.EqualTo ("A11B"));
        }

        // Makes sure that the hashing function is good by testing
        // all scenarios and ensuring that there are no collisions.
        [Test]
        public void TestMemberFn_GetHashCode_i () {
            HashSet<Int32> hs = new HashSet<Int32>();
            UInt16 packed = UInt16.MinValue;
            while (packed < UInt16.MaxValue) {
                ++packed;
                var packedObj = new Bgr565 ();
                packedObj.PackedValue = packed;
                Int32 hc = packedObj.GetHashCode ();
                Assert.That (!hs.Contains (hc));
                hs.Add (hc);
            }
        }
    }

    // ────────────────────────────────────────────────────────────────────────────────────────────────────────────── //
    // Tests the Bgra16 packed data type.
    [TestFixture]
    public class Bgra16Tests
    {
        // Iterates over every possible Bgra16 value and makes sure that
        // unpacking them and then re-packing that result yields the
        // original packed value.
        [Test]
        public void TestAllPossibleValues_i () {
            UInt16 packed = UInt16.MinValue;
            while (packed < UInt16.MaxValue) {
                ++packed;
                var packedObj = new Bgra16 ();
                packedObj.PackedValue = packed;
                Single realB, realG, realR, realA = 0f;
                packedObj.UnpackTo (out realB, out realG, out realR, out realA);
                var newPackedObj = new Bgra16 (realB, realG, realR, realA);
                Assert.That (newPackedObj.PackedValue, Is.EqualTo (packed));
            }
        }

        // For a given example, this test ensures that the ToString function
        // yields the expected string.
        [Test]
        public void TestMemberFn_ToString_i () {
            var testCase = new Bgra16 ();
            testCase.PackFrom (0.222f, 0.125f, 0.656f, 0.861f);
            String s = testCase.ToString ();
            Assert.That (s, Is.EqualTo ("DA23"));
        }

        // Makes sure that the hashing function is good by testing
        // all scenarios and ensuring that there are no collisions.
        [Test]
        public void TestMemberFn_GetHashCode_i () {
            HashSet<Int32> hs = new HashSet<Int32>();
            UInt16 packed = UInt16.MinValue;
            while (packed < UInt16.MaxValue) {
                ++packed;
                var packedObj = new Bgra16 ();
                packedObj.PackedValue = packed;
                Int32 hc = packedObj.GetHashCode ();
                Assert.That (!hs.Contains (hc));
                hs.Add (hc);
            }
        }
    }

    // ────────────────────────────────────────────────────────────────────────────────────────────────────────────── //
    // Tests the Bgra5551 packed data type.
    [TestFixture]
    public class Bgra5551Tests
    {
        // Iterates over every possible Bgra5551 value and makes sure that
        // unpacking them and then re-packing that result yields the
        // original packed value.
        [Test]
        public void TestAllPossibleValues_i () {
            UInt16 packed = UInt16.MinValue;
            while (packed < UInt16.MaxValue) {
                ++packed;
                var packedObj = new Bgra5551 ();
                packedObj.PackedValue = packed;
                Single realB, realG, realR, realA = 0f;
                packedObj.UnpackTo (out realB, out realG, out realR, out realA);
                var newPackedObj = new Bgra5551 (realB, realG, realR, realA);
                Assert.That (newPackedObj.PackedValue, Is.EqualTo (packed));
            }
        }

        // For a given example, this test ensures that the ToString function
        // yields the expected string.
        [Test]
        public void TestMemberFn_ToString_i () {
            var testCase = new Bgra5551 ();
            testCase.PackFrom (0.222f, 0.125f, 0.656f, 0.861f);
            String s = testCase.ToString ();
            Assert.That (s, Is.EqualTo ("D087"));
        }

        // Makes sure that the hashing function is good by testing
        // all scenarios and ensuring that there are no collisions.
        [Test]
        public void TestMemberFn_GetHashCode_i () {
            HashSet<Int32> hs = new HashSet<Int32>();
            UInt16 packed = UInt16.MinValue;
            while (packed < UInt16.MaxValue) {
                ++packed;
                var packedObj = new Bgra5551 ();
                packedObj.PackedValue = packed;
                Int32 hc = packedObj.GetHashCode ();
                Assert.That (!hs.Contains (hc));
                hs.Add (hc);
            }
        }
    }
    // ────────────────────────────────────────────────────────────────────────────────────────────────────────────── //
    // Tests the Byte4 packed data type.
    [TestFixture]
    public class Byte4Tests
    {
        // Iterates over a random selection of values within the range of
        // possible Byte4 values and makes sure that unpacking them and
        // then re-packing that result yields the original packed value.
        [Test]
        public void TestRandomValues_i () {
            var rand = new System.Random ();
            var buff = new Byte[4];

            for (Int32 i = 0; i < Settings.NumTests; ++i) {
                rand.NextBytes (buff);
                UInt32 packed = BitConverter.ToUInt32 (buff, 0);
                var packedObj = new Byte4 ();
                packedObj.PackedValue = packed;
                Single realX, realY, realZ, realW = 0f;
                packedObj.UnpackTo (out realX, out realY, out realZ, out realW);
                var newPackedObj = new Byte4 (realX, realY, realZ, realW);
                Assert.That (newPackedObj.PackedValue, Is.EqualTo (packed));
            }
        }

        // For a given example, this test ensures that the ToString function
        // yields the expected string.
        [Test]
        public void TestMemberFn_ToString_i () {
            var testCase = new Byte4 ();
            testCase.PackFrom (0.656f, 0.125f, 0.222f, 0.861f);
            String s = testCase.ToString ();
            Assert.That (s, Is.EqualTo ("01000001"));
        }

        // Makes sure that the hashing function is good by testing
        // random scenarios and ensuring that there are no more than a
        // reasonable number of collisions.
        [Test]
        public void TestMemberFn_GetHashCode_i () {
            HashSet<Int32> hs = new HashSet<Int32>();
            var rand = new System.Random ();
            var buff = new Byte[4];
            UInt32 collisions = 0;
            for (Int32 i = 0; i < Settings.NumTests; ++i) {
                rand.NextBytes (buff);
                BitConverter.ToUInt32 (buff, 0);
                UInt32 packed = BitConverter.ToUInt32 (buff, 0);
                var packedObj = new Byte4 ();
                packedObj.PackedValue = packed;
                Int32 hc = packedObj.GetHashCode ();
                if (hs.Contains (hc)) ++collisions;
                hs.Add (hc);
            }
            Assert.That (collisions, Is.LessThan (10));
        }
    }

    // ────────────────────────────────────────────────────────────────────────────────────────────────────────────── //
    // Tests the NormalisedByte2 packed data type.
    [TestFixture]
    public class NormalisedByte2Tests
    {
        // Iterates over every possible NormalisedByte2 value and makes sure that
        // unpacking them and then re-packing that result yields the
        // original packed value.
        [Test]
        public void TestAllPossibleValues_i () {
            UInt16 packed = UInt16.MinValue;
            while (packed < UInt16.MaxValue) {
                ++packed;
                // Cannot guarantee that this packed value is valid.
                try {
                    var packedObj = new NormalisedByte2 ();
                    packedObj.PackedValue = packed;
                    Single realX, realY = 0f;
                    packedObj.UnpackTo (out realX, out realY);
                    var newPackedObj = new NormalisedByte2 (realX, realY);
                    Assert.That (newPackedObj.PackedValue, Is.EqualTo (packedObj.PackedValue));
                }
                catch (ArgumentException) {
                    continue;
                }
            }
        }

        // For a given example, this test ensures that the ToString function
        // yields the expected string.
        [Test]
        public void TestMemberFn_ToString_i () {
            var testCase = new NormalisedByte2 ();
            testCase.PackFrom (0.222f, 0.861f);
            String s = testCase.ToString ();
            Assert.That (s, Is.EqualTo ("6D1C"));
        }

        // Makes sure that the hashing function is good by testing
        // all scenarios and ensuring that there are no collisions.
        [Test]
        public void TestMemberFn_GetHashCode_i () {
            HashSet<Int32> hs = new HashSet<Int32>();
            UInt16 packed = UInt16.MinValue;
            while (packed < UInt16.MaxValue) {
                ++packed;
                var packedObj = new NormalisedByte2 ();
                packedObj.PackedValue = packed;
                Int32 hc = packedObj.GetHashCode ();
                Assert.That (!hs.Contains (hc));
                hs.Add (hc);
            }
        }
    }

    // ────────────────────────────────────────────────────────────────────────────────────────────────────────────── //
    // Tests the NormalisedByte4 packed data type.
    [TestFixture]
    public class NormalisedByte4Tests
    {
        // Iterates over a random selection of values within the range of
        // possible NormalisedByte4 values and makes sure that unpacking them and
        // then re-packing that result yields the original packed value.
        [Test]
        public void TestRandomValues_i ()
        {
            var rand = new System.Random ();
            var buff = new Byte[4];

            for (Int32 i = 0; i < Settings.NumTests; ++i) {
                rand.NextBytes (buff);
                UInt32 packed = BitConverter.ToUInt32 (buff, 0);

                // Cannot guarantee that this packed value is valid.
                try {
                    var packedObj = new NormalisedByte4 ();
                    packedObj.PackedValue = packed;
                    Single realX, realY, realZ, realW = 0f;
                    packedObj.UnpackTo (out realX, out realY, out realZ, out realW);
                    var newPackedObj = new NormalisedByte4 (realX, realY, realZ, realW);
                    Assert.That (newPackedObj.PackedValue, Is.EqualTo (packed));
                }
                catch (ArgumentException) {
                    continue;
                }
            }
        }

        // For a given example, this test ensures that the ToString function
        // yields the expected string.
        [Test]
        public void TestMemberFn_ToString_i ()
        {
            var testCase = new NormalisedByte4 ();
            testCase.PackFrom (0.656f, 0.125f, 0.222f, 0.861f);
            String s = testCase.ToString ();
            Assert.That (s, Is.EqualTo ("6D1C1053"));
        }

        // Makes sure that the hashing function is good by testing
        // random scenarios and ensuring that there are no more than a
        // reasonable number of collisions.
        [Test]
        public void TestMemberFn_GetHashCode_i () {
            HashSet<Int32> hs = new HashSet<Int32>();
            var rand = new System.Random ();
            var buff = new Byte[4];
            UInt32 collisions = 0;
            for (Int32 i = 0; i < Settings.NumTests; ++i) {
                rand.NextBytes (buff);
                UInt32 packed = BitConverter.ToUInt32 (buff, 0);
                var packedObj = new NormalisedByte4 ();
                packedObj.PackedValue = packed;
                Int32 hc = packedObj.GetHashCode ();
                if (hs.Contains (hc)) ++collisions;
                hs.Add (hc);
            }
            Assert.That (collisions, Is.LessThan (10));
        }
    }

    // ────────────────────────────────────────────────────────────────────────────────────────────────────────────── //
    // Tests the NormalisedShort2 packed data type.
    [TestFixture]
    public class NormalisedShort2Tests
    {
        // Iterates over a random selection of values within the range of
        // possible NormalisedShort2 values and makes sure that unpacking them and
        // then re-packing that result yields the original packed value.
        [Test]
        public void TestRandomValues_i () {
            var rand = new System.Random ();
            var buff = new Byte[4];

            for (Int32 i = 0; i < Settings.NumTests; ++i) {
                rand.NextBytes (buff);
                UInt32 packed = BitConverter.ToUInt32 (buff, 0);

                // Cannot guarantee that this packed value is valid.
                try {
                    var packedObj = new NormalisedShort2 ();
                    packedObj.PackedValue = packed;
                    Single realX, realY = 0f;
                    packedObj.UnpackTo (out realX, out realY);
                    var newPackedObj = new NormalisedShort2 (realX, realY);
                    Assert.That (newPackedObj.PackedValue, Is.EqualTo (packed));
                }
                catch (ArgumentException) {
                    continue;
                }
            }
        }

        // For a given example, this test ensures that the ToString function
        // yields the expected string.
        [Test]
        public void TestMemberFn_ToString_i () {
            var testCase = new NormalisedShort2 ();
            testCase.PackFrom (0.656f, 0.861f);
            String s = testCase.ToString ();
            Assert.That (s, Is.EqualTo ("6E3453F7"));
        }

        // Makes sure that the hashing function is good by testing
        // random scenarios and ensuring that there are no more than a
        // reasonable number of collisions.
        [Test]
        public void TestMemberFn_GetHashCode_i () {
            HashSet<Int32> hs = new HashSet<Int32>();
            var rand = new System.Random ();
            var buff = new Byte[4];
            UInt32 collisions = 0;
            for (Int32 i = 0; i < Settings.NumTests; ++i) {
                rand.NextBytes (buff);
                UInt32 packed = BitConverter.ToUInt32 (buff, 0);
                var packedObj = new NormalisedShort2 ();
                packedObj.PackedValue = packed;
                Int32 hc = packedObj.GetHashCode ();
                if (hs.Contains (hc)) ++collisions;
                hs.Add (hc);
            }
            Assert.That (collisions, Is.LessThan (10));
        }
    }

    // ────────────────────────────────────────────────────────────────────────────────────────────────────────────── //
    // Tests the NormalisedShort4 packed data type.
    [TestFixture]
    public class NormalisedShort4Tests
    {
        // Iterates over a random selection of values within the range of
        // possible NormalisedShort4 values and makes sure that unpacking them and
        // then re-packing that result yields the original packed value.
        [Test]
        public void TestRandomValues_i () {
            var rand = new System.Random ();
            var buff = new Byte[8];

            for (Int32 i = 0; i < Settings.NumTests; ++i) {
                rand.NextBytes (buff);
                UInt64 packed = BitConverter.ToUInt64 (buff, 0);

                // Cannot guarantee that this packed value is valid.
                try {
                    var packedObj = new NormalisedShort4 ();
                    packedObj.PackedValue = packed;
                    Single realX, realY, realZ, realW = 0f;
                    packedObj.UnpackTo (out realX, out realY, out realZ, out realW);
                    var newPackedObj = new NormalisedShort4 (realX, realY, realZ, realW);
                    Assert.That (newPackedObj.PackedValue, Is.EqualTo (packed));
                }
                catch (ArgumentException) {
                    continue;
                }
            }
        }

        // For a given example, this test ensures that the ToString function
        // yields the expected string.
        [Test]
        public void TestMemberFn_ToString_i () {
            var testCase = new NormalisedShort4 ();
            testCase.PackFrom (0.656f, 0.125f, 0.222f, 0.861f);
            String s = testCase.ToString ();
            Assert.That (s, Is.EqualTo ("6E341C6A100053F7"));
        }

        // Makes sure that the hashing function is good by testing
        // random scenarios and ensuring that there are no more than a
        // reasonable number of collisions.
        [Test]
        public void TestMemberFn_GetHashCode_i () {
            HashSet<Int32> hs = new HashSet<Int32>();
            var rand = new System.Random ();
            var buff = new Byte[8];
            UInt32 collisions = 0;
            for (Int32 i = 0; i < Settings.NumTests; ++i) {
                rand.NextBytes (buff);
                UInt64 packed = BitConverter.ToUInt64 (buff, 0);
                var packedObj = new NormalisedShort4 ();
                packedObj.PackedValue = packed;
                Int32 hc = packedObj.GetHashCode ();
                if (hs.Contains (hc)) ++collisions;
                hs.Add (hc);
            }
            Assert.That (collisions, Is.LessThan (10));
        }
    }

    // ────────────────────────────────────────────────────────────────────────────────────────────────────────────── //
    // Tests the Rg32 packed data type.
    [TestFixture]
    public class Rg32Tests
    {
        // Iterates over a random selection of values within the range of
        // possible Rg32 values and makes sure that unpacking them and
        // then re-packing that result yields the original packed value.
        [Test]
        public void TestRandomValues_i () {
            var rand = new System.Random ();
            var buff = new Byte[4];

            for (Int32 i = 0; i < Settings.NumTests; ++i) {
                rand.NextBytes (buff);
                UInt32 packed = BitConverter.ToUInt32 (buff, 0);
                var packedObj = new Rg32 ();
                packedObj.PackedValue = packed;
                Single realR, realG = 0f;
                packedObj.UnpackTo (out realR, out realG);
                var newPackedObj = new Rg32 (realR, realG);
                Assert.That (newPackedObj.PackedValue, Is.EqualTo (packed));
            }
        }

        // For a given example, this test ensures that the ToString function
        // yields the expected string.
        [Test]
        public void TestMemberFn_ToString_i () {
            var testCase = new Rg32 ();
            testCase.PackFrom (0.222f, 0.861f);
            String s = testCase.ToString ();
            Assert.That (s, Is.EqualTo ("DC6A38D5"));
        }

        // Makes sure that the hashing function is good by testing
        // random scenarios and ensuring that there are no more than a
        // reasonable number of collisions.
        [Test]
        public void TestMemberFn_GetHashCode_i () {
            HashSet<Int32> hs = new HashSet<Int32>();
            var rand = new System.Random ();
            var buff = new Byte[4];
            UInt32 collisions = 0;
            for (Int32 i = 0; i < Settings.NumTests; ++i) {
                rand.NextBytes (buff);
                UInt32 packed = BitConverter.ToUInt32 (buff, 0);
                var packedObj = new Rgba64 ();
                packedObj.PackedValue = packed;
                Int32 hc = packedObj.GetHashCode ();
                if (hs.Contains (hc)) ++collisions;
                hs.Add (hc);
            }
            Assert.That (collisions, Is.LessThan (10));
        }
    }

    // ────────────────────────────────────────────────────────────────────────────────────────────────────────────── //
    // Tests the Rgba32 packed data type.
    [TestFixture]
    public class Rgba32Tests
    {
        // Iterates over a random selection of values within the range of
        // possible Rgba32 values and makes sure that unpacking them and
        // then re-packing that result yields the original packed value.
        [Test]
        public void TestRandomValues_i () {
            var rand = new System.Random ();
            var buff = new Byte[4];

            for (Int32 i = 0; i < Settings.NumTests; ++i) {
                rand.NextBytes (buff);
                UInt32 packed = BitConverter.ToUInt32 (buff, 0);
                var packedObj = new Rgba32 ();
                packedObj.PackedValue = packed;
                Single realR, realG, realB, realA = 0f;
                packedObj.UnpackTo (out realR, out realG, out realB, out realA);
                var newPackedObj = new Rgba32 (realR, realG, realB, realA);
                Assert.That (newPackedObj.PackedValue, Is.EqualTo (packed));
            }
        }

        // For a given example, this test ensures that the ToString function
        // yields the expected string.
        [Test]
        public void TestMemberFn_ToString_i () {
            var testCase = new Rgba32 ();
            testCase.PackFrom (0.656f, 0.125f, 0.222f, 0.861f);
            String s = testCase.ToString ();
            Assert.That (s, Is.EqualTo ("{R:167 G:32 B:57 A:220}"));
        }

        // Makes sure that the hashing function is good by testing
        // random scenarios and ensuring that there are no more than a
        // reasonable number of collisions.
        [Test]
        public void TestMemberFn_GetHashCode_i () {
            HashSet<Int32> hs = new HashSet<Int32>();
            var rand = new System.Random ();
            var buff = new Byte[4];
            UInt32 collisions = 0;
            for (Int32 i = 0; i < Settings.NumTests; ++i) {
                rand.NextBytes (buff);
                UInt32 packed = BitConverter.ToUInt32 (buff, 0);
                var packedObj = new Rgba32 ();
                packedObj.PackedValue = packed;
                Int32 hc = packedObj.GetHashCode ();
                if (hs.Contains (hc)) ++collisions;
                hs.Add (hc);
            }
            Assert.That (collisions, Is.LessThan (10));
        }
    }

    // ────────────────────────────────────────────────────────────────────────────────────────────────────────────── //
    // Tests the Rgba64 packed data type.
    [TestFixture]
    public class Rgba64Tests
    {
        // Iterates over a random selection of values within the range of
        // possible Rgba64 values and makes sure that unpacking them and
        // then re-packing that result yields the original packed value.
        [Test]
        public void TestRandomValues_i () {
            var rand = new System.Random ();
            var buff = new Byte[8];

            for (Int32 i = 0; i < Settings.NumTests; ++i) {
                rand.NextBytes (buff);
                UInt64 packed = BitConverter.ToUInt64 (buff, 0);
                var packedObj = new Rgba64 ();
                packedObj.PackedValue = packed;
                Single realR, realG, realB, realA = 0f;
                packedObj.UnpackTo (out realR, out realG, out realB, out realA);
                var newPackedObj = new Rgba64 (realR, realG, realB, realA);
                Assert.That (newPackedObj.PackedValue, Is.EqualTo (packed));
            }
        }

        // For a given example, this test ensures that the ToString function
        // yields the expected string.
        [Test]
        public void TestMemberFn_ToString_i () {
            var testCase = new Rgba64 ();
            testCase.PackFrom (0.656f, 0.125f, 0.222f, 0.861f);
            String s = testCase.ToString ();
            Assert.That (s, Is.EqualTo ("DC6A38D52000A7EF"));
        }

        // Makes sure that the hashing function is good by testing
        // random scenarios and ensuring that there are no more than a
        // reasonable number of collisions.
        [Test]
        public void TestMemberFn_GetHashCode_i () {
            HashSet<Int32> hs = new HashSet<Int32>();
            var rand = new System.Random ();
            var buff = new Byte[8];
            UInt32 collisions = 0;
            for (Int32 i = 0; i < Settings.NumTests; ++i) {
                rand.NextBytes (buff);
                UInt64 packed = BitConverter.ToUInt64 (buff, 0);
                var packedObj = new Rgba64 ();
                packedObj.PackedValue = packed;
                Int32 hc = packedObj.GetHashCode ();
                if (hs.Contains (hc)) ++collisions;
                hs.Add (hc);
            }
            Assert.That (collisions, Is.LessThan (10));
        }
    }

    // ────────────────────────────────────────────────────────────────────────────────────────────────────────────── //
    // Tests the Rgba1010102 packed data type.
    [TestFixture]
    public class Rgba1010102Tests {
        // Iterates over a random selection of values within the range of
        // possible Rgba1010102 values and makes sure that unpacking them and
        // then re-packing that result yields the original packed value.
        [Test]
        public void TestRandomValues_i () {
            var rand = new System.Random ();
            var buff = new Byte[4];

            for (Int32 i = 0; i < Settings.NumTests; ++i) {
                rand.NextBytes (buff);
                UInt32 packed = BitConverter.ToUInt32 (buff, 0);
                var packedObj = new Rgba1010102 ();
                packedObj.PackedValue = packed;
                Single realR, realG, realB, realA = 0f;
                packedObj.UnpackTo (out realR, out realG, out realB, out realA);
                var newPackedObj = new Rgba1010102 (realR, realG, realB, realA);
                Assert.That (newPackedObj.PackedValue, Is.EqualTo (packed));
            }
        }

        // For a given example, this test ensures that the ToString function
        // yields the expected string.
        [Test]
        public void TestMemberFn_ToString_i () {
            var testCase = new Rgba1010102 ();
            testCase.PackFrom (0.656f, 0.125f, 0.222f, 0.861f);
            String s = testCase.ToString ();
            Assert.That (s, Is.EqualTo ("8DD0A7EF"));
        }

        // Makes sure that the hashing function is good by testing
        // random scenarios and ensuring that there are no more than a
        // reasonable number of collisions.
        [Test]
        public void TestMemberFn_GetHashCode_i () {
            HashSet<Int32> hs = new HashSet<Int32>();
            var rand = new System.Random ();
            var buff = new Byte[4];
            UInt32 collisions = 0;
            for (Int32 i = 0; i < Settings.NumTests; ++i) {
                rand.NextBytes (buff);
                UInt32 packed = BitConverter.ToUInt32 (buff, 0);
                var packedObj = new Rgba1010102 ();
                packedObj.PackedValue = packed;
                Int32 hc = packedObj.GetHashCode ();
                if (hs.Contains (hc)) ++collisions;
                hs.Add (hc);
            }
            Assert.That (collisions, Is.LessThan (10));
        }
    }

    // ────────────────────────────────────────────────────────────────────────────────────────────────────────────── //
    // Tests the Short2 packed data type.
    [TestFixture]
    public class Short2Tests
    {
        // Iterates over a random selection of values within the range of
        // possible Short2 values and makes sure that unpacking them and
        // then re-packing that result yields the original packed value.
        [Test]
        public void TestRandomValues_i () {
            var rand = new System.Random ();
            var buff = new Byte[4];

            for (Int32 i = 0; i < Settings.NumTests; ++i) {
                rand.NextBytes (buff);
                UInt32 packed = BitConverter.ToUInt32 (buff, 0);
                var packedObj = new Short2 ();
                packedObj.PackedValue = packed;
                Single realX, realY = 0f;
                packedObj.UnpackTo (out realX, out realY);
                var newPackedObj = new Short2 (realX, realY);
                Assert.That (newPackedObj.PackedValue, Is.EqualTo (packed));
            }
        }

        // For a given example, this test ensures that the ToString function
        // yields the expected string.
        [Test]
        public void TestMemberFn_ToString_i () {
            var testCase = new Short2 ();
            testCase.PackFrom (0.656f, 0.125f);
            String s = testCase.ToString ();
            Assert.That (s, Is.EqualTo ("00000001"));
        }

        // Makes sure that the hashing function is good by testing
        // random scenarios and ensuring that there are no more than a
        // reasonable number of collisions.
        [Test]
        public void TestMemberFn_GetHashCode_i () {
            HashSet<Int32> hs = new HashSet<Int32>();
            var rand = new System.Random ();
            var buff = new Byte[4];
            UInt32 collisions = 0;
            for (Int32 i = 0; i < Settings.NumTests; ++i) {
                rand.NextBytes (buff);
                UInt32 packed = BitConverter.ToUInt32 (buff, 0);
                var packedObj = new Short2 ();
                packedObj.PackedValue = packed;
                Int32 hc = packedObj.GetHashCode ();
                if (hs.Contains (hc)) ++collisions;
                hs.Add (hc);
            }
            Assert.That (collisions, Is.LessThan (10));
        }
    }

    // ────────────────────────────────────────────────────────────────────────────────────────────────────────────── //
    // Tests the Short4 packed data type.
    [TestFixture]
    public class Short4Tests
    {
        // Iterates over a random selection of values within the range of
        // possible Short4 values and makes sure that unpacking them and
        // then re-packing that result yields the original packed value.
        [Test]
        public void TestRandomValues_i () {
            var rand = new System.Random ();
            var buff = new Byte[8];

            for (Int32 i = 0; i < Settings.NumTests; ++i) {
                rand.NextBytes (buff);
                UInt64 packed = BitConverter.ToUInt64 (buff, 0);
                var packedObj = new Short4 ();
                packedObj.PackedValue = packed;
                Single realX, realY, realZ, realW = 0f;
                packedObj.UnpackTo (out realX, out realY, out realZ, out realW);
                var newPackedObj = new Short4 (realX, realY, realZ, realW);
                Assert.That (newPackedObj.PackedValue, Is.EqualTo (packedObj.PackedValue));
            }
        }

        // For a given example, this test ensures that the ToString function
        // yields the expected string.
        [Test]
        public void TestMemberFn_ToString_i () {
            var testCase = new Short4 ();
            testCase.PackFrom (0.656f, 0.125f, 0.222f, 0.861f);
            String s = testCase.ToString ();
            Assert.That (s, Is.EqualTo ("1000000000001"));
        }

        // Makes sure that the hashing function is good by testing
        // random scenarios and ensuring that there are no more than a
        // reasonable number of collisions.
        [Test]
        public void TestMemberFn_GetHashCode_i ()
        {
            HashSet<Int32> hs = new HashSet<Int32>();
            var rand = new System.Random ();
            var buff = new Byte[8];
            UInt32 collisions = 0;
            for (Int32 i = 0; i < Settings.NumTests; ++i) {
                rand.NextBytes (buff);
                UInt64 packed = BitConverter.ToUInt64 (buff, 0);
                var packedObj = new Short4 ();
                packedObj.PackedValue = packed;
                Int32 hc = packedObj.GetHashCode ();
                if (hs.Contains (hc)) ++collisions;
                hs.Add (hc);
            }
            Assert.That (collisions, Is.LessThan (10));
        }
    }

}
