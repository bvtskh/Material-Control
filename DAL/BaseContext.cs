namespace Material_System.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Material_System.Entities;

    public partial class BaseContext : DbContext
    {
        static string baseConnection = "data source=172.28.10.17;initial catalog=UMCVN_BASE;user id=sa;password=umc@2019;MultipleActiveResultSets=True;App=EntityFramework";
        public BaseContext()
            : base(baseConnection)
        {
        }

        //public virtual DbSet<ERP_USER> ERP_USER { get; set; }
        public virtual DbSet<WH_LOTNG> WH_LOTNGs { get; set; }
        public virtual DbSet<WH_BCLBFLM_His> WH_BCLBFLM_His { get; set; }
        public virtual DbSet<ERP_RULES> ERP_RULES { get; set; }
        public virtual DbSet<WH_Tokusai> WH_Tokusais { get; set; }
        public virtual DbSet<WH_Tokusai_His> WH_Tokusai_His { get; set; }
        public virtual DbSet<Log4Net> Log4Nets { get; set; }
        public virtual DbSet<Tokusai_Item> TokusaiItems { get; set; }
        public virtual DbSet<LotPicture> Parts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
    public partial class UmesContext : DbContext
    {
       static string umesConnecttion = @"Data Source=172.28.10.8;Initial Catalog=UMC_MESDB_TEST;User ID=sa;Password=$umcevn123;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public UmesContext()
           : base(umesConnecttion)
        {
        }
    }
}