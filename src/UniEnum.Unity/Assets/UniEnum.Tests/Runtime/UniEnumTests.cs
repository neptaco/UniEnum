using System;
using System.Diagnostics;
using NUnit.Framework;
using UniEnumUtils;
#if UNITY_INCLUDE_TESTS
using UnityEngine.TestTools.Constraints;
using Is = UnityEngine.TestTools.Constraints.Is;
#endif

namespace UniEnumTests
{
    public class UniEnumTests
    {
        [Flags]
        private enum Types
        {
            Type1,
            Type2,
            Type3,
        }
        
        [Test]
        public void GetNamesTest()
        {
            var names1 = Enum.GetNames(typeof(Types));
            var names2 = UniEnum.GetNames<Types>();
            Assert.AreEqual(names1,names2);

            CheckNotGCAlloc(() => 
            {
                UniEnum.GetNames<Types>();
            });
        }

        [Conditional("UNITY_INCLUDE_TESTS")]
        private void CheckNotGCAlloc(Action action)
        {
#if UNITY_INCLUDE_TESTS
            Assert.That(() =>
            {
                action();
            }, Is.Not.AllocatingGCMemory());
#endif            
        }
        
        [Test]
        public void GetValuesTest()
        {
            var values1 = (Types[])Enum.GetValues(typeof(Types));
            var values2 = UniEnum.GetValues<Types>();
            Assert.AreEqual(values1,values2);
            
            CheckNotGCAlloc(() => 
            {
                UniEnum.GetValues<Types>();
            });
        }

        [Test]
        public void IsDefinedTest()
        {
            Assert.IsTrue(UniEnum.IsDefined<Int2Enum>(4));
            Assert.IsTrue(UniEnum.IsDefined<Int2Enum>(6));
            Assert.IsFalse(UniEnum.IsDefined<Int2Enum>(5));
            Assert.IsFalse(UniEnum.IsDefined<Int2Enum>(7));

            CheckNotGCAlloc(() =>
            {
                UniEnum.IsDefined<Int2Enum>(6);
                UniEnum.IsDefined<Int2Enum>(5);
            });
        }
        
        [Test]
        public void CountTest()
        {
            Assert.AreEqual(3,UniEnum.GetCount<Types>());

            CheckNotGCAlloc(() =>
            {
                UniEnum.GetCount<Types>();
            });
        }
        
    }
}
