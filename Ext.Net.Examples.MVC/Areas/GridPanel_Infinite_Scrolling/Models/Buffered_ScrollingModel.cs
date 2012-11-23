using System;
using System.Collections;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_Infinite_Scrolling.Models
{
    public class TestData
    {
        public static IEnumerable GetData(int count)
        {
            var firstNames = new string[] { "Ed", "Tommy", "Aaron", "Abe", "Jamie", "Adam", "Dave", "David", "Jay", "Nicolas", "Nige" };
            var lastNames = new string[] { "Spencer", "Maintz", "Conran", "Elias", "Avins", "Mishcon", "Kaneda", "Davis", "Robinson", "Ferrero", "White" };
            var ratings = new int[] { 1, 2, 3, 4, 5 };
            var salaries = new int[] { 100, 400, 900, 1500, 1000000 };

            var data = new object[count];
            var rnd = new Random();

            for (int i = 0; i < count; i++)
            {
                var ratingId = rnd.Next(ratings.Length);
                var salaryId = rnd.Next(salaries.Length);
                var firstNameId = rnd.Next(firstNames.Length);
                var lastNameId = rnd.Next(lastNames.Length);

                var rating = ratings[ratingId];
                var salary = salaries[salaryId];
                var name = String.Format("{0} {1}", firstNames[firstNameId], lastNames[lastNameId]);
                var id = "rec-" + i;

                data[i] = new object[] { id, name, rating, salary };
            }

            return data;
        }
    }
}