using Microsoft.EntityFrameworkCore;
using SMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.Data.SMSDbContext
{
    public class PDbContext : DbContext
    {
        public PDbContext(DbContextOptions<PDbContext> options) : base(options)
        {

        }
        public DbSet<ClassInfoModel> ClassInfoModels { get; set; }
        public DbSet<SectionModel> SectionModels { get; set; }
        public DbSet<AdmissionModel> AdmissionModels { get; set; }
        public DbSet<ResultModel> ResultModels { get; set; }
        public DbSet<AdmissionFeeModel> admissionFeeModels { get; set; }
        public DbSet<MonthlyFeeModel> MonthlyFeeModels { get; set; }
        public DbSet<StudentTransfer> StudentTransfers { get; set; }

        
    }
}
