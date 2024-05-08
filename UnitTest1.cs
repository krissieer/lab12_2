using ClassLibraryLab10;
using lab12_2;
using System.Collections;
namespace TestLaba12_2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ConstructorWithLength()
        {
            int length = 4;
            MyHashTable<MusicalInstrument> table = new MyHashTable<MusicalInstrument>(length);
            MusicalInstrument m1 = new MusicalInstrument();
            m1.IRandomInit();
            table.AddItem(m1);
            Guitar g1 = new Guitar();
            g1.IRandomInit();
            table.AddItem(g1);
            ElectricGuitar e1 = new ElectricGuitar();
            e1.IRandomInit();
            table.AddItem(e1);
            Piano p1 = new Piano();
            p1.IRandomInit();
            table.AddItem(p1);
            Assert.AreEqual(length, table.Count);
        }

        [TestMethod]
        public void SearchItemTrue()
        {
            MyHashTable<MusicalInstrument> table = new MyHashTable<MusicalInstrument>(8);
            MusicalInstrument m1 = new MusicalInstrument();
            m1.IRandomInit();
            Point<MusicalInstrument> Pm = new Point<MusicalInstrument>(m1);
            MusicalInstrument m2 = new MusicalInstrument();
            m2.IRandomInit();
            Guitar g1 = new Guitar();
            g1.IRandomInit();
            Guitar g2 = new Guitar();
            Point<MusicalInstrument> Pg = new Point<MusicalInstrument>(g1);
            g2.IRandomInit();
            ElectricGuitar e1 = new ElectricGuitar();
            e1.IRandomInit();
            Point<MusicalInstrument> Pe = new Point<MusicalInstrument>(e1);
            ElectricGuitar e2 = new ElectricGuitar();
            e2.IRandomInit();
            Piano p1 = new Piano();
            p1.IRandomInit();
            Point<MusicalInstrument> Pp = new Point<MusicalInstrument>(p1);
            Piano p2 = new Piano();
            p2.IRandomInit();

            MusicalInstrument m3 = new MusicalInstrument();
            m3.IRandomInit();
            Guitar g3 = new Guitar();
            g3.IRandomInit();
            ElectricGuitar e3 = new ElectricGuitar();
            e3.IRandomInit();

            table.AddItem(m1);
            table.AddItem(m2);
            table.AddItem(g1);
            table.AddItem(g2);
            table.AddItem(e1);
            table.AddItem(e2);
            table.AddItem(p1);
            table.AddItem(p2);

            Assert.AreEqual(table.SearchItem(Pm), 1);
            Assert.AreEqual(table.SearchItem(Pg), 1);
            Assert.AreEqual(table.SearchItem(Pe), 1);
            Assert.AreEqual(table.SearchItem(Pp), 1);
        }

        [TestMethod]
        public void SearchItemFalse()
        {
            MyHashTable<MusicalInstrument> table = new MyHashTable<MusicalInstrument>(8);
            MusicalInstrument m1 = new MusicalInstrument();
            m1.IRandomInit();
            MusicalInstrument m2 = new MusicalInstrument();
            m2.IRandomInit();
            Guitar g1 = new Guitar();
            g1.IRandomInit();
            Guitar g2 = new Guitar();
            g2.IRandomInit();
            ElectricGuitar e1 = new ElectricGuitar();
            e1.IRandomInit();
            ElectricGuitar e2 = new ElectricGuitar();
            e2.IRandomInit();
            Piano p1 = new Piano();
            p1.IRandomInit();
            Piano p2 = new Piano();
            p2.IRandomInit();

            MusicalInstrument m3 = new MusicalInstrument("ghghg",43);
            Point<MusicalInstrument> Pm3 = new Point<MusicalInstrument>(m3);

            table.AddItem(m1);
            table.AddItem(m2);
            table.AddItem(g1);
            table.AddItem(g2);
            table.AddItem(e1);
            table.AddItem(e2);
            table.AddItem(p1);
            table.AddItem(p2);

            Assert.AreEqual(table.SearchItem(Pm3), -1);
            Assert.AreEqual(table.SearchItem(null), -1);
        }

        [TestMethod]
        public void SearchItem0()
        {
            MyHashTable<MusicalInstrument> table = new MyHashTable<MusicalInstrument>();
            MusicalInstrument m1 = new MusicalInstrument("m", 10);
            Point<MusicalInstrument> Pm1 = new Point<MusicalInstrument>(m1);
            table.SearchItem(Pm1);
            Assert.AreEqual(table.SearchItem(Pm1), 0);
        }

        [TestMethod]
        public void PrintTableEmpty()
        {
            try
            {
                MyHashTable<MusicalInstrument> table = new MyHashTable<MusicalInstrument>();
                table.PrintTable();
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Таблица пустая", ex.Message);
            }
        }

        [TestMethod]
        public void PrintTableZero()
        {
            try
            {
                MyHashTable<MusicalInstrument> table = new MyHashTable<MusicalInstrument>(0);
                table.PrintTable();
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Таблица пустая", ex.Message);
            }
        }

        [TestMethod]
        public void FindNameNullTable()
        {
            MyHashTable<MusicalInstrument> table = new MyHashTable<MusicalInstrument>();
            Assert.AreEqual(table.FindName("ggg"), null);
        }

        [TestMethod]
        public void FindNameNullItem()
        {
            MyHashTable<MusicalInstrument> table = new MyHashTable<MusicalInstrument>(4);
            MusicalInstrument m1 = new MusicalInstrument();
            m1.IRandomInit();
            Guitar g1 = new Guitar();
            g1.IRandomInit();
            ElectricGuitar e1 = new ElectricGuitar();
            e1.IRandomInit();
            Piano p1 = new Piano();
            p1.IRandomInit();

            MusicalInstrument m3 = new MusicalInstrument("ghghgh",22);
            Guitar g3 = new Guitar("fjfjf", 3,55);

            table.AddItem(m1);
            table.AddItem(g1);
            table.AddItem(e1);
            table.AddItem(p1);

            Assert.AreEqual(table.FindName(m3.Name), null);
            Assert.AreEqual(table.FindName(g3.Name), null);
        }

        [TestMethod]
        public void FindName()
        {
            MyHashTable<MusicalInstrument> table = new MyHashTable<MusicalInstrument>(8);
            MusicalInstrument m1 = new MusicalInstrument();
            m1.IRandomInit();
            //Point<MusicalInstrument> Pm1 = new Point<MusicalInstrument>(m1);
            MusicalInstrument m2 = new MusicalInstrument();
            m2.IRandomInit();
            Guitar g1 = new Guitar();
            g1.IRandomInit();
            Guitar g2 = new Guitar();
            g2.IRandomInit();
            ElectricGuitar e1 = new ElectricGuitar();
            e1.IRandomInit();
            ElectricGuitar e2 = new ElectricGuitar();
            e2.IRandomInit();
            Piano p1 = new Piano();
            p1.IRandomInit();
            //Point<MusicalInstrument> Pp1 = new Point<MusicalInstrument>(p1);
            Piano p2 = new Piano();
            p2.IRandomInit();

            table.AddItem(m1);
            table.AddItem(m2);
            table.AddItem(g1);
            table.AddItem(g2);
            table.AddItem(e1);
            table.AddItem(e2);
            table.AddItem(p1);
            table.AddItem(p2);

            Point<MusicalInstrument> isFound = table.FindName(m1.Name);
            Assert.AreEqual(isFound, table.FindName(m1.Name));
            Point<MusicalInstrument> isFound2 = table.FindName(g1.Name);
            Assert.AreEqual(isFound2, table.FindName(g1.Name));
            Point<MusicalInstrument> isFound3 = table.FindName(p2.Name);
            Assert.AreEqual(isFound3, table.FindName(p2.Name));
        }

        [TestMethod]
        public void AddItem1()
        {
            MyHashTable<MusicalInstrument> table = new MyHashTable<MusicalInstrument>(8);
            MusicalInstrument m1 = new MusicalInstrument();
            m1.IRandomInit();
            MusicalInstrument m2 = new MusicalInstrument();
            m2.IRandomInit();
            Guitar g1 = new Guitar();
            g1.IRandomInit();
            Guitar g2 = new Guitar();
            g2.IRandomInit();
            ElectricGuitar e1 = new ElectricGuitar();
            e1.IRandomInit();
            Piano p1 = new Piano();
            p1.IRandomInit();

            Assert.AreEqual(table.AddItem(m1), 1);
            Assert.AreEqual(table.AddItem(m2), 1);
            Assert.AreEqual(table.AddItem(g1), 1);
            Assert.AreEqual(table.AddItem(g2), 1);
            Assert.AreEqual(table.AddItem(e1), 1);
            Assert.AreEqual(table.AddItem(p1), 1);
        }

        [TestMethod]
        public void AddItemFalse()
        {
            MyHashTable<MusicalInstrument> table = new MyHashTable<MusicalInstrument>(8);
            MusicalInstrument m1 = new MusicalInstrument();
            m1.IRandomInit();
            table.AddItem(m1);
            table.AddItem(m1);

            Assert.AreEqual(table.AddItem(m1), -1);
        }

        [TestMethod]
        public void AddItem0()
        {
            MyHashTable<MusicalInstrument> table = new MyHashTable<MusicalInstrument>();
            MusicalInstrument m1 = new MusicalInstrument("m", 10);
            Assert.AreEqual(table.AddItem(m1), 0);
        }

        [TestMethod]
        public void RemoveItemFalse()
        {
            MyHashTable<MusicalInstrument> table = new MyHashTable<MusicalInstrument>(4);
            MusicalInstrument m1 = new MusicalInstrument();
            m1.IRandomInit();
            Guitar g1 = new Guitar();
            g1.IRandomInit();
            ElectricGuitar e1 = new ElectricGuitar();
            e1.IRandomInit();
            Piano p1 = new Piano();
            p1.IRandomInit();

            table.AddItem(m1);
            table.AddItem(g1);
            table.AddItem(e1);
            table.AddItem(p1);

            Assert.AreEqual(table.RemoveItem(null), -1);
        }

        [TestMethod]
        public void RemoveItem0()
        {
            MyHashTable<MusicalInstrument> table = new MyHashTable<MusicalInstrument>();
            MusicalInstrument m1 = new MusicalInstrument("m", 10);
            Point<MusicalInstrument> Pm = new Point<MusicalInstrument>(m1);
            Assert.AreEqual(table.RemoveItem(Pm), 0);
        }

        [TestMethod]
        public void RemoveItem1()
        {
            MyHashTable<MusicalInstrument> table = new MyHashTable<MusicalInstrument>(8);
            MusicalInstrument m1 = new MusicalInstrument();
            m1.IRandomInit();
            Point<MusicalInstrument> Pm1 = new Point<MusicalInstrument>(m1);
            MusicalInstrument m2 = new MusicalInstrument();
            m2.IRandomInit();
            Point<MusicalInstrument> Pm2 = new Point<MusicalInstrument>(m2);
            Guitar g1 = new Guitar();
            g1.IRandomInit();
            Point<MusicalInstrument> Pg1 = new Point<MusicalInstrument>(g1);
            Guitar g2 = new Guitar();
            g2.IRandomInit();
            Point<MusicalInstrument> Pg2 = new Point<MusicalInstrument>(g2);
            ElectricGuitar e1 = new ElectricGuitar();
            e1.IRandomInit();
            Point<MusicalInstrument> Pe1 = new Point<MusicalInstrument>(e1);
            ElectricGuitar e2 = new ElectricGuitar();
            e2.IRandomInit();
            Point<MusicalInstrument> Pe2 = new Point<MusicalInstrument>(e2);
            Piano p1 = new Piano();
            p1.IRandomInit();
            Point<MusicalInstrument> Pp1 = new Point<MusicalInstrument>(p1);
            Piano p2 = new Piano();
            p2.IRandomInit();
            Point<MusicalInstrument> Pp2 = new Point<MusicalInstrument>(p2);

            table.AddItem(m1);
            table.AddItem(m2);
            table.AddItem(g1);
            table.AddItem(g2);
            table.AddItem(e1);
            table.AddItem(e2);
            table.AddItem(p1);
            table.AddItem(p2);

            Assert.AreEqual(table.RemoveItem(Pp1), 1);
            Assert.AreEqual(table.RemoveItem(Pe1), 1);
            Assert.AreEqual(table.RemoveItem(Pm1), 1);
            Assert.AreEqual(table.RemoveItem(Pg1), 1);
            Assert.AreEqual(table.RemoveItem(Pm2), 1);
            Assert.AreEqual(table.RemoveItem(Pg2), 1);
            Assert.AreEqual(table.RemoveItem(Pe2), 1);
            Assert.AreEqual(table.RemoveItem(Pp2), 1);
        }

        [TestMethod]
        public void RemoveItem1_2()
        {
            MyHashTable<MusicalInstrument> table = new MyHashTable<MusicalInstrument>(8);
            MusicalInstrument m1 = new MusicalInstrument();
            m1.IRandomInit();
            Point<MusicalInstrument> Pm1 = new Point<MusicalInstrument>(m1);
            Piano p1 = new Piano();
            p1.IRandomInit();
            Point<MusicalInstrument> Pp1 = new Point<MusicalInstrument>(p1);
            table.AddItem(m1);
            table.AddItem(p1);
            Assert.AreEqual(table.RemoveItem(Pm1), 1);
            Assert.AreEqual(table.RemoveItem(Pp1), 1);
        }

        [TestMethod]
        public void Clone()
        {
            MyHashTable<MusicalInstrument> table = new MyHashTable<MusicalInstrument>(8);

            MusicalInstrument m1 = new MusicalInstrument();
            m1.IRandomInit();
            MusicalInstrument m2 = new MusicalInstrument();
            m2.IRandomInit();
            Guitar g1 = new Guitar();
            g1.IRandomInit();
            Guitar g2 = new Guitar();
            g2.IRandomInit();
            ElectricGuitar e1 = new ElectricGuitar();
            e1.IRandomInit();
            ElectricGuitar e2 = new ElectricGuitar();
            e2.IRandomInit();
            Piano p1 = new Piano();
            p1.IRandomInit();
            Piano p2 = new Piano();
            p2.IRandomInit();
            table.AddItem(m1);
            table.AddItem(m2);
            table.AddItem(g1);
            table.AddItem(g2);
            table.AddItem(e1);
            table.AddItem(e2);
            table.AddItem(p1);
            table.AddItem(p2);

            MusicalInstrument m4 = new MusicalInstrument();
            m4.IRandomInit();
            MyHashTable<MusicalInstrument> cloneTable = table.Clone(table);
            Assert.AreEqual(table.Capacity, cloneTable.Capacity);
            cloneTable.ChangeItem(new MusicalInstrument("NEW ITEM", 555));
            Assert.AreNotEqual(table, cloneTable);
        }

        [TestMethod]
        public void CloneNull()
        {
            MyHashTable<MusicalInstrument> table = new MyHashTable<MusicalInstrument>();
            MyHashTable<MusicalInstrument> cloneTable = table.Clone(table);
            Assert.AreEqual(cloneTable, null);
        }

        

        // Класс Point
        [TestMethod]
        public void ConstructorWithoutParam()
        {
            Point<MusicalInstrument> p = new Point<MusicalInstrument>();
            Assert.IsNull(p.Next);
            Assert.IsNull(p.Prev);
            Assert.IsNull(p.Data);
        }

        [TestMethod]
        public void GetHashCodeNull()
        {
            Point<MusicalInstrument> p = new Point<MusicalInstrument>();
            var res1 = p.GetHashCode();
            Assert.AreEqual(res1, 0);
        }

        [TestMethod]
        public void GetHashCode()
        {
            MusicalInstrument m = new MusicalInstrument();
            Point<MusicalInstrument> p = new Point<MusicalInstrument>(m);
            var res1 = p.GetHashCode();
            Assert.AreEqual(res1, p.GetHashCode());
        }

        [TestMethod]
        public void ToStringNull()
        {
            Point<MusicalInstrument> p = new Point<MusicalInstrument>();
            var res1 = p.ToString();
            Assert.AreEqual(res1, "");
        }

        [TestMethod]
        public void ToString()
        {
            MusicalInstrument m = new MusicalInstrument("m",44);
            Point<MusicalInstrument> p = new Point<MusicalInstrument>(m);
            var res1 = p.ToString();
            Assert.AreEqual(res1, "44: m,");
        }
    }
}