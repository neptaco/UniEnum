using System;
using NUnit.Framework;
using UniEnumUtils;

namespace UniEnumTests
{
    public enum SbyteEnum : sbyte
    {
        Type1 = 1, Type2 = 2, Type3 = 3, Type4 = 4, Type5 = 5, Type6 = 6, Type7 = 7, Type8 = 8, Type9 = 9, Type10 = 10, Type11 = 11, Type12 = 12, Type13 = 13, Type14 = 14, Type15 = 15, Type16 = 16, Type17 = 17, Type18 = 18, Type19 = 19, Type20 = 20, Type21 = 21, Type22 = 22, Type23 = 23, Type24 = 24, Type25 = 25, Type26 = 26, Type27 = 27, Type28 = 28, Type29 = 29, Type30 = 30, Type31 = 31, Type32 = 32
    }

    public class SbyteEnumTest
    {
        [Test]
        public void SbyteEnumIsDefineTest()
        {
            Assert.AreEqual(true, UniEnum.IsDefined<SbyteEnum>((sbyte)1));
            Assert.AreEqual(true, UniEnum.IsDefined<SbyteEnum>((sbyte)2));
            Assert.AreEqual(false, UniEnum.IsDefined<SbyteEnum>((sbyte)-1));
            Assert.AreEqual(false, UniEnum.IsDefined<SbyteEnum>((sbyte)33));

            var type1 = (SbyteEnum)Enum.ToObject(typeof(SbyteEnum), 1);
            var unknown = (SbyteEnum)Enum.ToObject(typeof(SbyteEnum), -1);
            Assert.AreEqual(true, UniEnum.IsDefined(type1));
            Assert.AreEqual(false, UniEnum.IsDefined(unknown));
            
            Assert.AreEqual(true, UniEnum.IsDefined<SbyteEnum>(SbyteEnum.Type1 | SbyteEnum.Type2));
            
        }

        [Test] 
        public void SbyteEnumTryParseTest() 
        {
            SbyteEnum value;
            bool result;
            
            result = UniEnum.TryParse("1", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(SbyteEnum.Type1, value);

            result = UniEnum.TryParse("+1", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(SbyteEnum.Type1, value);

            result = UniEnum.TryParse("2", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(SbyteEnum.Type2, value);

            result = UniEnum.TryParse("-1", out value);
            Assert.AreEqual(true, result);

            
            result = UniEnum.TryParse("type1", out value);
            Assert.AreEqual(false, result);

            result = UniEnum.TryParse("type1", true, out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(SbyteEnum.Type1, value);

            result = UniEnum.TryParse("Type1", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(SbyteEnum.Type1, value);
            
            result = UniEnum.TryParse("Type1", false, out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(SbyteEnum.Type1, value);
            
            result = UniEnum.TryParse("type0", out value);
            Assert.AreEqual(false, result);

        }
    }

    public enum ByteEnum : byte
    {
        Type1 = 1, Type2 = 2, Type3 = 3, Type4 = 4, Type5 = 5, Type6 = 6, Type7 = 7, Type8 = 8, Type9 = 9, Type10 = 10, Type11 = 11, Type12 = 12, Type13 = 13, Type14 = 14, Type15 = 15, Type16 = 16, Type17 = 17, Type18 = 18, Type19 = 19, Type20 = 20, Type21 = 21, Type22 = 22, Type23 = 23, Type24 = 24, Type25 = 25, Type26 = 26, Type27 = 27, Type28 = 28, Type29 = 29, Type30 = 30, Type31 = 31, Type32 = 32
    }

    public class ByteEnumTest
    {
        [Test]
        public void ByteEnumIsDefineTest()
        {
            Assert.AreEqual(true, UniEnum.IsDefined<ByteEnum>((byte)1));
            Assert.AreEqual(true, UniEnum.IsDefined<ByteEnum>((byte)2));
            //Assert.AreEqual(false, UniEnum.IsDefined<ByteEnum>((byte)-1));
            Assert.AreEqual(false, UniEnum.IsDefined<ByteEnum>((byte)33));

            var type1 = (ByteEnum)Enum.ToObject(typeof(ByteEnum), 1);
            var unknown = (ByteEnum)Enum.ToObject(typeof(ByteEnum), -1);
            Assert.AreEqual(true, UniEnum.IsDefined(type1));
            Assert.AreEqual(false, UniEnum.IsDefined(unknown));
            
            Assert.AreEqual(true, UniEnum.IsDefined<ByteEnum>(ByteEnum.Type1 | ByteEnum.Type2));
            
        }

        [Test] 
        public void ByteEnumTryParseTest() 
        {
            ByteEnum value;
            bool result;
            
            result = UniEnum.TryParse("1", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(ByteEnum.Type1, value);

            result = UniEnum.TryParse("+1", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(ByteEnum.Type1, value);

            result = UniEnum.TryParse("2", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(ByteEnum.Type2, value);

            result = UniEnum.TryParse("-1", out value);
            Assert.AreEqual(false, result);

            
            result = UniEnum.TryParse("type1", out value);
            Assert.AreEqual(false, result);

            result = UniEnum.TryParse("type1", true, out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(ByteEnum.Type1, value);

            result = UniEnum.TryParse("Type1", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(ByteEnum.Type1, value);
            
            result = UniEnum.TryParse("Type1", false, out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(ByteEnum.Type1, value);
            
            result = UniEnum.TryParse("type0", out value);
            Assert.AreEqual(false, result);

        }
    }

    public enum ShortEnum : short
    {
        Type1 = 1, Type2 = 2, Type3 = 3, Type4 = 4, Type5 = 5, Type6 = 6, Type7 = 7, Type8 = 8, Type9 = 9, Type10 = 10, Type11 = 11, Type12 = 12, Type13 = 13, Type14 = 14, Type15 = 15, Type16 = 16, Type17 = 17, Type18 = 18, Type19 = 19, Type20 = 20, Type21 = 21, Type22 = 22, Type23 = 23, Type24 = 24, Type25 = 25, Type26 = 26, Type27 = 27, Type28 = 28, Type29 = 29, Type30 = 30, Type31 = 31, Type32 = 32
    }

    public class ShortEnumTest
    {
        [Test]
        public void ShortEnumIsDefineTest()
        {
            Assert.AreEqual(true, UniEnum.IsDefined<ShortEnum>((short)1));
            Assert.AreEqual(true, UniEnum.IsDefined<ShortEnum>((short)2));
            Assert.AreEqual(false, UniEnum.IsDefined<ShortEnum>((short)-1));
            Assert.AreEqual(false, UniEnum.IsDefined<ShortEnum>((short)33));

            var type1 = (ShortEnum)Enum.ToObject(typeof(ShortEnum), 1);
            var unknown = (ShortEnum)Enum.ToObject(typeof(ShortEnum), -1);
            Assert.AreEqual(true, UniEnum.IsDefined(type1));
            Assert.AreEqual(false, UniEnum.IsDefined(unknown));
            
            Assert.AreEqual(true, UniEnum.IsDefined<ShortEnum>(ShortEnum.Type1 | ShortEnum.Type2));
            
        }

        [Test] 
        public void ShortEnumTryParseTest() 
        {
            ShortEnum value;
            bool result;
            
            result = UniEnum.TryParse("1", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(ShortEnum.Type1, value);

            result = UniEnum.TryParse("+1", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(ShortEnum.Type1, value);

            result = UniEnum.TryParse("2", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(ShortEnum.Type2, value);

            result = UniEnum.TryParse("-1", out value);
            Assert.AreEqual(true, result);

            
            result = UniEnum.TryParse("type1", out value);
            Assert.AreEqual(false, result);

            result = UniEnum.TryParse("type1", true, out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(ShortEnum.Type1, value);

            result = UniEnum.TryParse("Type1", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(ShortEnum.Type1, value);
            
            result = UniEnum.TryParse("Type1", false, out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(ShortEnum.Type1, value);
            
            result = UniEnum.TryParse("type0", out value);
            Assert.AreEqual(false, result);

        }
    }

    public enum UshortEnum : ushort
    {
        Type1 = 1, Type2 = 2, Type3 = 3, Type4 = 4, Type5 = 5, Type6 = 6, Type7 = 7, Type8 = 8, Type9 = 9, Type10 = 10, Type11 = 11, Type12 = 12, Type13 = 13, Type14 = 14, Type15 = 15, Type16 = 16, Type17 = 17, Type18 = 18, Type19 = 19, Type20 = 20, Type21 = 21, Type22 = 22, Type23 = 23, Type24 = 24, Type25 = 25, Type26 = 26, Type27 = 27, Type28 = 28, Type29 = 29, Type30 = 30, Type31 = 31, Type32 = 32
    }

    public class UshortEnumTest
    {
        [Test]
        public void UshortEnumIsDefineTest()
        {
            Assert.AreEqual(true, UniEnum.IsDefined<UshortEnum>((ushort)1));
            Assert.AreEqual(true, UniEnum.IsDefined<UshortEnum>((ushort)2));
            //Assert.AreEqual(false, UniEnum.IsDefined<UshortEnum>((ushort)-1));
            Assert.AreEqual(false, UniEnum.IsDefined<UshortEnum>((ushort)33));

            var type1 = (UshortEnum)Enum.ToObject(typeof(UshortEnum), 1);
            var unknown = (UshortEnum)Enum.ToObject(typeof(UshortEnum), -1);
            Assert.AreEqual(true, UniEnum.IsDefined(type1));
            Assert.AreEqual(false, UniEnum.IsDefined(unknown));
            
            Assert.AreEqual(true, UniEnum.IsDefined<UshortEnum>(UshortEnum.Type1 | UshortEnum.Type2));
            
        }

        [Test] 
        public void UshortEnumTryParseTest() 
        {
            UshortEnum value;
            bool result;
            
            result = UniEnum.TryParse("1", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(UshortEnum.Type1, value);

            result = UniEnum.TryParse("+1", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(UshortEnum.Type1, value);

            result = UniEnum.TryParse("2", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(UshortEnum.Type2, value);

            result = UniEnum.TryParse("-1", out value);
            Assert.AreEqual(false, result);

            
            result = UniEnum.TryParse("type1", out value);
            Assert.AreEqual(false, result);

            result = UniEnum.TryParse("type1", true, out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(UshortEnum.Type1, value);

            result = UniEnum.TryParse("Type1", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(UshortEnum.Type1, value);
            
            result = UniEnum.TryParse("Type1", false, out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(UshortEnum.Type1, value);
            
            result = UniEnum.TryParse("type0", out value);
            Assert.AreEqual(false, result);

        }
    }

    public enum IntEnum : int
    {
        Type1 = 1, Type2 = 2, Type3 = 3, Type4 = 4, Type5 = 5, Type6 = 6, Type7 = 7, Type8 = 8, Type9 = 9, Type10 = 10, Type11 = 11, Type12 = 12, Type13 = 13, Type14 = 14, Type15 = 15, Type16 = 16, Type17 = 17, Type18 = 18, Type19 = 19, Type20 = 20, Type21 = 21, Type22 = 22, Type23 = 23, Type24 = 24, Type25 = 25, Type26 = 26, Type27 = 27, Type28 = 28, Type29 = 29, Type30 = 30, Type31 = 31, Type32 = 32
    }

    public class IntEnumTest
    {
        [Test]
        public void IntEnumIsDefineTest()
        {
            Assert.AreEqual(true, UniEnum.IsDefined<IntEnum>((int)1));
            Assert.AreEqual(true, UniEnum.IsDefined<IntEnum>((int)2));
            Assert.AreEqual(false, UniEnum.IsDefined<IntEnum>((int)-1));
            Assert.AreEqual(false, UniEnum.IsDefined<IntEnum>((int)33));

            var type1 = (IntEnum)Enum.ToObject(typeof(IntEnum), 1);
            var unknown = (IntEnum)Enum.ToObject(typeof(IntEnum), -1);
            Assert.AreEqual(true, UniEnum.IsDefined(type1));
            Assert.AreEqual(false, UniEnum.IsDefined(unknown));
            
            Assert.AreEqual(true, UniEnum.IsDefined<IntEnum>(IntEnum.Type1 | IntEnum.Type2));
            
        }

        [Test] 
        public void IntEnumTryParseTest() 
        {
            IntEnum value;
            bool result;
            
            result = UniEnum.TryParse("1", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(IntEnum.Type1, value);

            result = UniEnum.TryParse("+1", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(IntEnum.Type1, value);

            result = UniEnum.TryParse("2", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(IntEnum.Type2, value);

            result = UniEnum.TryParse("-1", out value);
            Assert.AreEqual(true, result);

            
            result = UniEnum.TryParse("type1", out value);
            Assert.AreEqual(false, result);

            result = UniEnum.TryParse("type1", true, out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(IntEnum.Type1, value);

            result = UniEnum.TryParse("Type1", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(IntEnum.Type1, value);
            
            result = UniEnum.TryParse("Type1", false, out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(IntEnum.Type1, value);
            
            result = UniEnum.TryParse("type0", out value);
            Assert.AreEqual(false, result);

        }
    }

    public enum Int2Enum : int
    {
        Type1 = 2, Type2 = 4, Type3 = 6, Type4 = 8, Type5 = 10, Type6 = 12, Type7 = 14, Type8 = 16, Type9 = 18, Type10 = 20, Type11 = 22, Type12 = 24, Type13 = 26, Type14 = 28, Type15 = 30, Type16 = 32, Type17 = 34, Type18 = 36, Type19 = 38, Type20 = 40, Type21 = 42, Type22 = 44, Type23 = 46, Type24 = 48, Type25 = 50, Type26 = 52, Type27 = 54, Type28 = 56, Type29 = 58, Type30 = 60, Type31 = 62, Type32 = 64
    }

    public class Int2EnumTest
    {
        [Test]
        public void Int2EnumIsDefineTest()
        {
            Assert.AreEqual(true, UniEnum.IsDefined<Int2Enum>((int)2));
            Assert.AreEqual(true, UniEnum.IsDefined<Int2Enum>((int)4));
            Assert.AreEqual(false, UniEnum.IsDefined<Int2Enum>((int)-1));
            Assert.AreEqual(false, UniEnum.IsDefined<Int2Enum>((int)66));

            var type1 = (Int2Enum)Enum.ToObject(typeof(Int2Enum), 2);
            var unknown = (Int2Enum)Enum.ToObject(typeof(Int2Enum), -1);
            Assert.AreEqual(true, UniEnum.IsDefined(type1));
            Assert.AreEqual(false, UniEnum.IsDefined(unknown));
            
            Assert.AreEqual(true, UniEnum.IsDefined<Int2Enum>(Int2Enum.Type1 | Int2Enum.Type2));
            
        }

        [Test] 
        public void Int2EnumTryParseTest() 
        {
            Int2Enum value;
            bool result;
            
            result = UniEnum.TryParse("2", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(Int2Enum.Type1, value);

            result = UniEnum.TryParse("+2", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(Int2Enum.Type1, value);

            result = UniEnum.TryParse("4", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(Int2Enum.Type2, value);

            result = UniEnum.TryParse("-1", out value);
            Assert.AreEqual(true, result);

            
            result = UniEnum.TryParse("type1", out value);
            Assert.AreEqual(false, result);

            result = UniEnum.TryParse("type1", true, out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(Int2Enum.Type1, value);

            result = UniEnum.TryParse("Type1", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(Int2Enum.Type1, value);
            
            result = UniEnum.TryParse("Type1", false, out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(Int2Enum.Type1, value);
            
            result = UniEnum.TryParse("type0", out value);
            Assert.AreEqual(false, result);

        }
    }

    public enum UintEnum : uint
    {
        Type1 = 1, Type2 = 2, Type3 = 3, Type4 = 4, Type5 = 5, Type6 = 6, Type7 = 7, Type8 = 8, Type9 = 9, Type10 = 10, Type11 = 11, Type12 = 12, Type13 = 13, Type14 = 14, Type15 = 15, Type16 = 16, Type17 = 17, Type18 = 18, Type19 = 19, Type20 = 20, Type21 = 21, Type22 = 22, Type23 = 23, Type24 = 24, Type25 = 25, Type26 = 26, Type27 = 27, Type28 = 28, Type29 = 29, Type30 = 30, Type31 = 31, Type32 = 32
    }

    public class UintEnumTest
    {
        [Test]
        public void UintEnumIsDefineTest()
        {
            Assert.AreEqual(true, UniEnum.IsDefined<UintEnum>((uint)1));
            Assert.AreEqual(true, UniEnum.IsDefined<UintEnum>((uint)2));
            //Assert.AreEqual(false, UniEnum.IsDefined<UintEnum>((uint)-1));
            Assert.AreEqual(false, UniEnum.IsDefined<UintEnum>((uint)33));

            var type1 = (UintEnum)Enum.ToObject(typeof(UintEnum), 1);
            var unknown = (UintEnum)Enum.ToObject(typeof(UintEnum), -1);
            Assert.AreEqual(true, UniEnum.IsDefined(type1));
            Assert.AreEqual(false, UniEnum.IsDefined(unknown));
            
            Assert.AreEqual(true, UniEnum.IsDefined<UintEnum>(UintEnum.Type1 | UintEnum.Type2));
            
        }

        [Test] 
        public void UintEnumTryParseTest() 
        {
            UintEnum value;
            bool result;
            
            result = UniEnum.TryParse("1", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(UintEnum.Type1, value);

            result = UniEnum.TryParse("+1", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(UintEnum.Type1, value);

            result = UniEnum.TryParse("2", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(UintEnum.Type2, value);

            result = UniEnum.TryParse("-1", out value);
            Assert.AreEqual(false, result);

            
            result = UniEnum.TryParse("type1", out value);
            Assert.AreEqual(false, result);

            result = UniEnum.TryParse("type1", true, out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(UintEnum.Type1, value);

            result = UniEnum.TryParse("Type1", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(UintEnum.Type1, value);
            
            result = UniEnum.TryParse("Type1", false, out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(UintEnum.Type1, value);
            
            result = UniEnum.TryParse("type0", out value);
            Assert.AreEqual(false, result);

        }
    }

    public enum LongEnum : long
    {
        Type1 = 1, Type2 = 2, Type3 = 3, Type4 = 4, Type5 = 5, Type6 = 6, Type7 = 7, Type8 = 8, Type9 = 9, Type10 = 10, Type11 = 11, Type12 = 12, Type13 = 13, Type14 = 14, Type15 = 15, Type16 = 16, Type17 = 17, Type18 = 18, Type19 = 19, Type20 = 20, Type21 = 21, Type22 = 22, Type23 = 23, Type24 = 24, Type25 = 25, Type26 = 26, Type27 = 27, Type28 = 28, Type29 = 29, Type30 = 30, Type31 = 31, Type32 = 32
    }

    public class LongEnumTest
    {
        [Test]
        public void LongEnumIsDefineTest()
        {
            Assert.AreEqual(true, UniEnum.IsDefined<LongEnum>((long)1));
            Assert.AreEqual(true, UniEnum.IsDefined<LongEnum>((long)2));
            Assert.AreEqual(false, UniEnum.IsDefined<LongEnum>((long)-1));
            Assert.AreEqual(false, UniEnum.IsDefined<LongEnum>((long)33));

            var type1 = (LongEnum)Enum.ToObject(typeof(LongEnum), 1);
            var unknown = (LongEnum)Enum.ToObject(typeof(LongEnum), -1);
            Assert.AreEqual(true, UniEnum.IsDefined(type1));
            Assert.AreEqual(false, UniEnum.IsDefined(unknown));
            
            Assert.AreEqual(true, UniEnum.IsDefined<LongEnum>(LongEnum.Type1 | LongEnum.Type2));
            
        }

        [Test] 
        public void LongEnumTryParseTest() 
        {
            LongEnum value;
            bool result;
            
            result = UniEnum.TryParse("1", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(LongEnum.Type1, value);

            result = UniEnum.TryParse("+1", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(LongEnum.Type1, value);

            result = UniEnum.TryParse("2", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(LongEnum.Type2, value);

            result = UniEnum.TryParse("-1", out value);
            Assert.AreEqual(true, result);

            
            result = UniEnum.TryParse("type1", out value);
            Assert.AreEqual(false, result);

            result = UniEnum.TryParse("type1", true, out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(LongEnum.Type1, value);

            result = UniEnum.TryParse("Type1", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(LongEnum.Type1, value);
            
            result = UniEnum.TryParse("Type1", false, out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(LongEnum.Type1, value);
            
            result = UniEnum.TryParse("type0", out value);
            Assert.AreEqual(false, result);

        }
    }

    public enum UlongEnum : ulong
    {
        Type1 = 1, Type2 = 2, Type3 = 3, Type4 = 4, Type5 = 5, Type6 = 6, Type7 = 7, Type8 = 8, Type9 = 9, Type10 = 10, Type11 = 11, Type12 = 12, Type13 = 13, Type14 = 14, Type15 = 15, Type16 = 16, Type17 = 17, Type18 = 18, Type19 = 19, Type20 = 20, Type21 = 21, Type22 = 22, Type23 = 23, Type24 = 24, Type25 = 25, Type26 = 26, Type27 = 27, Type28 = 28, Type29 = 29, Type30 = 30, Type31 = 31, Type32 = 32
    }

    public class UlongEnumTest
    {
        [Test]
        public void UlongEnumIsDefineTest()
        {
            Assert.AreEqual(true, UniEnum.IsDefined<UlongEnum>((ulong)1));
            Assert.AreEqual(true, UniEnum.IsDefined<UlongEnum>((ulong)2));
            //Assert.AreEqual(false, UniEnum.IsDefined<UlongEnum>((ulong)-1));
            Assert.AreEqual(false, UniEnum.IsDefined<UlongEnum>((ulong)33));

            var type1 = (UlongEnum)Enum.ToObject(typeof(UlongEnum), 1);
            var unknown = (UlongEnum)Enum.ToObject(typeof(UlongEnum), -1);
            Assert.AreEqual(true, UniEnum.IsDefined(type1));
            Assert.AreEqual(false, UniEnum.IsDefined(unknown));
            
            Assert.AreEqual(true, UniEnum.IsDefined<UlongEnum>(UlongEnum.Type1 | UlongEnum.Type2));
            
        }

        [Test] 
        public void UlongEnumTryParseTest() 
        {
            UlongEnum value;
            bool result;
            
            result = UniEnum.TryParse("1", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(UlongEnum.Type1, value);

            result = UniEnum.TryParse("+1", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(UlongEnum.Type1, value);

            result = UniEnum.TryParse("2", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(UlongEnum.Type2, value);

            result = UniEnum.TryParse("-1", out value);
            Assert.AreEqual(false, result);

            
            result = UniEnum.TryParse("type1", out value);
            Assert.AreEqual(false, result);

            result = UniEnum.TryParse("type1", true, out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(UlongEnum.Type1, value);

            result = UniEnum.TryParse("Type1", out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(UlongEnum.Type1, value);
            
            result = UniEnum.TryParse("Type1", false, out value);
            Assert.AreEqual(true, result);
            Assert.AreEqual(UlongEnum.Type1, value);
            
            result = UniEnum.TryParse("type0", out value);
            Assert.AreEqual(false, result);

        }
    }

}

