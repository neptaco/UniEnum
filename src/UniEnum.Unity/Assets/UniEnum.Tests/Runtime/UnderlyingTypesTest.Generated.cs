using System;
using NUnit.Framework;
using UniEnumUtils;

namespace UniEnumTests
{
    public enum SbyteEnum_S1_1 : sbyte
    {
        Type1 = 1, Type2 = 2, Type3 = 3, Type4 = 4, Type5 = 5, Type6 = 6, Type7 = 7, Type8 = 8, Type9 = 9, Type10 = 10, Type11 = 11, Type12 = 12, Type13 = 13, Type14 = 14, Type15 = 15, Type16 = 16, Type17 = 17, Type18 = 18, Type19 = 19, Type20 = 20, Type21 = 21, Type22 = 22, Type23 = 23, Type24 = 24, Type25 = 25, Type26 = 26, Type27 = 27, Type28 = 28, Type29 = 29, Type30 = 30, Type31 = 31, Type32 = 32
    }

    public class SbyteEnum_S1_1Test
    {
        [Test]
        public void SbyteEnum_S1_1_MinMaxTest()
        {
            Assert.AreEqual(SbyteEnum_S1_1.Type1, UniEnum.GetMinValue<SbyteEnum_S1_1>());
            Assert.AreEqual(SbyteEnum_S1_1.Type32, UniEnum.GetMaxValue<SbyteEnum_S1_1>());
        }

        [Test]
        public void SbyteEnum_S1_1_IsDefineTest()
        {
            Assert.AreEqual(true, UniEnum.IsDefined<SbyteEnum_S1_1>((sbyte)1));
            Assert.AreEqual(true, UniEnum.IsDefined<SbyteEnum_S1_1>((sbyte)2));
            Assert.AreEqual(false, UniEnum.IsDefined<SbyteEnum_S1_1>((sbyte)-1));
            Assert.AreEqual(false, UniEnum.IsDefined<SbyteEnum_S1_1>((sbyte)33));

            var type1 = (SbyteEnum_S1_1)Enum.ToObject(typeof(SbyteEnum_S1_1), 1);
            var unknown = (SbyteEnum_S1_1)Enum.ToObject(typeof(SbyteEnum_S1_1), -1);
            Assert.AreEqual(true, UniEnum.IsDefined(type1));
            Assert.AreEqual(false, UniEnum.IsDefined(unknown));
            
            Assert.AreEqual(true, UniEnum.IsDefined<SbyteEnum_S1_1>(SbyteEnum_S1_1.Type1 | SbyteEnum_S1_1.Type2));            
        }

        [Test] 
        public void SbyteEnum_S1_1_TryParseTest() 
        {
            SbyteEnum_S1_1 value;
            bool result;
            
            result = UniEnum.TryParse("1", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(SbyteEnum_S1_1.Type1, value);

            result = UniEnum.TryParse("+1", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(SbyteEnum_S1_1.Type1, value);

            result = UniEnum.TryParse("2", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(SbyteEnum_S1_1.Type2, value);

            result = UniEnum.TryParse("-1", out value);
            Assert.AreEqual(true, result);

            
            result = UniEnum.TryParse("type1", out value);
            Assert.AreEqual(false, result);

            result = UniEnum.TryParse("type1", true, out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(SbyteEnum_S1_1.Type1, value);

            result = UniEnum.TryParse("Type1", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(SbyteEnum_S1_1.Type1, value);
            
            result = UniEnum.TryParse("Type1", false, out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(SbyteEnum_S1_1.Type1, value);
            
            result = UniEnum.TryParse("type0", out value);
            Assert.AreEqual(false, result);

        }
    }

    public enum ByteEnum_S1_1 : byte
    {
        Type1 = 1, Type2 = 2, Type3 = 3, Type4 = 4, Type5 = 5, Type6 = 6, Type7 = 7, Type8 = 8, Type9 = 9, Type10 = 10, Type11 = 11, Type12 = 12, Type13 = 13, Type14 = 14, Type15 = 15, Type16 = 16, Type17 = 17, Type18 = 18, Type19 = 19, Type20 = 20, Type21 = 21, Type22 = 22, Type23 = 23, Type24 = 24, Type25 = 25, Type26 = 26, Type27 = 27, Type28 = 28, Type29 = 29, Type30 = 30, Type31 = 31, Type32 = 32
    }

    public class ByteEnum_S1_1Test
    {
        [Test]
        public void ByteEnum_S1_1_MinMaxTest()
        {
            Assert.AreEqual(ByteEnum_S1_1.Type1, UniEnum.GetMinValue<ByteEnum_S1_1>());
            Assert.AreEqual(ByteEnum_S1_1.Type32, UniEnum.GetMaxValue<ByteEnum_S1_1>());
        }

        [Test]
        public void ByteEnum_S1_1_IsDefineTest()
        {
            Assert.AreEqual(true, UniEnum.IsDefined<ByteEnum_S1_1>((byte)1));
            Assert.AreEqual(true, UniEnum.IsDefined<ByteEnum_S1_1>((byte)2));
            //Assert.AreEqual(false, UniEnum.IsDefined<ByteEnum_S1_1>((byte)-1));
            Assert.AreEqual(false, UniEnum.IsDefined<ByteEnum_S1_1>((byte)33));

            var type1 = (ByteEnum_S1_1)Enum.ToObject(typeof(ByteEnum_S1_1), 1);
            var unknown = (ByteEnum_S1_1)Enum.ToObject(typeof(ByteEnum_S1_1), -1);
            Assert.AreEqual(true, UniEnum.IsDefined(type1));
            Assert.AreEqual(false, UniEnum.IsDefined(unknown));
            
            Assert.AreEqual(true, UniEnum.IsDefined<ByteEnum_S1_1>(ByteEnum_S1_1.Type1 | ByteEnum_S1_1.Type2));            
        }

        [Test] 
        public void ByteEnum_S1_1_TryParseTest() 
        {
            ByteEnum_S1_1 value;
            bool result;
            
            result = UniEnum.TryParse("1", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(ByteEnum_S1_1.Type1, value);

            result = UniEnum.TryParse("+1", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(ByteEnum_S1_1.Type1, value);

            result = UniEnum.TryParse("2", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(ByteEnum_S1_1.Type2, value);

            result = UniEnum.TryParse("-1", out value);
            Assert.AreEqual(false, result);

            
            result = UniEnum.TryParse("type1", out value);
            Assert.AreEqual(false, result);

            result = UniEnum.TryParse("type1", true, out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(ByteEnum_S1_1.Type1, value);

            result = UniEnum.TryParse("Type1", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(ByteEnum_S1_1.Type1, value);
            
            result = UniEnum.TryParse("Type1", false, out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(ByteEnum_S1_1.Type1, value);
            
            result = UniEnum.TryParse("type0", out value);
            Assert.AreEqual(false, result);

        }
    }

    public enum ShortEnum_S1_1 : short
    {
        Type1 = 1, Type2 = 2, Type3 = 3, Type4 = 4, Type5 = 5, Type6 = 6, Type7 = 7, Type8 = 8, Type9 = 9, Type10 = 10, Type11 = 11, Type12 = 12, Type13 = 13, Type14 = 14, Type15 = 15, Type16 = 16, Type17 = 17, Type18 = 18, Type19 = 19, Type20 = 20, Type21 = 21, Type22 = 22, Type23 = 23, Type24 = 24, Type25 = 25, Type26 = 26, Type27 = 27, Type28 = 28, Type29 = 29, Type30 = 30, Type31 = 31, Type32 = 32
    }

    public class ShortEnum_S1_1Test
    {
        [Test]
        public void ShortEnum_S1_1_MinMaxTest()
        {
            Assert.AreEqual(ShortEnum_S1_1.Type1, UniEnum.GetMinValue<ShortEnum_S1_1>());
            Assert.AreEqual(ShortEnum_S1_1.Type32, UniEnum.GetMaxValue<ShortEnum_S1_1>());
        }

        [Test]
        public void ShortEnum_S1_1_IsDefineTest()
        {
            Assert.AreEqual(true, UniEnum.IsDefined<ShortEnum_S1_1>((short)1));
            Assert.AreEqual(true, UniEnum.IsDefined<ShortEnum_S1_1>((short)2));
            Assert.AreEqual(false, UniEnum.IsDefined<ShortEnum_S1_1>((short)-1));
            Assert.AreEqual(false, UniEnum.IsDefined<ShortEnum_S1_1>((short)33));

            var type1 = (ShortEnum_S1_1)Enum.ToObject(typeof(ShortEnum_S1_1), 1);
            var unknown = (ShortEnum_S1_1)Enum.ToObject(typeof(ShortEnum_S1_1), -1);
            Assert.AreEqual(true, UniEnum.IsDefined(type1));
            Assert.AreEqual(false, UniEnum.IsDefined(unknown));
            
            Assert.AreEqual(true, UniEnum.IsDefined<ShortEnum_S1_1>(ShortEnum_S1_1.Type1 | ShortEnum_S1_1.Type2));            
        }

        [Test] 
        public void ShortEnum_S1_1_TryParseTest() 
        {
            ShortEnum_S1_1 value;
            bool result;
            
            result = UniEnum.TryParse("1", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(ShortEnum_S1_1.Type1, value);

            result = UniEnum.TryParse("+1", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(ShortEnum_S1_1.Type1, value);

            result = UniEnum.TryParse("2", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(ShortEnum_S1_1.Type2, value);

            result = UniEnum.TryParse("-1", out value);
            Assert.AreEqual(true, result);

            
            result = UniEnum.TryParse("type1", out value);
            Assert.AreEqual(false, result);

            result = UniEnum.TryParse("type1", true, out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(ShortEnum_S1_1.Type1, value);

            result = UniEnum.TryParse("Type1", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(ShortEnum_S1_1.Type1, value);
            
            result = UniEnum.TryParse("Type1", false, out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(ShortEnum_S1_1.Type1, value);
            
            result = UniEnum.TryParse("type0", out value);
            Assert.AreEqual(false, result);

        }
    }

    public enum UshortEnum_S1_1 : ushort
    {
        Type1 = 1, Type2 = 2, Type3 = 3, Type4 = 4, Type5 = 5, Type6 = 6, Type7 = 7, Type8 = 8, Type9 = 9, Type10 = 10, Type11 = 11, Type12 = 12, Type13 = 13, Type14 = 14, Type15 = 15, Type16 = 16, Type17 = 17, Type18 = 18, Type19 = 19, Type20 = 20, Type21 = 21, Type22 = 22, Type23 = 23, Type24 = 24, Type25 = 25, Type26 = 26, Type27 = 27, Type28 = 28, Type29 = 29, Type30 = 30, Type31 = 31, Type32 = 32
    }

    public class UshortEnum_S1_1Test
    {
        [Test]
        public void UshortEnum_S1_1_MinMaxTest()
        {
            Assert.AreEqual(UshortEnum_S1_1.Type1, UniEnum.GetMinValue<UshortEnum_S1_1>());
            Assert.AreEqual(UshortEnum_S1_1.Type32, UniEnum.GetMaxValue<UshortEnum_S1_1>());
        }

        [Test]
        public void UshortEnum_S1_1_IsDefineTest()
        {
            Assert.AreEqual(true, UniEnum.IsDefined<UshortEnum_S1_1>((ushort)1));
            Assert.AreEqual(true, UniEnum.IsDefined<UshortEnum_S1_1>((ushort)2));
            //Assert.AreEqual(false, UniEnum.IsDefined<UshortEnum_S1_1>((ushort)-1));
            Assert.AreEqual(false, UniEnum.IsDefined<UshortEnum_S1_1>((ushort)33));

            var type1 = (UshortEnum_S1_1)Enum.ToObject(typeof(UshortEnum_S1_1), 1);
            var unknown = (UshortEnum_S1_1)Enum.ToObject(typeof(UshortEnum_S1_1), -1);
            Assert.AreEqual(true, UniEnum.IsDefined(type1));
            Assert.AreEqual(false, UniEnum.IsDefined(unknown));
            
            Assert.AreEqual(true, UniEnum.IsDefined<UshortEnum_S1_1>(UshortEnum_S1_1.Type1 | UshortEnum_S1_1.Type2));            
        }

        [Test] 
        public void UshortEnum_S1_1_TryParseTest() 
        {
            UshortEnum_S1_1 value;
            bool result;
            
            result = UniEnum.TryParse("1", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(UshortEnum_S1_1.Type1, value);

            result = UniEnum.TryParse("+1", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(UshortEnum_S1_1.Type1, value);

            result = UniEnum.TryParse("2", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(UshortEnum_S1_1.Type2, value);

            result = UniEnum.TryParse("-1", out value);
            Assert.AreEqual(false, result);

            
            result = UniEnum.TryParse("type1", out value);
            Assert.AreEqual(false, result);

            result = UniEnum.TryParse("type1", true, out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(UshortEnum_S1_1.Type1, value);

            result = UniEnum.TryParse("Type1", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(UshortEnum_S1_1.Type1, value);
            
            result = UniEnum.TryParse("Type1", false, out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(UshortEnum_S1_1.Type1, value);
            
            result = UniEnum.TryParse("type0", out value);
            Assert.AreEqual(false, result);

        }
    }

    public enum IntEnum_S1_1 : int
    {
        Type1 = 1, Type2 = 2, Type3 = 3, Type4 = 4, Type5 = 5, Type6 = 6, Type7 = 7, Type8 = 8, Type9 = 9, Type10 = 10, Type11 = 11, Type12 = 12, Type13 = 13, Type14 = 14, Type15 = 15, Type16 = 16, Type17 = 17, Type18 = 18, Type19 = 19, Type20 = 20, Type21 = 21, Type22 = 22, Type23 = 23, Type24 = 24, Type25 = 25, Type26 = 26, Type27 = 27, Type28 = 28, Type29 = 29, Type30 = 30, Type31 = 31, Type32 = 32
    }

    public class IntEnum_S1_1Test
    {
        [Test]
        public void IntEnum_S1_1_MinMaxTest()
        {
            Assert.AreEqual(IntEnum_S1_1.Type1, UniEnum.GetMinValue<IntEnum_S1_1>());
            Assert.AreEqual(IntEnum_S1_1.Type32, UniEnum.GetMaxValue<IntEnum_S1_1>());
        }

        [Test]
        public void IntEnum_S1_1_IsDefineTest()
        {
            Assert.AreEqual(true, UniEnum.IsDefined<IntEnum_S1_1>((int)1));
            Assert.AreEqual(true, UniEnum.IsDefined<IntEnum_S1_1>((int)2));
            Assert.AreEqual(false, UniEnum.IsDefined<IntEnum_S1_1>((int)-1));
            Assert.AreEqual(false, UniEnum.IsDefined<IntEnum_S1_1>((int)33));

            var type1 = (IntEnum_S1_1)Enum.ToObject(typeof(IntEnum_S1_1), 1);
            var unknown = (IntEnum_S1_1)Enum.ToObject(typeof(IntEnum_S1_1), -1);
            Assert.AreEqual(true, UniEnum.IsDefined(type1));
            Assert.AreEqual(false, UniEnum.IsDefined(unknown));
            
            Assert.AreEqual(true, UniEnum.IsDefined<IntEnum_S1_1>(IntEnum_S1_1.Type1 | IntEnum_S1_1.Type2));            
        }

        [Test] 
        public void IntEnum_S1_1_TryParseTest() 
        {
            IntEnum_S1_1 value;
            bool result;
            
            result = UniEnum.TryParse("1", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(IntEnum_S1_1.Type1, value);

            result = UniEnum.TryParse("+1", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(IntEnum_S1_1.Type1, value);

            result = UniEnum.TryParse("2", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(IntEnum_S1_1.Type2, value);

            result = UniEnum.TryParse("-1", out value);
            Assert.AreEqual(true, result);

            
            result = UniEnum.TryParse("type1", out value);
            Assert.AreEqual(false, result);

            result = UniEnum.TryParse("type1", true, out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(IntEnum_S1_1.Type1, value);

            result = UniEnum.TryParse("Type1", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(IntEnum_S1_1.Type1, value);
            
            result = UniEnum.TryParse("Type1", false, out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(IntEnum_S1_1.Type1, value);
            
            result = UniEnum.TryParse("type0", out value);
            Assert.AreEqual(false, result);

        }
    }

    public enum Int2Enum_S1_2 : int
    {
        Type1 = 1, Type2 = 3, Type3 = 5, Type4 = 7, Type5 = 9, Type6 = 11, Type7 = 13, Type8 = 15, Type9 = 17, Type10 = 19, Type11 = 21, Type12 = 23, Type13 = 25, Type14 = 27, Type15 = 29, Type16 = 31, Type17 = 33, Type18 = 35, Type19 = 37, Type20 = 39, Type21 = 41, Type22 = 43, Type23 = 45, Type24 = 47, Type25 = 49, Type26 = 51, Type27 = 53, Type28 = 55, Type29 = 57, Type30 = 59, Type31 = 61, Type32 = 63
    }

    public class Int2Enum_S1_2Test
    {
        [Test]
        public void Int2Enum_S1_2_MinMaxTest()
        {
            Assert.AreEqual(Int2Enum_S1_2.Type1, UniEnum.GetMinValue<Int2Enum_S1_2>());
            Assert.AreEqual(Int2Enum_S1_2.Type32, UniEnum.GetMaxValue<Int2Enum_S1_2>());
        }

        [Test]
        public void Int2Enum_S1_2_IsDefineTest()
        {
            Assert.AreEqual(true, UniEnum.IsDefined<Int2Enum_S1_2>((int)1));
            Assert.AreEqual(true, UniEnum.IsDefined<Int2Enum_S1_2>((int)3));
            Assert.AreEqual(false, UniEnum.IsDefined<Int2Enum_S1_2>((int)-1));
            Assert.AreEqual(false, UniEnum.IsDefined<Int2Enum_S1_2>((int)65));

            var type1 = (Int2Enum_S1_2)Enum.ToObject(typeof(Int2Enum_S1_2), 1);
            var unknown = (Int2Enum_S1_2)Enum.ToObject(typeof(Int2Enum_S1_2), -1);
            Assert.AreEqual(true, UniEnum.IsDefined(type1));
            Assert.AreEqual(false, UniEnum.IsDefined(unknown));
            
            Assert.AreEqual(true, UniEnum.IsDefined<Int2Enum_S1_2>(Int2Enum_S1_2.Type1 | Int2Enum_S1_2.Type2));            
        }

        [Test] 
        public void Int2Enum_S1_2_TryParseTest() 
        {
            Int2Enum_S1_2 value;
            bool result;
            
            result = UniEnum.TryParse("1", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(Int2Enum_S1_2.Type1, value);

            result = UniEnum.TryParse("+1", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(Int2Enum_S1_2.Type1, value);

            result = UniEnum.TryParse("3", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(Int2Enum_S1_2.Type2, value);

            result = UniEnum.TryParse("-1", out value);
            Assert.AreEqual(true, result);

            
            result = UniEnum.TryParse("type1", out value);
            Assert.AreEqual(false, result);

            result = UniEnum.TryParse("type1", true, out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(Int2Enum_S1_2.Type1, value);

            result = UniEnum.TryParse("Type1", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(Int2Enum_S1_2.Type1, value);
            
            result = UniEnum.TryParse("Type1", false, out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(Int2Enum_S1_2.Type1, value);
            
            result = UniEnum.TryParse("type0", out value);
            Assert.AreEqual(false, result);

        }
    }

    public enum UintEnum_S1_1 : uint
    {
        Type1 = 1, Type2 = 2, Type3 = 3, Type4 = 4, Type5 = 5, Type6 = 6, Type7 = 7, Type8 = 8, Type9 = 9, Type10 = 10, Type11 = 11, Type12 = 12, Type13 = 13, Type14 = 14, Type15 = 15, Type16 = 16, Type17 = 17, Type18 = 18, Type19 = 19, Type20 = 20, Type21 = 21, Type22 = 22, Type23 = 23, Type24 = 24, Type25 = 25, Type26 = 26, Type27 = 27, Type28 = 28, Type29 = 29, Type30 = 30, Type31 = 31, Type32 = 32
    }

    public class UintEnum_S1_1Test
    {
        [Test]
        public void UintEnum_S1_1_MinMaxTest()
        {
            Assert.AreEqual(UintEnum_S1_1.Type1, UniEnum.GetMinValue<UintEnum_S1_1>());
            Assert.AreEqual(UintEnum_S1_1.Type32, UniEnum.GetMaxValue<UintEnum_S1_1>());
        }

        [Test]
        public void UintEnum_S1_1_IsDefineTest()
        {
            Assert.AreEqual(true, UniEnum.IsDefined<UintEnum_S1_1>((uint)1));
            Assert.AreEqual(true, UniEnum.IsDefined<UintEnum_S1_1>((uint)2));
            //Assert.AreEqual(false, UniEnum.IsDefined<UintEnum_S1_1>((uint)-1));
            Assert.AreEqual(false, UniEnum.IsDefined<UintEnum_S1_1>((uint)33));

            var type1 = (UintEnum_S1_1)Enum.ToObject(typeof(UintEnum_S1_1), 1);
            var unknown = (UintEnum_S1_1)Enum.ToObject(typeof(UintEnum_S1_1), -1);
            Assert.AreEqual(true, UniEnum.IsDefined(type1));
            Assert.AreEqual(false, UniEnum.IsDefined(unknown));
            
            Assert.AreEqual(true, UniEnum.IsDefined<UintEnum_S1_1>(UintEnum_S1_1.Type1 | UintEnum_S1_1.Type2));            
        }

        [Test] 
        public void UintEnum_S1_1_TryParseTest() 
        {
            UintEnum_S1_1 value;
            bool result;
            
            result = UniEnum.TryParse("1", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(UintEnum_S1_1.Type1, value);

            result = UniEnum.TryParse("+1", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(UintEnum_S1_1.Type1, value);

            result = UniEnum.TryParse("2", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(UintEnum_S1_1.Type2, value);

            result = UniEnum.TryParse("-1", out value);
            Assert.AreEqual(false, result);

            
            result = UniEnum.TryParse("type1", out value);
            Assert.AreEqual(false, result);

            result = UniEnum.TryParse("type1", true, out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(UintEnum_S1_1.Type1, value);

            result = UniEnum.TryParse("Type1", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(UintEnum_S1_1.Type1, value);
            
            result = UniEnum.TryParse("Type1", false, out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(UintEnum_S1_1.Type1, value);
            
            result = UniEnum.TryParse("type0", out value);
            Assert.AreEqual(false, result);

        }
    }

    public enum LongEnum_S1_1 : long
    {
        Type1 = 1, Type2 = 2, Type3 = 3, Type4 = 4, Type5 = 5, Type6 = 6, Type7 = 7, Type8 = 8, Type9 = 9, Type10 = 10, Type11 = 11, Type12 = 12, Type13 = 13, Type14 = 14, Type15 = 15, Type16 = 16, Type17 = 17, Type18 = 18, Type19 = 19, Type20 = 20, Type21 = 21, Type22 = 22, Type23 = 23, Type24 = 24, Type25 = 25, Type26 = 26, Type27 = 27, Type28 = 28, Type29 = 29, Type30 = 30, Type31 = 31, Type32 = 32
    }

    public class LongEnum_S1_1Test
    {
        [Test]
        public void LongEnum_S1_1_MinMaxTest()
        {
            Assert.AreEqual(LongEnum_S1_1.Type1, UniEnum.GetMinValue<LongEnum_S1_1>());
            Assert.AreEqual(LongEnum_S1_1.Type32, UniEnum.GetMaxValue<LongEnum_S1_1>());
        }

        [Test]
        public void LongEnum_S1_1_IsDefineTest()
        {
            Assert.AreEqual(true, UniEnum.IsDefined<LongEnum_S1_1>((long)1));
            Assert.AreEqual(true, UniEnum.IsDefined<LongEnum_S1_1>((long)2));
            Assert.AreEqual(false, UniEnum.IsDefined<LongEnum_S1_1>((long)-1));
            Assert.AreEqual(false, UniEnum.IsDefined<LongEnum_S1_1>((long)33));

            var type1 = (LongEnum_S1_1)Enum.ToObject(typeof(LongEnum_S1_1), 1);
            var unknown = (LongEnum_S1_1)Enum.ToObject(typeof(LongEnum_S1_1), -1);
            Assert.AreEqual(true, UniEnum.IsDefined(type1));
            Assert.AreEqual(false, UniEnum.IsDefined(unknown));
            
            Assert.AreEqual(true, UniEnum.IsDefined<LongEnum_S1_1>(LongEnum_S1_1.Type1 | LongEnum_S1_1.Type2));            
        }

        [Test] 
        public void LongEnum_S1_1_TryParseTest() 
        {
            LongEnum_S1_1 value;
            bool result;
            
            result = UniEnum.TryParse("1", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(LongEnum_S1_1.Type1, value);

            result = UniEnum.TryParse("+1", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(LongEnum_S1_1.Type1, value);

            result = UniEnum.TryParse("2", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(LongEnum_S1_1.Type2, value);

            result = UniEnum.TryParse("-1", out value);
            Assert.AreEqual(true, result);

            
            result = UniEnum.TryParse("type1", out value);
            Assert.AreEqual(false, result);

            result = UniEnum.TryParse("type1", true, out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(LongEnum_S1_1.Type1, value);

            result = UniEnum.TryParse("Type1", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(LongEnum_S1_1.Type1, value);
            
            result = UniEnum.TryParse("Type1", false, out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(LongEnum_S1_1.Type1, value);
            
            result = UniEnum.TryParse("type0", out value);
            Assert.AreEqual(false, result);

        }
    }

    public enum UlongEnum_S1_1 : ulong
    {
        Type1 = 1, Type2 = 2, Type3 = 3, Type4 = 4, Type5 = 5, Type6 = 6, Type7 = 7, Type8 = 8, Type9 = 9, Type10 = 10, Type11 = 11, Type12 = 12, Type13 = 13, Type14 = 14, Type15 = 15, Type16 = 16, Type17 = 17, Type18 = 18, Type19 = 19, Type20 = 20, Type21 = 21, Type22 = 22, Type23 = 23, Type24 = 24, Type25 = 25, Type26 = 26, Type27 = 27, Type28 = 28, Type29 = 29, Type30 = 30, Type31 = 31, Type32 = 32
    }

    public class UlongEnum_S1_1Test
    {
        [Test]
        public void UlongEnum_S1_1_MinMaxTest()
        {
            Assert.AreEqual(UlongEnum_S1_1.Type1, UniEnum.GetMinValue<UlongEnum_S1_1>());
            Assert.AreEqual(UlongEnum_S1_1.Type32, UniEnum.GetMaxValue<UlongEnum_S1_1>());
        }

        [Test]
        public void UlongEnum_S1_1_IsDefineTest()
        {
            Assert.AreEqual(true, UniEnum.IsDefined<UlongEnum_S1_1>((ulong)1));
            Assert.AreEqual(true, UniEnum.IsDefined<UlongEnum_S1_1>((ulong)2));
            //Assert.AreEqual(false, UniEnum.IsDefined<UlongEnum_S1_1>((ulong)-1));
            Assert.AreEqual(false, UniEnum.IsDefined<UlongEnum_S1_1>((ulong)33));

            var type1 = (UlongEnum_S1_1)Enum.ToObject(typeof(UlongEnum_S1_1), 1);
            var unknown = (UlongEnum_S1_1)Enum.ToObject(typeof(UlongEnum_S1_1), -1);
            Assert.AreEqual(true, UniEnum.IsDefined(type1));
            Assert.AreEqual(false, UniEnum.IsDefined(unknown));
            
            Assert.AreEqual(true, UniEnum.IsDefined<UlongEnum_S1_1>(UlongEnum_S1_1.Type1 | UlongEnum_S1_1.Type2));            
        }

        [Test] 
        public void UlongEnum_S1_1_TryParseTest() 
        {
            UlongEnum_S1_1 value;
            bool result;
            
            result = UniEnum.TryParse("1", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(UlongEnum_S1_1.Type1, value);

            result = UniEnum.TryParse("+1", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(UlongEnum_S1_1.Type1, value);

            result = UniEnum.TryParse("2", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(UlongEnum_S1_1.Type2, value);

            result = UniEnum.TryParse("-1", out value);
            Assert.AreEqual(false, result);

            
            result = UniEnum.TryParse("type1", out value);
            Assert.AreEqual(false, result);

            result = UniEnum.TryParse("type1", true, out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(UlongEnum_S1_1.Type1, value);

            result = UniEnum.TryParse("Type1", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(UlongEnum_S1_1.Type1, value);
            
            result = UniEnum.TryParse("Type1", false, out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(UlongEnum_S1_1.Type1, value);
            
            result = UniEnum.TryParse("type0", out value);
            Assert.AreEqual(false, result);

        }
    }

}

