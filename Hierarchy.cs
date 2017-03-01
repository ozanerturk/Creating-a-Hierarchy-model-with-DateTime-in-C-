using Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlogEngine.Models
{

    public class Hierarchy
    {
        public HashSet<YearTag> years { get; set; }
        public Hierarchy()
        {
            years = new HashSet<YearTag>();
        }
    }
    public class YearTag
    {
        public int yearValue { get; set; }
        public List<MonthTag> months { get; set; }

        public YearTag()
        {
            months = new List<MonthTag>();
        }
    }

    public class MonthTag
    {
        public int mountValue { get; set; }
        public List<Article> articles { get; set; }

        public MonthTag()
        {
            articles = new List<Article>();
        }
    }
  


    public static class HierarchyHelper
    {
        public static Hierarchy CreateHierarchyModel(this List<Article> articles)
        {
            Hierarchy hierarchy= new Hierarchy();
           
            foreach (var item in articles)
            {
                DateTime date = item.creationDate;
                if(hierarchy.years.SingleOrDefault(x=>x.yearValue==date.Year)== null)
                {
                    hierarchy.years.Add(new YearTag()
                    {
                        yearValue = date.Year
                    });
                }
               
                YearTag yearTag = hierarchy.years.Single(x => x.yearValue == date.Year);

                if (yearTag.months.SingleOrDefault(x => x.mountValue == date.Month) == null)
                {    yearTag.months.Add(new MonthTag()
                    {
                        mountValue = date.Month
                    });

                }
            
                MonthTag mountTag = yearTag.months.Single(x => x.mountValue == date.Month);


                mountTag.articles.Add(item);


            }

           

            return hierarchy;
        }
    }
    
}
