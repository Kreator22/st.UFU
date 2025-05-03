namespace HW01_Tests_07_08_09
{
    [TestClass]
    public sealed class HW01_Tests_07_08_09
    {
        [TestMethod]
        public void Tests_HW01_07()
        {
            bool actual;

            actual = HW01_07_08_09.IS_B_InTheMiddle(1, 2, 3);
            Assert.AreEqual(true, actual);

            actual = HW01_07_08_09.IS_B_InTheMiddle(3, 2, 1);
            Assert.AreEqual(true, actual);

            actual = HW01_07_08_09.IS_B_InTheMiddle(1, 2, 1);
            Assert.AreEqual(false, actual);

            actual = HW01_07_08_09.IS_B_InTheMiddle(2, 1, 2);
            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void Tests_HW01_08()
        {
            bool actual;

            actual = HW01_07_08_09.AreOdd(1, 1);
            Assert.AreEqual(true, actual);

            actual = HW01_07_08_09.AreOdd(1, 2);
            Assert.AreEqual(false, actual);

            actual = HW01_07_08_09.AreOdd(2, 2);
            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void Tests_HW01_09()
        {
            bool actual;

            actual = HW01_07_08_09.AreSameParity(1, 1);
            Assert.AreEqual(true, actual);

            actual = HW01_07_08_09.AreSameParity(1, 2);
            Assert.AreEqual(false, actual);

            actual = HW01_07_08_09.AreSameParity(2, 2);
            Assert.AreEqual(true, actual);
        }
    }
}
