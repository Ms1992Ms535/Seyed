using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Seyed.Models;

public partial class CustomerContext : DbContext
{
    public CustomerContext()
    {
    }

    public CustomerContext(DbContextOptions<CustomerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<AddressType> AddressTypes { get; set; }

    public virtual DbSet<BankAccount> BankAccounts { get; set; }

    public virtual DbSet<BlackList> BlackLists { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<ClientMerge> ClientMerges { get; set; }

    public virtual DbSet<ClientMergeSystem> ClientMergeSystems { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Config> Configs { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<ContactInfo> ContactInfos { get; set; }

    public virtual DbSet<CreditWorthiness> CreditWorthinesses { get; set; }

    public virtual DbSet<CustomerFile> CustomerFiles { get; set; }

    public virtual DbSet<CustomerStatusReason> CustomerStatusReasons { get; set; }

    public virtual DbSet<FileBatch> FileBatches { get; set; }

    public virtual DbSet<FileBatchRecord> FileBatchRecords { get; set; }

    public virtual DbSet<Human> Humans { get; set; }

    public virtual DbSet<HumanCategory> HumanCategories { get; set; }

    public virtual DbSet<HumanMirEmad> HumanMirEmads { get; set; }

    public virtual DbSet<Log> Logs { get; set; }

    public virtual DbSet<OwnerSignature> OwnerSignatures { get; set; }

    public virtual DbSet<RegSeri> RegSeris { get; set; }

    public virtual DbSet<RelationshipType> RelationshipTypes { get; set; }

    public virtual DbSet<Religion> Religions { get; set; }

    public virtual DbSet<SpecialCond> SpecialConds { get; set; }

    public virtual DbSet<VersionInfo> VersionInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
        if (!optionsBuilder.IsConfigured)
        {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Initial Catalog=Customer;User ID=sa;Password=@fagh#110;Encrypt=True;TrustServerCertificate=True;");
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {



        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasFillFactor(80);

            entity.ToTable("Address");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active).HasDefaultValue(true);
            entity.Property(e => e.Address1)
                .HasMaxLength(1000)
                .HasColumnName("Address");
            entity.Property(e => e.AddressTypeId).HasColumnName("AddressTypeID");
            entity.Property(e => e.CityCode)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.ModifyDate).HasColumnType("smalldatetime");
            entity.Property(e => e.PostalCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.TelNo)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.AddressType).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.AddressTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Address_AddressType");

            entity.HasOne(d => d.Client).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Address_Client");
        });

        modelBuilder.Entity<AddressType>(entity =>
        {
            entity.HasKey(e => e.Id).HasFillFactor(80);

            entity.ToTable("AddressType");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.Active).HasDefaultValue(true);
            entity.Property(e => e.Title).HasMaxLength(15);
        });

        modelBuilder.Entity<BankAccount>(entity =>
        {
            entity.HasKey(e => e.Id).HasFillFactor(80);

            entity.ToTable("BankAccount");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AccNo)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.BankId).HasColumnName("BankID");
            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.ModifyDate).HasColumnType("datetime");
            entity.Property(e => e.OwnerName).HasMaxLength(100);
            entity.Property(e => e.ShebaNo)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<BlackList>(entity =>
        {
            entity.HasKey(e => e.BlackListId).HasFillFactor(80);

            entity.ToTable("BlackList");

            entity.HasIndex(e => e.ClientId, "IX_BlackList").HasFillFactor(80);

            entity.Property(e => e.BlackListId)
                .HasComment("شناسه جدول")
                .HasColumnName("BlackListID");
            entity.Property(e => e.AddBranchId)
                .HasComment("شعبه اضافه کننده به لیست سیاه")
                .HasColumnName("AddBranchID");
            entity.Property(e => e.AddDate)
                .HasComment("تاریخ اضافه کردن به لیست سیاه")
                .HasColumnType("datetime");
            entity.Property(e => e.AddUserId)
                .HasComment("کاربر اضافه کننده به لیست سیاه")
                .HasColumnName("AddUserID");
            entity.Property(e => e.ClientId)
                .HasComment("کلید خارجی از جدول Client")
                .HasColumnName("ClientID");
            entity.Property(e => e.Comment).HasColumnType("ntext");
            entity.Property(e => e.DeleteBranchId)
                .HasComment("شعبه حذف کننده از لیست سیاه")
                .HasColumnName("DeleteBranchID");
            entity.Property(e => e.DeleteDate)
                .HasComment("تاریخ حذف از لیست سیاه")
                .HasColumnType("datetime");
            entity.Property(e => e.DeleteUserId)
                .HasComment("کاربر حذف کننده از لیست سیاه")
                .HasColumnName("DeleteUserID");
            entity.Property(e => e.OriginalBranchId).HasColumnName("OriginalBranchID");
            entity.Property(e => e.OriginalId).HasColumnName("OriginalID");
            entity.Property(e => e.ReasonIds)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("کلید خارجی از جدول CustomerStatusReason")
                .HasColumnName("ReasonIDs");
            entity.Property(e => e.Status).HasComment("وضعیت:1:فعال در لیست سیاه 0 حذف شده از لیست سیاه");

            entity.HasOne(d => d.Client).WithMany(p => p.BlackLists)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK_BlackList_Client");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientId)
                .HasName("PK_Client_1")
                .HasFillFactor(80);

            entity.ToTable("Client");

            entity.HasIndex(e => e.CustomerNo, "IX_Client")
                .IsUnique()
                .HasFillFactor(80);

            entity.HasIndex(e => new { e.RefType, e.RefId }, "IX_Client_1").HasFillFactor(80);

            entity.Property(e => e.ClientId)
                .HasComment("شناسه جدول")
                .HasColumnName("ClientID");
            entity.Property(e => e.BranchId).HasColumnName("BranchID");
            entity.Property(e => e.Codem)
                .HasMaxLength(50)
                .HasColumnName("codem");
            entity.Property(e => e.CostCenterId)
                .HasComment("شناسه مرکز هزینه مشتری")
                .HasColumnName("CostCenterID");
            entity.Property(e => e.CustomerNo).HasComment("شماره مشتری");
            entity.Property(e => e.MirEmadClientId).HasColumnName("MirEmadClientID");
            entity.Property(e => e.MirEmadHumanId).HasColumnName("MirEmadHumanID");
            entity.Property(e => e.OriginalBreanchId).HasColumnName("OriginalBreanchID");
            entity.Property(e => e.OriginalId).HasColumnName("OriginalID");
            entity.Property(e => e.RefId)
                .HasComment("کلید خارجی شناسه جدولhuman or Company")
                .HasColumnName("RefID");
            entity.Property(e => e.RefType).HasComment("نوع مشتری : 1: حقوقی   2:حقیقی    3: مشترک");

            entity.HasOne(d => d.Ref).WithMany(p => p.Clients)
                .HasForeignKey(d => d.RefId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Client_Company");

            entity.HasOne(d => d.RefNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.RefId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Client_Human");
        });

        modelBuilder.Entity<ClientMerge>(entity =>
        {
            entity.HasKey(e => e.Id).HasFillFactor(80);

            entity.ToTable("ClientMerge");

            entity.Property(e => e.Id)
                .HasComment("شناسه جدول")
                .HasColumnName("ID");
            entity.Property(e => e.Active).HasDefaultValue(true);
            entity.Property(e => e.ApplyDate)
                .HasComment("تاریخ ادغام")
                .HasColumnType("datetime");
            entity.Property(e => e.ClientIdA).HasComment("شناسه مشتری اصلی");
            entity.Property(e => e.ClientIdB).HasComment("شناسه مشتری فرعی");
            entity.Property(e => e.CreateBy).HasComment("کاربر ادغام کننده");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsDone).HasDefaultValue(false);
            entity.Property(e => e.IsMerge).HasDefaultValue(true);

            entity.HasOne(d => d.ClientIdANavigation).WithMany(p => p.ClientMerges)
                .HasForeignKey(d => d.ClientIdA)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClientMerge_Client");
        });

        modelBuilder.Entity<ClientMergeSystem>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("PK_ClientMergeTables")
                .HasFillFactor(80);

            entity.ToTable("ClientMergeSystem");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EntityId).HasColumnName("EntityID");
            entity.Property(e => e.EntityName).HasMaxLength(50);
            entity.Property(e => e.MergeId)
                .HasComment("کلید خارجی از جدولClientMerge")
                .HasColumnName("MergeID");

            entity.HasOne(d => d.Merge).WithMany(p => p.ClientMergeSystems)
                .HasForeignKey(d => d.MergeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClientMergeSystem_ClientMerge");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.CompanyId).HasFillFactor(80);

            entity.ToTable("Company");

            entity.Property(e => e.CompanyId)
                .HasComment("شناسه")
                .HasColumnName("CompanyID");
            entity.Property(e => e.Boss)
                .HasMaxLength(50)
                .HasComment("مدیر عامل");
            entity.Property(e => e.Comment)
                .HasMaxLength(255)
                .HasComment("توضیحات");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .HasComment("نام");
            entity.Property(e => e.CompanyType)
                .HasDefaultValue((byte)0)
                .HasComment("1 تأسیس شده\r\n2 در حال تأسیس\r\n3 نهاد");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("تاریخ ثبت")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.EconomicCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("کد اقتصادی");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LatinCompanyName)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasComment("نام به لاتین");
            entity.Property(e => e.LetterNo)
                .HasMaxLength(50)
                .HasComment("شماره نامه");
            entity.Property(e => e.Mobile)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifyDate).HasColumnType("smalldatetime");
            entity.Property(e => e.NationalNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OriginalBranchId).HasColumnName("OriginalBranchID");
            entity.Property(e => e.OriginalId).HasColumnName("OriginalID");
            entity.Property(e => e.PartMaster)
                .HasMaxLength(500)
                .HasComment("مسئول");
            entity.Property(e => e.PartName)
                .HasMaxLength(500)
                .HasComment("واحد");
            entity.Property(e => e.RegDate)
                .HasComment("تاریخ ثبت")
                .HasColumnType("datetime");
            entity.Property(e => e.RegNo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("شماره ثبت");
            entity.Property(e => e.RegPlace)
                .HasMaxLength(500)
                .HasComment("محل ثبت");
            entity.Property(e => e.RelationPerson)
                .HasMaxLength(50)
                .HasComment("نام رابط حساب");
            entity.Property(e => e.RelationPersonDate)
                .HasComment("تاریخ معرفی رابط")
                .HasColumnType("datetime");
            entity.Property(e => e.Stamp).HasComment("مهر دارد یا خیر");
            entity.Property(e => e.TimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.UserId)
                .HasComment("کاربر ثبت کننده مشتری")
                .HasColumnName("UserID");
        });

        modelBuilder.Entity<Config>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Config");

            entity.Property(e => e.Comment).HasMaxLength(100);
            entity.Property(e => e.Key)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Key_");
            entity.Property(e => e.Value1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Value2)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.Id).HasFillFactor(80);

            entity.ToTable("Contact");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.LastName).HasMaxLength(64);
            entity.Property(e => e.Name).HasMaxLength(64);
        });

        modelBuilder.Entity<ContactInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasFillFactor(80);

            entity.ToTable("ContactInfo");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ContactId).HasColumnName("ContactID");
            entity.Property(e => e.Title).HasMaxLength(100);
            entity.Property(e => e.Value).HasMaxLength(64);

            entity.HasOne(d => d.Contact).WithMany(p => p.ContactInfos)
                .HasForeignKey(d => d.ContactId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contact_ContactInfo");
        });

        modelBuilder.Entity<CreditWorthiness>(entity =>
        {
            entity.HasKey(e => e.CreditWorthinessId).HasFillFactor(80);

            entity.ToTable("CreditWorthiness");

            entity.HasIndex(e => e.ClientId, "IX_CreditWorthiness").HasFillFactor(80);

            entity.Property(e => e.CreditWorthinessId)
                .HasComment("شناسه")
                .HasColumnName("CreditWorthinessID");
            entity.Property(e => e.AddBranchId)
                .HasComment("شعبه اضافه کننده به لیست خوش حسابان")
                .HasColumnName("AddBranchID");
            entity.Property(e => e.AddDate)
                .HasComment("تاریخ اضافه شدن به لیست خوش حسابان")
                .HasColumnType("datetime");
            entity.Property(e => e.AddUserId)
                .HasComment("کاربر اضافه کننده به لیست خوش حسابان")
                .HasColumnName("AddUserID");
            entity.Property(e => e.ClientId)
                .HasComment("کلید خارجی از جدول client")
                .HasColumnName("ClientID");
            entity.Property(e => e.Comment).HasColumnType("ntext");
            entity.Property(e => e.DeleteBranchId)
                .HasComment("شعبه حذف کننده از لیست خوش حسابان")
                .HasColumnName("DeleteBranchID");
            entity.Property(e => e.DeleteDate)
                .HasComment("تاریخ حذف از لیست خوش حسابان")
                .HasColumnType("datetime");
            entity.Property(e => e.DeleteUserId)
                .HasComment("کاربر حذف کننده از لیست خوش حسابان")
                .HasColumnName("DeleteUserID");
            entity.Property(e => e.ReasonIds)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("کلید خارجی دلیل حذف یا اضافه از این جدول(CustomerstatusReason)")
                .HasColumnName("ReasonIDs");
            entity.Property(e => e.Status).HasComment("وضعیت 1: فعال در لیست خوش حسابی، 0 حذف شده از لیست خوش حسابی");

            entity.HasOne(d => d.Client).WithMany(p => p.CreditWorthinesses)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CreditWorthiness_Client");
        });

        modelBuilder.Entity<CustomerFile>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("PK_CustomerSign")
                .HasFillFactor(80);

            entity.ToTable("CustomerFile");

            entity.HasIndex(e => e.ClientId, "IX_CustomerFile").HasFillFactor(80);

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.FileId).HasColumnName("FileID");
            entity.Property(e => e.ModifyDate).HasColumnType("smalldatetime");

            entity.HasOne(d => d.Client).WithMany(p => p.CustomerFiles)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerFile_Client");
        });

        modelBuilder.Entity<CustomerStatusReason>(entity =>
        {
            entity.HasKey(e => e.Id).HasFillFactor(80);

            entity.ToTable("CustomerStatusReason");

            entity.Property(e => e.Id)
                .HasComment("شناسه")
                .HasColumnName("ID");
            entity.Property(e => e.Active).HasComment("فعال بودن");
            entity.Property(e => e.Status).HasComment("0:delete Reason,           1: add reason");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasComment("عنوان دلیل");
            entity.Property(e => e.Type).HasComment("0=CreditWorthiness   1=BlackList");
        });

        modelBuilder.Entity<FileBatch>(entity =>
        {
            entity.HasKey(e => e.Id).HasFillFactor(80);

            entity.ToTable("FileBatch");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BranchId).HasColumnName("BranchID");
            entity.Property(e => e.Comment)
                .HasMaxLength(255)
                .IsSparse();
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FileName).HasMaxLength(255);
            entity.Property(e => e.ModifyDate).HasColumnType("datetime");
            entity.Property(e => e.RecordCount).HasComment("تعداد سطرهای فایل");
            entity.Property(e => e.Status).HasComment("0 انجام نشده\r\n1 انجام شده\r\n2 لغو شده");
            entity.Property(e => e.Type).HasComment("0  ثبت دسته‏ای مشتری\r\n1  ادغام \r\n2 برگشت ادغام\r\n3 فایل اطلاعات مشتری جهت یافتن مشتریان مشابه\r\n--\r\nادغام و برگشت ادغام بصورت فایل نیست و در اینجا کاربرد ندارد");
        });

        modelBuilder.Entity<FileBatchRecord>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("PK_FileBatchInfo")
                .HasFillFactor(80);

            entity.ToTable("FileBatchRecord");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FileBatchId).HasColumnName("FileBatchID");
            entity.Property(e => e.Record).HasColumnType("xml");
            entity.Property(e => e.Result).HasColumnType("xml");
            entity.Property(e => e.ResultMsg).HasMaxLength(50);
        });



        base.OnModelCreating(modelBuilder);



        modelBuilder.Entity<Human>(entity =>
        {


            entity.HasKey(e => e.HumanId)
                .HasName("PK_Client")
                .HasFillFactor(80);

            entity.ToTable("Human");

            entity.HasIndex(e => e.NationalNo, "IX_Human_NationalNo").HasFillFactor(80);

            entity.Property(e => e.HumanId)
                .HasComment("شناسه")
                .HasColumnName("HumanID");
            entity.Property(e => e.BirthDate)
                .HasComment("تاریخ تولد")
                .HasColumnType("datetime");
            entity.Property(e => e.BirthPlace)
                .HasMaxLength(50)
                .HasComment("محل تولد");
            entity.Property(e => e.CategoryCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasComment("کد کامپیوتری طلبه");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.Comment).HasMaxLength(255);
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("تاریخ ثبت")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.DatCont)
                .HasMaxLength(50)
                .HasColumnName("DAT_CONT");
            entity.Property(e => e.EducationId)
                .HasComment(" تحصیلات کلاسیک")
                .HasColumnName("EducationID");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Family)
                .HasMaxLength(50)
                .HasComment("فامیل");
            entity.Property(e => e.FamilyOld)
                .HasMaxLength(50)
                .HasColumnName("familyOld");
            entity.Property(e => e.FatherName)
                .HasMaxLength(50)
                .HasComment("نام پدر");
            entity.Property(e => e.FathernameOld).HasMaxLength(50);
            entity.Property(e => e.Finger).HasComment("اثر انگشت دارد یا خیر");
            entity.Property(e => e.HumanName)
                .HasMaxLength(50)
                .HasComment("نام");
            entity.Property(e => e.Job)
                .HasMaxLength(40)
                .HasComment("شغل");
            entity.Property(e => e.LatinFamily)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("فامیل به لاتین");
            entity.Property(e => e.LatinName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("نام به لاتین");
            entity.Property(e => e.Marriage).HasComment("مجرد یا متاهل");
            entity.Property(e => e.MirEmadHumanId).HasColumnName("MirEmadHumanID");
            entity.Property(e => e.Mobile)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifyDate).HasColumnType("smalldatetime");
            entity.Property(e => e.NameOld)
                .HasMaxLength(50)
                .HasColumnName("nameOld");
            entity.Property(e => e.NationalId)
                .HasComment("ملیت")
                .HasColumnName("NationalID");
            entity.Property(e => e.NationalNo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasComment("کد ملی");
            entity.Property(e => e.NickName)
                .HasMaxLength(50)
                .HasComment("شهرت");
            entity.Property(e => e.OriginalBranchId).HasColumnName("OriginalBranchID");
            entity.Property(e => e.OriginalId).HasColumnName("OriginalID");
            entity.Property(e => e.Pic).HasComment("تصویر دارد یا خیر");
            entity.Property(e => e.RegNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("شماره شناسنامه");
            entity.Property(e => e.RegPlace)
                .HasMaxLength(50)
                .HasComment("محل ثبت");
            entity.Property(e => e.RegSerial)
                .HasMaxLength(20)
                .HasComment("شماره سریال");
            entity.Property(e => e.RegnoOld)
                .HasMaxLength(50)
                .HasColumnName("regnoOld");
            entity.Property(e => e.RelationshipClientId).HasColumnName("RelationshipClientID");
            entity.Property(e => e.RelationshipTypeId).HasColumnName("RelationshipTypeID");
            entity.Property(e => e.ReligionId)
                .HasComment("شناسه مذهب")
                .HasColumnName("ReligionID");
            entity.Property(e => e.Sex).HasComment("جنسیت");
            entity.Property(e => e.SpecialCondId)
                .HasComment("شناسه شرایط خاص")
                .HasColumnName("SpecialCondID");
            entity.Property(e => e.Stime).HasMaxLength(50);
            entity.Property(e => e.TimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.Title).HasMaxLength(255);
            entity.Property(e => e.UserId)
                .HasComment("کاربر ثبت کننده مشتری")
                .HasColumnName("UserID");

            entity.HasOne(d => d.Category).WithMany(p => p.Humans)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Human_Category");

            entity.HasOne(d => d.RelationshipType).WithMany(p => p.Humans)
                .HasForeignKey(d => d.RelationshipTypeId)
                .HasConstraintName("FK_Human_RelationshipType");
        });

        modelBuilder.Entity<HumanCategory>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("PK_Category")
                .HasFillFactor(80);

            entity.ToTable("HumanCategory");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.Active).HasDefaultValue(true);
            entity.Property(e => e.SortOrder).HasDefaultValue((byte)0);
            entity.Property(e => e.Title).HasMaxLength(20);
        });

        modelBuilder.Entity<HumanMirEmad>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("HumanMirEmad");

            entity.Property(e => e.BirthDate).HasColumnType("datetime");
            entity.Property(e => e.BirthPlace).HasMaxLength(50);
            entity.Property(e => e.CategoryCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.Comment).HasMaxLength(255);
            entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");
            entity.Property(e => e.DatCont)
                .HasMaxLength(50)
                .HasColumnName("DAT_CONT");
            entity.Property(e => e.EducationId).HasColumnName("EducationID");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Family).HasMaxLength(50);
            entity.Property(e => e.FamilyOld)
                .HasMaxLength(50)
                .HasColumnName("familyOld");
            entity.Property(e => e.FatherName).HasMaxLength(50);
            entity.Property(e => e.FathernameOld).HasMaxLength(50);
            entity.Property(e => e.HumanId)
                .ValueGeneratedOnAdd()
                .HasColumnName("HumanID");
            entity.Property(e => e.HumanName).HasMaxLength(50);
            entity.Property(e => e.Job).HasMaxLength(40);
            entity.Property(e => e.LatinFamily)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LatinName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Mobile)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifyDate).HasColumnType("smalldatetime");
            entity.Property(e => e.NameOld)
                .HasMaxLength(50)
                .HasColumnName("nameOld");
            entity.Property(e => e.NationalId).HasColumnName("NationalID");
            entity.Property(e => e.NationalNo)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.NickName).HasMaxLength(50);
            entity.Property(e => e.OriginalBranchId).HasColumnName("OriginalBranchID");
            entity.Property(e => e.OriginalId).HasColumnName("OriginalID");
            entity.Property(e => e.RegNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.RegPlace).HasMaxLength(50);
            entity.Property(e => e.RegSerial).HasMaxLength(20);
            entity.Property(e => e.RegnoOld)
                .HasMaxLength(50)
                .HasColumnName("regnoOld");
            entity.Property(e => e.RelationshipClientId).HasColumnName("RelationshipClientID");
            entity.Property(e => e.RelationshipTypeId).HasColumnName("RelationshipTypeID");
            entity.Property(e => e.ReligionId).HasColumnName("ReligionID");
            entity.Property(e => e.SpecialCondId).HasColumnName("SpecialCondID");
            entity.Property(e => e.Stime).HasMaxLength(50);
            entity.Property(e => e.TimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.Title).HasMaxLength(255);
            entity.Property(e => e.UserId).HasColumnName("UserID");
        });

        modelBuilder.Entity<Log>(entity =>
        {
            entity.HasKey(e => e.Id).HasFillFactor(80);

            entity.ToTable("Log");

            entity.HasIndex(e => e.CreateDate, "IX_Log_CreateDate").HasFillFactor(80);

            entity.HasIndex(e => e.EntityId, "IX_Log_EntityID").HasFillFactor(80);

            entity.HasIndex(e => e.UserId, "IX_Log_UserID").HasFillFactor(80);

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ActionTypeId).HasColumnName("ActionTypeID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.EntityId).HasColumnName("EntityID");
            entity.Property(e => e.Message).HasMaxLength(1000);
            entity.Property(e => e.RecordId).HasColumnName("RecordID");
            entity.Property(e => e.SubEntityId).HasColumnName("SubEntityID");
            entity.Property(e => e.UserId).HasColumnName("UserID");
        });

        modelBuilder.Entity<OwnerSignature>(entity =>
        {
            entity.HasKey(e => e.Id).HasFillFactor(80);

            entity.ToTable("OwnerSignature");

            entity.Property(e => e.Id)
                .HasComment("شناسه جدول")
                .HasColumnName("ID");
            entity.Property(e => e.ClientId)
                .HasComment("شناسه مشتری حقوقی")
                .HasColumnName("ClientID");
            entity.Property(e => e.ExpireDateSignature)
                .HasComment("تاریخ انقضاء امضاء")
                .HasColumnType("datetime");
            entity.Property(e => e.OwnerSignatureClientId)
                .HasComment("شناسه صاحب امضا حقیقی از جدولclient")
                .HasColumnName("OwnerSignatureClientID");

            entity.HasOne(d => d.Client).WithMany(p => p.OwnerSignatures)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OwnerSignature_Client");
        });

        modelBuilder.Entity<RegSeri>(entity =>
        {
            entity.HasKey(e => e.Id).HasFillFactor(80);

            entity.ToTable("RegSeri");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.Seri).HasMaxLength(5);
        });

        modelBuilder.Entity<RelationshipType>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("PK__Relation__3214EC271996BEB7")
                .HasFillFactor(80);

            entity.ToTable("RelationshipType");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<Religion>(entity =>
        {
            entity.HasKey(e => e.ReligionId).HasFillFactor(80);

            entity.ToTable("Religion");

            entity.Property(e => e.ReligionId).HasColumnName("ReligionID");
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<SpecialCond>(entity =>
        {
            entity.HasKey(e => e.Id).HasFillFactor(80);

            entity.ToTable("SpecialCond");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<VersionInfo>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("VersionInfo");

            entity.HasIndex(e => e.Version, "UC_Version")
                .IsUnique()
                .IsClustered();

            entity.Property(e => e.AppliedOn).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(1024);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
