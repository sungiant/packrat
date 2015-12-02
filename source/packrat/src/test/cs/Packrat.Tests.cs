namespace Packrat.Tests
{
    using System;
    using System.Globalization;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Runtime.ConstrainedExecution;
    using NUnit.Framework;
    using System.Runtime.CompilerServices;

    static class Settings
    {
        internal const UInt32 NumTests = 10000;
    }

    /// <summary>
    /// Tests the Alpha_8 packed data type.
    /// </summary>
    [TestFixture]
    public class Alpha_8Tests
    {
        /// <summary>
        /// Iterates over every possible Alpha_8 value and makes sure that
        /// unpacking them and then re-packing that result yeilds the 
        /// original packed value.
        /// </summary>
        [Test]
        public void TestAllPossibleValues_i()
        {   
            Byte packed = Byte.MinValue;
            while ( packed < Byte.MaxValue )
            {
                ++packed;
                var packedObj = new Alpha_8();
                packedObj.PackedValue = packed;
                Single unpacked;
                packedObj.UnpackTo(out unpacked);
                var newPackedObj = new Alpha_8(unpacked);
                Assert.That(newPackedObj.PackedValue, Is.EqualTo(packed));
            }
        }

        /// <summary>
        /// For a given example, this test ensures that the ToString function
        /// yields the expected string.
        /// </summary>
        [Test]
        public void TestMemberFn_ToString_i()
        {
            var testCase = new Alpha_8();
            testCase.PackFrom(0.656f);
            String s = testCase.ToString ();
            Assert.That(s, Is.EqualTo("A7"));
        }

        /// <summary>
        /// Makes sure that the hashing function is good by testing 
        /// all scenarios and ensuring that there are no collisions.
        /// </summary>
        [Test]
        public void TestMemberFn_GetHashCode_i ()
        {
            HashSet<Int32> hs = new HashSet<Int32>();
            Byte packed = Byte.MinValue;
            while ( packed < Byte.MaxValue )
            {
                ++packed;
                var packedObj = new Alpha_8();
                packedObj.PackedValue = packed;
                Int32 hc = packedObj.GetHashCode ();
                Assert.That(!hs.Contains(hc));
                hs.Add(hc);
            }
        }
    }

    /// <summary>
    /// Tests the Bgr_5_6_5 packed data type.
    /// </summary>
    [TestFixture]
    public class Bgr_5_6_5Tests
    {
        /// <summary>
        /// Iterates over every possible Bgr_5_6_5 value and makes sure that
        /// unpacking them and then re-packing that result yeilds the
        /// original packed value.
        /// </summary>
        [Test]
        public void TestAllPossibleValues_i()
        {
            UInt16 packed = UInt16.MinValue;
            while ( packed < UInt16.MaxValue )
            {
                ++packed;
                var packedObj = new Bgr_5_6_5();
                packedObj.PackedValue = packed;
                Single realB, realG, realR = 0f;
                packedObj.UnpackTo(out realB, out realG, out realR);
                var newPackedObj = new Bgr_5_6_5(realB, realG, realR);
                Assert.That(newPackedObj.PackedValue, Is.EqualTo(packed));
            }
        }

        /// <summary>
        /// For a given example, this test ensures that the ToString function
        /// yields the expected string.
        /// </summary>
        [Test]
        public void TestMemberFn_ToString_i()
        {
            var testCase = new Bgr_5_6_5();
            testCase.PackFrom(0.861f, 0.125f, 0.656f);
            String s = testCase.ToString ();
            Assert.That(s, Is.EqualTo("A11B"));
        }

        /// <summary>
        /// Makes sure that the hashing function is good by testing
        /// all scenarios and ensuring that there are no collisions.
        /// </summary>
        [Test]
        public void TestMemberFn_GetHashCode_i ()
        {
            HashSet<Int32> hs = new HashSet<Int32>();
            UInt16 packed = UInt16.MinValue;
            while ( packed < UInt16.MaxValue )
            {
                ++packed;
                var packedObj = new Bgr_5_6_5();
                packedObj.PackedValue = packed;
                Int32 hc = packedObj.GetHashCode ();
                Assert.That(!hs.Contains(hc));
                hs.Add(hc);
            }
        }
    }

    /// <summary>
    /// Tests the Bgra16 packed data type.
    /// </summary>
    [TestFixture]
    public class Bgra16Tests
    {
        /// <summary>
        /// Iterates over every possible Bgra16 value and makes sure that
        /// unpacking them and then re-packing that result yeilds the
        /// original packed value.
        /// </summary>
        [Test]
        public void TestAllPossibleValues_i()
        {
            UInt16 packed = UInt16.MinValue;
            while ( packed < UInt16.MaxValue )
            {
                ++packed;
                var packedObj = new Bgra16();
                packedObj.PackedValue = packed;
                Single realB, realG, realR, realA = 0f;
                packedObj.UnpackTo(out realB, out realG, out realR, out realA);
                var newPackedObj = new Bgra16(realB, realG, realR, realA);
                Assert.That(newPackedObj.PackedValue, Is.EqualTo(packed));
            }
        }

        /// <summary>
        /// For a given example, this test ensures that the ToString function
        /// yields the expected string.
        /// </summary>
        [Test]
        public void TestMemberFn_ToString_i()
        {
            var testCase = new Bgra16();
            testCase.PackFrom(0.222f, 0.125f, 0.656f, 0.861f);
            String s = testCase.ToString ();
            Assert.That(s, Is.EqualTo("DA23"));
        }

        /// <summary>
        /// Makes sure that the hashing function is good by testing
        /// all scenarios and ensuring that there are no collisions.
        /// </summary>
        [Test]
        public void TestMemberFn_GetHashCode_i ()
        {
            HashSet<Int32> hs = new HashSet<Int32>();
            UInt16 packed = UInt16.MinValue;
            while ( packed < UInt16.MaxValue )
            {
                ++packed;
                var packedObj = new Bgra16();
                packedObj.PackedValue = packed;
                Int32 hc = packedObj.GetHashCode ();
                Assert.That(!hs.Contains(hc));
                hs.Add(hc);
            }
        }
    }

    /// <summary>
    /// Tests the Bgra_5_5_5_1 packed data type.
    /// </summary>
    [TestFixture]
    public class Bgra_5_5_5_1Tests
    {
        /// <summary>
        /// Iterates over every possible Bgra_5_5_5_1 value and makes sure that
        /// unpacking them and then re-packing that result yeilds the
        /// original packed value.
        /// </summary>
        [Test]
        public void TestAllPossibleValues_i()
        {
            UInt16 packed = UInt16.MinValue;
            while ( packed < UInt16.MaxValue )
            {
                ++packed;
                var packedObj = new Bgra_5_5_5_1();
                packedObj.PackedValue = packed;
                Single realB, realG, realR, realA = 0f;
                packedObj.UnpackTo(out realB, out realG, out realR, out realA);
                var newPackedObj = new Bgra_5_5_5_1(realB, realG, realR, realA);
                Assert.That(newPackedObj.PackedValue, Is.EqualTo(packed));
            }
        }

        /// <summary>
        /// For a given example, this test ensures that the ToString function
        /// yields the expected string.
        /// </summary>
        [Test]
        public void TestMemberFn_ToString_i()
        {
            var testCase = new Bgra_5_5_5_1();
            testCase.PackFrom(0.222f, 0.125f, 0.656f, 0.861f);
            String s = testCase.ToString ();
            Assert.That(s, Is.EqualTo("D087"));
        }

        /// <summary>
        /// Makes sure that the hashing function is good by testing
        /// all scenarios and ensuring that there are no collisions.
        /// </summary>
        [Test]
        public void TestMemberFn_GetHashCode_i ()
        {
            HashSet<Int32> hs = new HashSet<Int32>();
            UInt16 packed = UInt16.MinValue;
            while ( packed < UInt16.MaxValue )
            {
                ++packed;
                var packedObj = new Bgra_5_5_5_1();
                packedObj.PackedValue = packed;
                Int32 hc = packedObj.GetHashCode ();
                Assert.That(!hs.Contains(hc));
                hs.Add(hc);
            }
        }
    }
    /// <summary>
    /// Tests the Byte4 packed data type.
    /// </summary>
    [TestFixture]
    public class Byte4Tests
    {
        /// <summary>
        /// Iterates over a random selection of values within the range of
        /// possible Byte4 values and makes sure that unpacking them and
        /// then re-packing that result yeilds the original packed value.
        /// </summary>
        [Test]
        public void TestRandomValues_i()
        {
            var rand = new System.Random();
            var buff = new Byte[4];

            for(Int32 i = 0; i < Settings.NumTests; ++i)
            {
                rand.NextBytes(buff);
                UInt32 packed = BitConverter.ToUInt32(buff, 0);
                var packedObj = new Byte4();
                packedObj.PackedValue = packed;
                Single realX, realY, realZ, realW = 0f;
                packedObj.UnpackTo(out realX, out realY, out realZ, out realW);
                var newPackedObj = new Byte4(realX, realY, realZ, realW);
                Assert.That(newPackedObj.PackedValue, Is.EqualTo(packed));
            }
        }

        /// <summary>
        /// For a given example, this test ensures that the ToString function
        /// yields the expected string.
        /// </summary>
        [Test]
        public void TestMemberFn_ToString_i()
        {
            var testCase = new Byte4();
            testCase.PackFrom(0.656f, 0.125f, 0.222f, 0.861f);
            String s = testCase.ToString ();
            Assert.That(s, Is.EqualTo("01000001"));
        }

        /// <summary>
        /// Makes sure that the hashing function is good by testing
        /// random scenarios and ensuring that there are no more than a
        /// reasonable number of collisions.
        /// </summary>
        [Test]
        public void TestMemberFn_GetHashCode_i ()
        {
            HashSet<Int32> hs = new HashSet<Int32>();
            var rand = new System.Random();
            var buff = new Byte[4];
            UInt32 collisions = 0;
            for(Int32 i = 0; i < Settings.NumTests; ++i)
            {
                rand.NextBytes(buff);
                BitConverter.ToUInt32(buff, 0);
                UInt32 packed = BitConverter.ToUInt32(buff, 0);
                var packedObj = new Byte4();
                packedObj.PackedValue = packed;
                Int32 hc = packedObj.GetHashCode ();
                if(hs.Contains(hc)) ++collisions;
                hs.Add(hc);
            }
            Assert.That(collisions, Is.LessThan(10));
        }
    }

    /// <summary>
    /// Tests the NormalisedByte2 packed data type.
    /// </summary>
    [TestFixture]
    public class NormalisedByte2Tests
    {
        /// <summary>
        /// Iterates over every possible NormalisedByte2 value and makes sure that
        /// unpacking them and then re-packing that result yeilds the
        /// original packed value.
        /// </summary>
        [Test]
        public void TestAllPossibleValues_i()
        {
            UInt16 packed = UInt16.MinValue;
            while ( packed < UInt16.MaxValue )
            {
                ++packed;
                // Cannot guarantee that this packed value is valid.
                try
                {
                    var packedObj = new NormalisedByte2();
                    packedObj.PackedValue = packed;
                    Single realX, realY = 0f;
                    packedObj.UnpackTo(out realX, out realY);
                    var newPackedObj = new NormalisedByte2(realX, realY);
                    Assert.That(newPackedObj.PackedValue, Is.EqualTo(packedObj.PackedValue));
                }
                catch(ArgumentException)
                {
                    continue;
                }
            }
        }

        /// <summary>
        /// For a given example, this test ensures that the ToString function
        /// yields the expected string.
        /// </summary>
        [Test]
        public void TestMemberFn_ToString_i()
        {
            var testCase = new NormalisedByte2();
            testCase.PackFrom(0.222f, 0.861f);
            String s = testCase.ToString ();
            Assert.That(s, Is.EqualTo("6D1C"));
        }

        /// <summary>
        /// Makes sure that the hashing function is good by testing
        /// all scenarios and ensuring that there are no collisions.
        /// </summary>
        [Test]
        public void TestMemberFn_GetHashCode_i ()
        {
            HashSet<Int32> hs = new HashSet<Int32>();
            UInt16 packed = UInt16.MinValue;
            while ( packed < UInt16.MaxValue )
            {
                ++packed;
                var packedObj = new NormalisedByte2();
                packedObj.PackedValue = packed;
                Int32 hc = packedObj.GetHashCode ();
                Assert.That(!hs.Contains(hc));
                hs.Add(hc);
            }
        }
    }

    /// <summary>
    /// Tests the NormalisedByte4 packed data type.
    /// </summary>
    [TestFixture]
    public class NormalisedByte4Tests
    {
        /// <summary>
        /// Iterates over a random selection of values within the range of
        /// possible NormalisedByte4 values and makes sure that unpacking them and
        /// then re-packing that result yeilds the original packed value.
        /// </summary>
        [Test]
        public void TestRandomValues_i()
        {
            var rand = new System.Random();
            var buff = new Byte[4];

            for(Int32 i = 0; i < Settings.NumTests; ++i)
            {
                rand.NextBytes(buff);
                UInt32 packed = BitConverter.ToUInt32(buff, 0);

                // Cannot guarantee that this packed value is valid.
                try
                {
                    var packedObj = new NormalisedByte4();
                    packedObj.PackedValue = packed;
                    Single realX, realY, realZ, realW = 0f;
                    packedObj.UnpackTo(out realX, out realY, out realZ, out realW);
                    var newPackedObj = new NormalisedByte4(realX, realY, realZ, realW);
                    Assert.That(newPackedObj.PackedValue, Is.EqualTo(packed));
                }
                catch(ArgumentException)
                {
                    continue;
                }
            }
        }

        /// <summary>
        /// For a given example, this test ensures that the ToString function
        /// yields the expected string.
        /// </summary>
        [Test]
        public void TestMemberFn_ToString_i()
        {
            var testCase = new NormalisedByte4();
            testCase.PackFrom(0.656f, 0.125f, 0.222f, 0.861f);
            String s = testCase.ToString ();
            Assert.That(s, Is.EqualTo("6D1C1053"));
        }

        /// <summary>
        /// Makes sure that the hashing function is good by testing
        /// random scenarios and ensuring that there are no more than a
        /// reasonable number of collisions.
        /// </summary>
        [Test]
        public void TestMemberFn_GetHashCode_i ()
        {
            HashSet<Int32> hs = new HashSet<Int32>();
            var rand = new System.Random();
            var buff = new Byte[4];
            UInt32 collisions = 0;
            for(Int32 i = 0; i < Settings.NumTests; ++i)
            {
                rand.NextBytes(buff);
                UInt32 packed = BitConverter.ToUInt32(buff, 0);
                var packedObj = new NormalisedByte4();
                packedObj.PackedValue = packed;
                Int32 hc = packedObj.GetHashCode ();
                if(hs.Contains(hc)) ++collisions;
                hs.Add(hc);
            }
            Assert.That(collisions, Is.LessThan(10));
        }
    }

    /// <summary>
    /// Tests the NormalisedShort2 packed data type.
    /// </summary>
    [TestFixture]
    public class NormalisedShort2Tests
    {
        /// <summary>
        /// Iterates over a random selection of values within the range of
        /// possible NormalisedShort2 values and makes sure that unpacking them and
        /// then re-packing that result yeilds the original packed value.
        /// </summary>
        [Test]
        public void TestRandomValues_i()
        {
            var rand = new System.Random();
            var buff = new Byte[4];

            for(Int32 i = 0; i < Settings.NumTests; ++i)
            {
                rand.NextBytes(buff);
                UInt32 packed = BitConverter.ToUInt32(buff, 0);

                // Cannot guarantee that this packed value is valid.
                try
                {
                    var packedObj = new NormalisedShort2();
                    packedObj.PackedValue = packed;
                    Single realX, realY = 0f;
                    packedObj.UnpackTo(out realX, out realY);
                    var newPackedObj = new NormalisedShort2(realX, realY);
                    Assert.That(newPackedObj.PackedValue, Is.EqualTo(packed));
                }
                catch(ArgumentException)
                {
                    continue;
                }
            }
        }

        /// <summary>
        /// For a given example, this test ensures that the ToString function
        /// yields the expected string.
        /// </summary>
        [Test]
        public void TestMemberFn_ToString_i()
        {
            var testCase = new NormalisedShort2();
            testCase.PackFrom(0.656f, 0.861f);
            String s = testCase.ToString ();
            Assert.That(s, Is.EqualTo("6E3453F7"));
        }

        /// <summary>
        /// Makes sure that the hashing function is good by testing
        /// random scenarios and ensuring that there are no more than a
        /// reasonable number of collisions.
        /// </summary>
        [Test]
        public void TestMemberFn_GetHashCode_i ()
        {
            HashSet<Int32> hs = new HashSet<Int32>();
            var rand = new System.Random();
            var buff = new Byte[4];
            UInt32 collisions = 0;
            for(Int32 i = 0; i < Settings.NumTests; ++i)
            {
                rand.NextBytes(buff);
                UInt32 packed = BitConverter.ToUInt32(buff, 0);
                var packedObj = new NormalisedShort2();
                packedObj.PackedValue = packed;
                Int32 hc = packedObj.GetHashCode ();
                if(hs.Contains(hc)) ++collisions;
                hs.Add(hc);
            }
            Assert.That(collisions, Is.LessThan(10));
        }
    }

    /// <summary>
    /// Tests the NormalisedShort4 packed data type.
    /// </summary>
    [TestFixture]
    public class NormalisedShort4Tests
    {
        /// <summary>
        /// Iterates over a random selection of values within the range of
        /// possible NormalisedShort4 values and makes sure that unpacking them and
        /// then re-packing that result yeilds the original packed value.
        /// </summary>
        [Test]
        public void TestRandomValues_i()
        {
            var rand = new System.Random();
            var buff = new Byte[8];

            for(Int32 i = 0; i < Settings.NumTests; ++i)
            {
                rand.NextBytes(buff);
                UInt64 packed = BitConverter.ToUInt64(buff, 0);

                // Cannot guarantee that this packed value is valid.
                try
                {
                    var packedObj = new NormalisedShort4();
                    packedObj.PackedValue = packed;
                    Single realX, realY, realZ, realW = 0f;
                    packedObj.UnpackTo(out realX, out realY, out realZ, out realW);
                    var newPackedObj = new NormalisedShort4(realX, realY, realZ, realW);
                    Assert.That(newPackedObj.PackedValue, Is.EqualTo(packed));
                }
                catch(ArgumentException)
                {
                    continue;
                }
            }
        }

        /// <summary>
        /// For a given example, this test ensures that the ToString function
        /// yields the expected string.
        /// </summary>
        [Test]
        public void TestMemberFn_ToString_i()
        {
            var testCase = new NormalisedShort4();
            testCase.PackFrom(0.656f, 0.125f, 0.222f, 0.861f);
            String s = testCase.ToString ();
            Assert.That(s, Is.EqualTo("6E341C6A100053F7"));
        }

        /// <summary>
        /// Makes sure that the hashing function is good by testing
        /// random scenarios and ensuring that there are no more than a
        /// reasonable number of collisions.
        /// </summary>
        [Test]
        public void TestMemberFn_GetHashCode_i ()
        {
            HashSet<Int32> hs = new HashSet<Int32>();
            var rand = new System.Random();
            var buff = new Byte[8];
            UInt32 collisions = 0;
            for(Int32 i = 0; i < Settings.NumTests; ++i)
            {
                rand.NextBytes(buff);
                UInt64 packed = BitConverter.ToUInt64(buff, 0);
                var packedObj = new NormalisedShort4();
                packedObj.PackedValue = packed;
                Int32 hc = packedObj.GetHashCode ();
                if(hs.Contains(hc)) ++collisions;
                hs.Add(hc);
            }
            Assert.That(collisions, Is.LessThan(10));
        }
    }

    /// <summary>
    /// Tests the Rg32 packed data type.
    /// </summary>
    [TestFixture]
    public class Rg32Tests
    {
        /// <summary>
        /// Iterates over a random selection of values within the range of
        /// possible Rg32 values and makes sure that unpacking them and
        /// then re-packing that result yeilds the original packed value.
        /// </summary>
        [Test]
        public void TestRandomValues_i()
        {
            var rand = new System.Random();
            var buff = new Byte[4];

            for(Int32 i = 0; i < Settings.NumTests; ++i)
            {
                rand.NextBytes(buff);
                UInt32 packed = BitConverter.ToUInt32(buff, 0);
                var packedObj = new Rg32();
                packedObj.PackedValue = packed;
                Single realR, realG = 0f;
                packedObj.UnpackTo(out realR, out realG);
                var newPackedObj = new Rg32(realR, realG);
                Assert.That(newPackedObj.PackedValue, Is.EqualTo(packed));
            }
        }

        /// <summary>
        /// For a given example, this test ensures that the ToString function
        /// yields the expected string.
        /// </summary>
        [Test]
        public void TestMemberFn_ToString_i()
        {
            var testCase = new Rg32();
            testCase.PackFrom(0.222f, 0.861f);
            String s = testCase.ToString ();
            Assert.That(s, Is.EqualTo("DC6A38D5"));
        }

        /// <summary>
        /// Makes sure that the hashing function is good by testing
        /// random scenarios and ensuring that there are no more than a
        /// reasonable number of collisions.
        /// </summary>
        [Test]
        public void TestMemberFn_GetHashCode_i ()
        {
            HashSet<Int32> hs = new HashSet<Int32>();
            var rand = new System.Random();
            var buff = new Byte[4];
            UInt32 collisions = 0;
            for(Int32 i = 0; i < Settings.NumTests; ++i)
            {
                rand.NextBytes(buff);
                UInt32 packed = BitConverter.ToUInt32(buff, 0);
                var packedObj = new Rgba64();
                packedObj.PackedValue = packed;
                Int32 hc = packedObj.GetHashCode ();
                if(hs.Contains(hc)) ++collisions;
                hs.Add(hc);
            }
            Assert.That(collisions, Is.LessThan(10));
        }
    }

    /// <summary>
    /// Tests the Rgba32 packed data type.
    /// </summary>
    [TestFixture]
    public class Rgba32Tests
    {
        /// <summary>
        /// Iterates over a random selection of values within the range of
        /// possible Rgba32 values and makes sure that unpacking them and
        /// then re-packing that result yeilds the original packed value.
        /// </summary>
        [Test]
        public void TestRandomValues_i()
        {
            var rand = new System.Random();
            var buff = new Byte[4];

            for(Int32 i = 0; i < Settings.NumTests; ++i)
            {
                rand.NextBytes(buff);
                UInt32 packed = BitConverter.ToUInt32(buff, 0);
                var packedObj = new Rgba32();
                packedObj.PackedValue = packed;
                Single realR, realG, realB, realA = 0f;
                packedObj.UnpackTo(out realR, out realG, out realB, out realA);
                var newPackedObj = new Rgba32(realR, realG, realB, realA);
                Assert.That(newPackedObj.PackedValue, Is.EqualTo(packed));
            }
        }

        /// <summary>
        /// For a given example, this test ensures that the ToString function
        /// yields the expected string.
        /// </summary>
        [Test]
        public void TestMemberFn_ToString_i()
        {
            var testCase = new Rgba32();
            testCase.PackFrom(0.656f, 0.125f, 0.222f, 0.861f);
            String s = testCase.ToString ();
            Assert.That(s, Is.EqualTo("{R:167 G:32 B:57 A:220}"));
        }

        /// <summary>
        /// Makes sure that the hashing function is good by testing
        /// random scenarios and ensuring that there are no more than a
        /// reasonable number of collisions.
        /// </summary>
        [Test]
        public void TestMemberFn_GetHashCode_i ()
        {
            HashSet<Int32> hs = new HashSet<Int32>();
            var rand = new System.Random();
            var buff = new Byte[4];
            UInt32 collisions = 0;
            for(Int32 i = 0; i < Settings.NumTests; ++i)
            {
                rand.NextBytes(buff);
                UInt32 packed = BitConverter.ToUInt32(buff, 0);
                var packedObj = new Rgba32();
                packedObj.PackedValue = packed;
                Int32 hc = packedObj.GetHashCode ();
                if(hs.Contains(hc)) ++collisions;
                hs.Add(hc);
            }
            Assert.That(collisions, Is.LessThan(10));
        }
    }

    /// <summary>
    /// Tests the Rgba64 packed data type.
    /// </summary>
    [TestFixture]
    public class Rgba64Tests
    {
        /// <summary>
        /// Iterates over a random selection of values within the range of
        /// possible Rgba64 values and makes sure that unpacking them and
        /// then re-packing that result yeilds the original packed value.
        /// </summary>
        [Test]
        public void TestRandomValues_i()
        {
            var rand = new System.Random();
            var buff = new Byte[8];

            for(Int32 i = 0; i < Settings.NumTests; ++i)
            {
                rand.NextBytes(buff);
                UInt64 packed = BitConverter.ToUInt64(buff, 0);
                var packedObj = new Rgba64();
                packedObj.PackedValue = packed;
                Single realR, realG, realB, realA = 0f;
                packedObj.UnpackTo(out realR, out realG, out realB, out realA);
                var newPackedObj = new Rgba64(realR, realG, realB, realA);
                Assert.That(newPackedObj.PackedValue, Is.EqualTo(packed));
            }
        }

        /// <summary>
        /// For a given example, this test ensures that the ToString function
        /// yields the expected string.
        /// </summary>
        [Test]
        public void TestMemberFn_ToString_i()
        {
            var testCase = new Rgba64();
            testCase.PackFrom(0.656f, 0.125f, 0.222f, 0.861f);
            String s = testCase.ToString ();
            Assert.That(s, Is.EqualTo("DC6A38D52000A7EF"));
        }

        /// <summary>
        /// Makes sure that the hashing function is good by testing
        /// random scenarios and ensuring that there are no more than a
        /// reasonable number of collisions.
        /// </summary>
        [Test]
        public void TestMemberFn_GetHashCode_i ()
        {
            HashSet<Int32> hs = new HashSet<Int32>();
            var rand = new System.Random();
            var buff = new Byte[8];
            UInt32 collisions = 0;
            for(Int32 i = 0; i < Settings.NumTests; ++i)
            {
                rand.NextBytes(buff);
                UInt64 packed = BitConverter.ToUInt64(buff, 0);
                var packedObj = new Rgba64();
                packedObj.PackedValue = packed;
                Int32 hc = packedObj.GetHashCode ();
                if(hs.Contains(hc)) ++collisions;
                hs.Add(hc);
            }
            Assert.That(collisions, Is.LessThan(10));
        }
    }

    /// <summary>
    /// Tests the Rgba_10_10_10_2 packed data type.
    /// </summary>
    [TestFixture]
    public class Rgba_10_10_10_2Tests
    {
        /// <summary>
        /// Iterates over a random selection of values within the range of
        /// possible Rgba_10_10_10_2 values and makes sure that unpacking them and
        /// then re-packing that result yeilds the original packed value.
        /// </summary>
        [Test]
        public void TestRandomValues_i()
        {
            var rand = new System.Random();
            var buff = new Byte[4];

            for(Int32 i = 0; i < Settings.NumTests; ++i)
            {
                rand.NextBytes(buff);
                UInt32 packed = BitConverter.ToUInt32(buff, 0);
                var packedObj = new Rgba_10_10_10_2();
                packedObj.PackedValue = packed;
                Single realR, realG, realB, realA = 0f;
                packedObj.UnpackTo(out realR, out realG, out realB, out realA);
                var newPackedObj = new Rgba_10_10_10_2(realR, realG, realB, realA);
                Assert.That(newPackedObj.PackedValue, Is.EqualTo(packed));
            }
        }

        /// <summary>
        /// For a given example, this test ensures that the ToString function
        /// yields the expected string.
        /// </summary>
        [Test]
        public void TestMemberFn_ToString_i()
        {
            var testCase = new Rgba_10_10_10_2();
            testCase.PackFrom(0.656f, 0.125f, 0.222f, 0.861f);
            String s = testCase.ToString ();
            Assert.That(s, Is.EqualTo("8DD0A7EF"));
        }

        /// <summary>
        /// Makes sure that the hashing function is good by testing
        /// random scenarios and ensuring that there are no more than a
        /// reasonable number of collisions.
        /// </summary>
        [Test]
        public void TestMemberFn_GetHashCode_i ()
        {
            HashSet<Int32> hs = new HashSet<Int32>();
            var rand = new System.Random();
            var buff = new Byte[4];
            UInt32 collisions = 0;
            for(Int32 i = 0; i < Settings.NumTests; ++i)
            {
                rand.NextBytes(buff);
                UInt32 packed = BitConverter.ToUInt32(buff, 0);
                var packedObj = new Rgba_10_10_10_2();
                packedObj.PackedValue = packed;
                Int32 hc = packedObj.GetHashCode ();
                if(hs.Contains(hc)) ++collisions;
                hs.Add(hc);
            }
            Assert.That(collisions, Is.LessThan(10));
        }
    }

    /// <summary>
    /// Tests the Short2 packed data type.
    /// </summary>
    [TestFixture]
    public class Short2Tests
    {
        /// <summary>
        /// Iterates over a random selection of values within the range of
        /// possible Short2 values and makes sure that unpacking them and
        /// then re-packing that result yeilds the original packed value.
        /// </summary>
        [Test]
        public void TestRandomValues_i()
        {
            var rand = new System.Random();
            var buff = new Byte[4];

            for(Int32 i = 0; i < Settings.NumTests; ++i)
            {
                rand.NextBytes(buff);
                UInt32 packed = BitConverter.ToUInt32(buff, 0);
                var packedObj = new Short2();
                packedObj.PackedValue = packed;
                Single realX, realY = 0f;
                packedObj.UnpackTo(out realX, out realY);
                var newPackedObj = new Short2(realX, realY);
                Assert.That(newPackedObj.PackedValue, Is.EqualTo(packed));
            }
        }

        /// <summary>
        /// For a given example, this test ensures that the ToString function
        /// yields the expected string.
        /// </summary>
        [Test]
        public void TestMemberFn_ToString_i()
        {
            var testCase = new Short2();
            testCase.PackFrom(0.656f, 0.125f);
            String s = testCase.ToString ();
            Assert.That(s, Is.EqualTo("00000001"));
        }

        /// <summary>
        /// Makes sure that the hashing function is good by testing
        /// random scenarios and ensuring that there are no more than a
        /// reasonable number of collisions.
        /// </summary>
        [Test]
        public void TestMemberFn_GetHashCode_i ()
        {
            HashSet<Int32> hs = new HashSet<Int32>();
            var rand = new System.Random();
            var buff = new Byte[4];
            UInt32 collisions = 0;
            for(Int32 i = 0; i < Settings.NumTests; ++i)
            {
                rand.NextBytes(buff);
                UInt32 packed = BitConverter.ToUInt32(buff, 0);
                var packedObj = new Short2();
                packedObj.PackedValue = packed;
                Int32 hc = packedObj.GetHashCode ();
                if(hs.Contains(hc)) ++collisions;
                hs.Add(hc);
            }
            Assert.That(collisions, Is.LessThan(10));
        }
    }

    /// <summary>
    /// Tests the Short4 packed data type.
    /// </summary>
    [TestFixture]
    public class Short4Tests
    {
        /// <summary>
        /// Iterates over a random selection of values within the range of
        /// possible Short4 values and makes sure that unpacking them and
        /// then re-packing that result yeilds the original packed value.
        /// </summary>
        [Test]
        public void TestRandomValues_i()
        {
            var rand = new System.Random();
            var buff = new Byte[8];

            for(Int32 i = 0; i < Settings.NumTests; ++i)
            {
                rand.NextBytes(buff);
                UInt64 packed = BitConverter.ToUInt64(buff, 0);
                var packedObj = new Short4();
                packedObj.PackedValue = packed;
                Single realX, realY, realZ, realW = 0f;
                packedObj.UnpackTo(out realX, out realY, out realZ, out realW);
                var newPackedObj = new Short4(realX, realY, realZ, realW);
                Assert.That(newPackedObj.PackedValue, Is.EqualTo(packedObj.PackedValue));
            }
        }

        /// <summary>
        /// For a given example, this test ensures that the ToString function
        /// yields the expected string.
        /// </summary>
        [Test]
        public void TestMemberFn_ToString_i()
        {
            var testCase = new Short4 ();
            testCase.PackFrom (0.656f, 0.125f, 0.222f, 0.861f);
            String s = testCase.ToString ();
            Assert.That(s, Is.EqualTo ("1000000000001"));
        }

        /// <summary>
        /// Makes sure that the hashing function is good by testing
        /// random scenarios and ensuring that there are no more than a
        /// reasonable number of collisions.
        /// </summary>
        [Test]
        public void TestMemberFn_GetHashCode_i ()
        {
            HashSet<Int32> hs = new HashSet<Int32>();
            var rand = new System.Random();
            var buff = new Byte[8];
            UInt32 collisions = 0;
            for(Int32 i = 0; i < Settings.NumTests; ++i)
            {
                rand.NextBytes(buff);
                UInt64 packed = BitConverter.ToUInt64(buff, 0);
                var packedObj = new Short4();
                packedObj.PackedValue = packed;
                Int32 hc = packedObj.GetHashCode ();
                if(hs.Contains(hc)) ++collisions;
                hs.Add(hc);
            }
            Assert.That(collisions, Is.LessThan(10));
        }
    }

}
