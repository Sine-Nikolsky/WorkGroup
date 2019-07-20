using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkGroup.Entities;

namespace WorkGroup.Context
{
    public class WorkGroupContext : DbContext
    {
        public DbSet<Detail> Details { get; set; }
        public DbSet<GroupItem> GroupItems { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<ProducedDetail> ProducedDetails { get; set; }
    }
}
