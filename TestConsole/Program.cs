using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkGroup.Context;
using WorkGroup.Entities;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new WorkGroupContext();

            var list = db.Groups.Where(x => x.Name != null);
            foreach (var group in list)
            {
                db.Groups.Remove(group);
            }

            //var list = db.Groups.Where(x => x.DeleteDate == null).ToList();

            //foreach (var group in list)
            //{
            //    if (group.Name != null)
            //    {
            //        db.Groups.Remove(group);
            //    }
            //}
            //foreach (var group in list)
            //{
            //    if (group.Name == "Other")
            //    {
            //        group.DeleteDate = DateTime.Now;
            //    }
            //}
            //foreach (var group in list)
            //{


            //    Console.WriteLine(group.Name);


            //}
            //Console.ReadLine();


            //db.Groups.AddRange(new Group[]{
            //    new Group()
            //    {
            //        Name = "ГОСТ",
            //        Id = Guid.NewGuid(),
            //        CreateDate = DateTime.Now,
            //        ModifyDate = DateTime.Now,
            //        DeleteDate = null
            //    },
            //    new Group()
            //    {
            //        Name = "Машина",
            //        Id = Guid.NewGuid(),
            //        CreateDate = DateTime.Now,
            //        ModifyDate = DateTime.Now,
            //        DeleteDate = null
            //    },
            //    new Group()
            //    {
            //        Name = "Прочее",
            //        Id = Guid.NewGuid(),
            //        CreateDate = DateTime.Now,
            //        ModifyDate = DateTime.Now,
            //        DeleteDate = null
            //    }
            //    });

            //db.SaveChanges();
        }
    }
}
