using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using corenorthwindapi.Models;

namespace corenorthwindapi.Data
{
    public partial class NorthwindDbContext : DbContext
    {
        public NorthwindDbContext()
        {
        }

        public NorthwindDbContext(DbContextOptions<NorthwindDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AlphabeticalListOfProduct> AlphabeticalListOfProducts { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<CategorySalesFor1997> CategorySalesFor1997s { get; set; } = null!;
        public virtual DbSet<CurrentProductList> CurrentProductLists { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<CustomerAndSuppliersByCity> CustomerAndSuppliersByCities { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Invoice> Invoices { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<OrderDetailsExtended> OrderDetailsExtendeds { get; set; } = null!;
        public virtual DbSet<OrderSubtotal> OrderSubtotals { get; set; } = null!;
        public virtual DbSet<OrdersQry> OrdersQries { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductSalesFor1997> ProductSalesFor1997s { get; set; } = null!;
        public virtual DbSet<ProductsAboveAveragePrice> ProductsAboveAveragePrices { get; set; } = null!;
        public virtual DbSet<ProductsByCategory> ProductsByCategories { get; set; } = null!;
        public virtual DbSet<QuarterlyOrder> QuarterlyOrders { get; set; } = null!;
        public virtual DbSet<SalesByCategory> SalesByCategories { get; set; } = null!;
        public virtual DbSet<SalesTotalsByAmount> SalesTotalsByAmounts { get; set; } = null!;
        public virtual DbSet<Shipper> Shippers { get; set; } = null!;
        public virtual DbSet<SnSlaIncident> SnSlaIncidents { get; set; } = null!;
        public virtual DbSet<SnSlaIncidentTemp> SnSlaIncidentTemps { get; set; } = null!;
        public virtual DbSet<SummaryOfSalesByQuarter> SummaryOfSalesByQuarters { get; set; } = null!;
        public virtual DbSet<SummaryOfSalesByYear> SummaryOfSalesByYears { get; set; } = null!;
        public virtual DbSet<Supplier> Suppliers { get; set; } = null!;
        public virtual DbSet<Timesheet> Timesheets { get; set; } = null!;
        public virtual DbSet<TimesheetTemp> TimesheetTemps { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Server=devopsmasterlinuxvm.centralus.cloudapp.azure.com,9005;Database=Northwind;User=sa;Password=passw0rd!;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlphabeticalListOfProduct>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Alphabetical list of products");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CategoryName).HasMaxLength(15);

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductName).HasMaxLength(40);

                entity.Property(e => e.QuantityPerUnit).HasMaxLength(20);

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.UnitPrice).HasColumnType("money");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasIndex(e => e.CategoryName, "CategoryName");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CategoryName).HasMaxLength(15);

                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.Picture).HasColumnType("image");
            });

            modelBuilder.Entity<CategorySalesFor1997>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Category Sales for 1997");

                entity.Property(e => e.CategoryName).HasMaxLength(15);

                entity.Property(e => e.CategorySales).HasColumnType("money");
            });

            modelBuilder.Entity<CurrentProductList>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Current Product List");

                entity.Property(e => e.ProductId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ProductID");

                entity.Property(e => e.ProductName).HasMaxLength(40);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasIndex(e => e.City, "City");

                entity.HasIndex(e => e.CompanyName, "CompanyName");

                entity.HasIndex(e => e.PostalCode, "PostalCode");

                entity.HasIndex(e => e.Region, "Region");

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(5)
                    .HasColumnName("CustomerID")
                    .IsFixedLength();

                entity.Property(e => e.Address).HasMaxLength(60);

                entity.Property(e => e.City).HasMaxLength(15);

                entity.Property(e => e.CompanyName).HasMaxLength(40);

                entity.Property(e => e.ContactName).HasMaxLength(30);

                entity.Property(e => e.ContactTitle).HasMaxLength(30);

                entity.Property(e => e.Country).HasMaxLength(15);

                entity.Property(e => e.Fax).HasMaxLength(24);

                entity.Property(e => e.Phone).HasMaxLength(24);

                entity.Property(e => e.PostalCode).HasMaxLength(10);

                entity.Property(e => e.Region).HasMaxLength(15);
            });

            modelBuilder.Entity<CustomerAndSuppliersByCity>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Customer and Suppliers by City");

                entity.Property(e => e.City).HasMaxLength(15);

                entity.Property(e => e.CompanyName).HasMaxLength(40);

                entity.Property(e => e.ContactName).HasMaxLength(30);

                entity.Property(e => e.Relationship)
                    .HasMaxLength(9)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasIndex(e => e.LastName, "LastName");

                entity.HasIndex(e => e.PostalCode, "PostalCode");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.Address).HasMaxLength(60);

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.City).HasMaxLength(15);

                entity.Property(e => e.Country).HasMaxLength(15);

                entity.Property(e => e.Extension).HasMaxLength(4);

                entity.Property(e => e.FirstName).HasMaxLength(10);

                entity.Property(e => e.HireDate).HasColumnType("datetime");

                entity.Property(e => e.HomePhone).HasMaxLength(24);

                entity.Property(e => e.LastName).HasMaxLength(20);

                entity.Property(e => e.Notes).HasColumnType("ntext");

                entity.Property(e => e.Photo).HasColumnType("image");

                entity.Property(e => e.PhotoPath).HasMaxLength(255);

                entity.Property(e => e.PostalCode).HasMaxLength(10);

                entity.Property(e => e.Region).HasMaxLength(15);

                entity.Property(e => e.Title).HasMaxLength(30);

                entity.Property(e => e.TitleOfCourtesy).HasMaxLength(25);

                entity.HasOne(d => d.ReportsToNavigation)
                    .WithMany(p => p.InverseReportsToNavigation)
                    .HasForeignKey(d => d.ReportsTo)
                    .HasConstraintName("FK_Employees_Employees");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Invoices");

                entity.Property(e => e.Address).HasMaxLength(60);

                entity.Property(e => e.City).HasMaxLength(15);

                entity.Property(e => e.Country).HasMaxLength(15);

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(5)
                    .HasColumnName("CustomerID")
                    .IsFixedLength();

                entity.Property(e => e.CustomerName).HasMaxLength(40);

                entity.Property(e => e.ExtendedPrice).HasColumnType("money");

                entity.Property(e => e.Freight).HasColumnType("money");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.PostalCode).HasMaxLength(10);

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductName).HasMaxLength(40);

                entity.Property(e => e.Region).HasMaxLength(15);

                entity.Property(e => e.RequiredDate).HasColumnType("datetime");

                entity.Property(e => e.Salesperson).HasMaxLength(31);

                entity.Property(e => e.ShipAddress).HasMaxLength(60);

                entity.Property(e => e.ShipCity).HasMaxLength(15);

                entity.Property(e => e.ShipCountry).HasMaxLength(15);

                entity.Property(e => e.ShipName).HasMaxLength(40);

                entity.Property(e => e.ShipPostalCode).HasMaxLength(10);

                entity.Property(e => e.ShipRegion).HasMaxLength(15);

                entity.Property(e => e.ShippedDate).HasColumnType("datetime");

                entity.Property(e => e.ShipperName).HasMaxLength(40);

                entity.Property(e => e.UnitPrice).HasColumnType("money");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasIndex(e => e.CustomerId, "CustomerID");

                entity.HasIndex(e => e.CustomerId, "CustomersOrders");

                entity.HasIndex(e => e.EmployeeId, "EmployeeID");

                entity.HasIndex(e => e.EmployeeId, "EmployeesOrders");

                entity.HasIndex(e => e.OrderDate, "OrderDate");

                entity.HasIndex(e => e.ShipPostalCode, "ShipPostalCode");

                entity.HasIndex(e => e.ShippedDate, "ShippedDate");

                entity.HasIndex(e => e.ShipVia, "ShippersOrders");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(5)
                    .HasColumnName("CustomerID")
                    .IsFixedLength();

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.Freight)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.RequiredDate).HasColumnType("datetime");

                entity.Property(e => e.ShipAddress).HasMaxLength(60);

                entity.Property(e => e.ShipCity).HasMaxLength(15);

                entity.Property(e => e.ShipCountry).HasMaxLength(15);

                entity.Property(e => e.ShipName).HasMaxLength(40);

                entity.Property(e => e.ShipPostalCode).HasMaxLength(10);

                entity.Property(e => e.ShipRegion).HasMaxLength(15);

                entity.Property(e => e.ShippedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Orders_Customers");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Orders_Employees");

                entity.HasOne(d => d.ShipViaNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ShipVia)
                    .HasConstraintName("FK_Orders_Shippers");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProductId })
                    .HasName("PK_Order_Details");

                entity.ToTable("Order Details");

                entity.HasIndex(e => e.OrderId, "OrderID");

                entity.HasIndex(e => e.OrderId, "OrdersOrder_Details");

                entity.HasIndex(e => e.ProductId, "ProductID");

                entity.HasIndex(e => e.ProductId, "ProductsOrder_Details");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Quantity).HasDefaultValueSql("((1))");

                entity.Property(e => e.UnitPrice).HasColumnType("money");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Details_Orders");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Details_Products");
            });

            modelBuilder.Entity<OrderDetailsExtended>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Order Details Extended");

                entity.Property(e => e.ExtendedPrice).HasColumnType("money");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductName).HasMaxLength(40);

                entity.Property(e => e.UnitPrice).HasColumnType("money");
            });

            modelBuilder.Entity<OrderSubtotal>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Order Subtotals");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.Subtotal).HasColumnType("money");
            });

            modelBuilder.Entity<OrdersQry>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Orders Qry");

                entity.Property(e => e.Address).HasMaxLength(60);

                entity.Property(e => e.City).HasMaxLength(15);

                entity.Property(e => e.CompanyName).HasMaxLength(40);

                entity.Property(e => e.Country).HasMaxLength(15);

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(5)
                    .HasColumnName("CustomerID")
                    .IsFixedLength();

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.Freight).HasColumnType("money");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.PostalCode).HasMaxLength(10);

                entity.Property(e => e.Region).HasMaxLength(15);

                entity.Property(e => e.RequiredDate).HasColumnType("datetime");

                entity.Property(e => e.ShipAddress).HasMaxLength(60);

                entity.Property(e => e.ShipCity).HasMaxLength(15);

                entity.Property(e => e.ShipCountry).HasMaxLength(15);

                entity.Property(e => e.ShipName).HasMaxLength(40);

                entity.Property(e => e.ShipPostalCode).HasMaxLength(10);

                entity.Property(e => e.ShipRegion).HasMaxLength(15);

                entity.Property(e => e.ShippedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasIndex(e => e.CategoryId, "CategoriesProducts");

                entity.HasIndex(e => e.CategoryId, "CategoryID");

                entity.HasIndex(e => e.ProductName, "ProductName");

                entity.HasIndex(e => e.SupplierId, "SupplierID");

                entity.HasIndex(e => e.SupplierId, "SuppliersProducts");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.ProductName).HasMaxLength(40);

                entity.Property(e => e.QuantityPerUnit).HasMaxLength(20);

                entity.Property(e => e.ReorderLevel).HasDefaultValueSql("((0))");

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.UnitPrice)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UnitsInStock).HasDefaultValueSql("((0))");

                entity.Property(e => e.UnitsOnOrder).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Products_Categories");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK_Products_Suppliers");
            });

            modelBuilder.Entity<ProductSalesFor1997>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Product Sales for 1997");

                entity.Property(e => e.CategoryName).HasMaxLength(15);

                entity.Property(e => e.ProductName).HasMaxLength(40);

                entity.Property(e => e.ProductSales).HasColumnType("money");
            });

            modelBuilder.Entity<ProductsAboveAveragePrice>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Products Above Average Price");

                entity.Property(e => e.ProductName).HasMaxLength(40);

                entity.Property(e => e.UnitPrice).HasColumnType("money");
            });

            modelBuilder.Entity<ProductsByCategory>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Products by Category");

                entity.Property(e => e.CategoryName).HasMaxLength(15);

                entity.Property(e => e.ProductName).HasMaxLength(40);

                entity.Property(e => e.QuantityPerUnit).HasMaxLength(20);
            });

            modelBuilder.Entity<QuarterlyOrder>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Quarterly Orders");

                entity.Property(e => e.City).HasMaxLength(15);

                entity.Property(e => e.CompanyName).HasMaxLength(40);

                entity.Property(e => e.Country).HasMaxLength(15);

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(5)
                    .HasColumnName("CustomerID")
                    .IsFixedLength();
            });

            modelBuilder.Entity<SalesByCategory>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Sales by Category");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CategoryName).HasMaxLength(15);

                entity.Property(e => e.ProductName).HasMaxLength(40);

                entity.Property(e => e.ProductSales).HasColumnType("money");
            });

            modelBuilder.Entity<SalesTotalsByAmount>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Sales Totals by Amount");

                entity.Property(e => e.CompanyName).HasMaxLength(40);

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.SaleAmount).HasColumnType("money");

                entity.Property(e => e.ShippedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Shipper>(entity =>
            {
                entity.Property(e => e.ShipperId).HasColumnName("ShipperID");

                entity.Property(e => e.CompanyName).HasMaxLength(40);

                entity.Property(e => e.Phone).HasMaxLength(24);
            });

            modelBuilder.Entity<SnSlaIncident>(entity =>
            {
                entity.ToTable("SN_SLA_Incident");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ActualElapsedPercentage).HasColumnName("Actual elapsed percentage");

                entity.Property(e => e.ActualTimeLeft).HasColumnName("Actual time left");

                entity.Property(e => e.EndTime)
                    .HasColumnType("datetime")
                    .HasColumnName("End Time");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Name1).HasMaxLength(255);

                entity.Property(e => e.ShortDescription)
                    .HasMaxLength(255)
                    .HasColumnName("Short description");

                entity.Property(e => e.SlaDefinition)
                    .HasMaxLength(255)
                    .HasColumnName("SLA definition");

                entity.Property(e => e.Stage).HasMaxLength(255);

                entity.Property(e => e.StartTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Start Time");

                entity.Property(e => e.State).HasMaxLength(255);

                entity.Property(e => e.Task).HasMaxLength(255);
            });

            modelBuilder.Entity<SnSlaIncidentTemp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SN_SLA_Incident_temp");

                entity.Property(e => e.ActualElapsedPercentage).HasColumnName("Actual elapsed percentage");

                entity.Property(e => e.ActualTimeLeft).HasColumnName("Actual time left");

                entity.Property(e => e.EndTime)
                    .HasMaxLength(255)
                    .HasColumnName("End Time");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Name1).HasMaxLength(255);

                entity.Property(e => e.ShortDescription)
                    .HasMaxLength(255)
                    .HasColumnName("Short description");

                entity.Property(e => e.SlaDefinition)
                    .HasMaxLength(255)
                    .HasColumnName("SLA definition");

                entity.Property(e => e.Stage).HasMaxLength(255);

                entity.Property(e => e.StartTime)
                    .HasMaxLength(255)
                    .HasColumnName("Start Time");

                entity.Property(e => e.State).HasMaxLength(255);

                entity.Property(e => e.Task).HasMaxLength(255);
            });

            modelBuilder.Entity<SummaryOfSalesByQuarter>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Summary of Sales by Quarter");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ShippedDate).HasColumnType("datetime");

                entity.Property(e => e.Subtotal).HasColumnType("money");
            });

            modelBuilder.Entity<SummaryOfSalesByYear>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Summary of Sales by Year");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ShippedDate).HasColumnType("datetime");

                entity.Property(e => e.Subtotal).HasColumnType("money");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasIndex(e => e.CompanyName, "CompanyName");

                entity.HasIndex(e => e.PostalCode, "PostalCode");

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.Address).HasMaxLength(60);

                entity.Property(e => e.City).HasMaxLength(15);

                entity.Property(e => e.CompanyName).HasMaxLength(40);

                entity.Property(e => e.ContactName).HasMaxLength(30);

                entity.Property(e => e.ContactTitle).HasMaxLength(30);

                entity.Property(e => e.Country).HasMaxLength(15);

                entity.Property(e => e.Fax).HasMaxLength(24);

                entity.Property(e => e.HomePage).HasColumnType("ntext");

                entity.Property(e => e.Phone).HasMaxLength(24);

                entity.Property(e => e.PostalCode).HasMaxLength(10);

                entity.Property(e => e.Region).HasMaxLength(15);
            });

            modelBuilder.Entity<Timesheet>(entity =>
            {
                entity.ToTable("Timesheet");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AttAbsType)
                    .HasMaxLength(255)
                    .HasColumnName("Att_Abs_Type");

                entity.Property(e => e.BasePlus)
                    .HasMaxLength(255)
                    .HasColumnName("Base_Plus");

                entity.Property(e => e.BillableNon)
                    .HasMaxLength(255)
                    .HasColumnName("Billable_Non");

                entity.Property(e => e.ContractNo).HasColumnName("Contract_No");

                entity.Property(e => e.CostCenter).HasColumnName("Cost_Center");

                entity.Property(e => e.CostcenterName)
                    .HasMaxLength(255)
                    .HasColumnName("Costcenter_Name");

                entity.Property(e => e.CostcenterOwner)
                    .HasMaxLength(255)
                    .HasColumnName("Costcenter_Owner");

                entity.Property(e => e.DateApproved)
                    .HasMaxLength(255)
                    .HasColumnName("DATE_Approved");

                entity.Property(e => e.EeGroup)
                    .HasMaxLength(255)
                    .HasColumnName("EE_group");

                entity.Property(e => e.EeSubgroup)
                    .HasMaxLength(255)
                    .HasColumnName("EE_subgroup");

                entity.Property(e => e.EmpNumber).HasColumnName("Emp_number");

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(255)
                    .HasColumnName("Employee_Name");

                entity.Property(e => e.EndTime)
                    .HasMaxLength(255)
                    .HasColumnName("End_Time");

                entity.Property(e => e.FromDate)
                    .HasMaxLength(255)
                    .HasColumnName("From_date");

                entity.Property(e => e.IsParsed)
                    .HasMaxLength(20)
                    .HasColumnName("Is_Parsed")
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.LongText).HasColumnName("Long_Text");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.NbType)
                    .HasMaxLength(255)
                    .HasColumnName("NB_Type");

                entity.Property(e => e.OnOffShore)
                    .HasMaxLength(255)
                    .HasColumnName("On_Off_shore");

                entity.Property(e => e.PortalId).HasMaxLength(255);

                entity.Property(e => e.PremiumId)
                    .HasMaxLength(255)
                    .HasColumnName("Premium_Id");

                entity.Property(e => e.PremiumNumber)
                    .HasMaxLength(255)
                    .HasColumnName("Premium_Number");

                entity.Property(e => e.PreviousWbs)
                    .HasMaxLength(255)
                    .HasColumnName("Previous_Wbs");

                entity.Property(e => e.ProcessStatus)
                    .HasMaxLength(255)
                    .HasColumnName("Process_status");

                entity.Property(e => e.ProcessStatus1)
                    .HasMaxLength(255)
                    .HasColumnName("Process_status1");

                entity.Property(e => e.PublicHoliday)
                    .HasMaxLength(255)
                    .HasColumnName("Public_Holiday");

                entity.Property(e => e.RecWbsElem)
                    .HasMaxLength(255)
                    .HasColumnName("Rec_WBS_elem");

                entity.Property(e => e.ReportingManagerId).HasColumnName("Reporting_Manager_Id");

                entity.Property(e => e.ReportingManagerName)
                    .HasMaxLength(255)
                    .HasColumnName("Reporting_Manager_Name");

                entity.Property(e => e.ResourceCountry)
                    .HasMaxLength(255)
                    .HasColumnName("Resource_Country");

                entity.Property(e => e.ShipToParty).HasColumnName("Ship_to_party");

                entity.Property(e => e.ShipToPartyName)
                    .HasMaxLength(255)
                    .HasColumnName("Ship_to_party_Name");

                entity.Property(e => e.StartTime)
                    .HasMaxLength(255)
                    .HasColumnName("Start_Time");

                entity.Property(e => e.TimeOff)
                    .HasMaxLength(255)
                    .HasColumnName("Time_Off");

                entity.Property(e => e.TimeOffType)
                    .HasMaxLength(255)
                    .HasColumnName("Time_Off_Type");

                entity.Property(e => e.TimeSheetApprEmpId)
                    .HasMaxLength(255)
                    .HasColumnName("TimeSheet_Appr_EmpId");

                entity.Property(e => e.TimeSheetApprName)
                    .HasMaxLength(255)
                    .HasColumnName("TimeSheet_Appr_Name");

                entity.Property(e => e.TimeSheetApprPid)
                    .HasMaxLength(255)
                    .HasColumnName("TimeSheet_Appr_PId");

                entity.Property(e => e.ToDate)
                    .HasMaxLength(255)
                    .HasColumnName("To_Date");

                entity.Property(e => e.TotalRecHrs)
                    .HasMaxLength(255)
                    .HasColumnName("Total_rec_hrs");

                entity.Property(e => e.TotalTargHrs)
                    .HasMaxLength(255)
                    .HasColumnName("Total_targ_hrs");

                entity.Property(e => e.TransferredToCo)
                    .HasMaxLength(255)
                    .HasColumnName("Transferred_to_CO");

                entity.Property(e => e.WbsDescription)
                    .HasMaxLength(255)
                    .HasColumnName("Wbs_Description");

                entity.Property(e => e.WbsPersName)
                    .HasMaxLength(255)
                    .HasColumnName("WBS_Pers_Name");

                entity.Property(e => e.WbsPersPortalid).HasColumnName("WBS_Pers_Portalid");

                entity.Property(e => e.WbsPersResponsible).HasColumnName("WBS_Pers_Responsible");
            });

            modelBuilder.Entity<TimesheetTemp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Timesheet_Temp");

                entity.Property(e => e.AttAbsType)
                    .HasMaxLength(255)
                    .HasColumnName("Att_Abs_Type");

                entity.Property(e => e.BasePlus)
                    .HasMaxLength(255)
                    .HasColumnName("Base_Plus");

                entity.Property(e => e.BillableNon)
                    .HasMaxLength(255)
                    .HasColumnName("Billable_Non");

                entity.Property(e => e.ContractNo).HasColumnName("Contract_No");

                entity.Property(e => e.CostCenter).HasColumnName("Cost_Center");

                entity.Property(e => e.CostcenterName)
                    .HasMaxLength(255)
                    .HasColumnName("Costcenter_Name");

                entity.Property(e => e.CostcenterOwner)
                    .HasMaxLength(255)
                    .HasColumnName("Costcenter_Owner");

                entity.Property(e => e.DateApproved)
                    .HasMaxLength(255)
                    .HasColumnName("DATE_Approved");

                entity.Property(e => e.EeGroup)
                    .HasMaxLength(255)
                    .HasColumnName("EE_group");

                entity.Property(e => e.EeSubgroup)
                    .HasMaxLength(255)
                    .HasColumnName("EE_subgroup");

                entity.Property(e => e.EmpNumber).HasColumnName("Emp_number");

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(255)
                    .HasColumnName("Employee_Name");

                entity.Property(e => e.EndTime)
                    .HasMaxLength(255)
                    .HasColumnName("End_Time");

                entity.Property(e => e.FromDate)
                    .HasMaxLength(255)
                    .HasColumnName("From_date");

                entity.Property(e => e.LongText).HasColumnName("Long_Text");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.NbType)
                    .HasMaxLength(255)
                    .HasColumnName("NB_Type");

                entity.Property(e => e.OnOffShore)
                    .HasMaxLength(255)
                    .HasColumnName("On_Off_shore");

                entity.Property(e => e.PortalId).HasMaxLength(255);

                entity.Property(e => e.PremiumId)
                    .HasMaxLength(255)
                    .HasColumnName("Premium_Id");

                entity.Property(e => e.PremiumNumber)
                    .HasMaxLength(255)
                    .HasColumnName("Premium_Number");

                entity.Property(e => e.PreviousWbs)
                    .HasMaxLength(255)
                    .HasColumnName("Previous_Wbs");

                entity.Property(e => e.ProcessStatus)
                    .HasMaxLength(255)
                    .HasColumnName("Process_status");

                entity.Property(e => e.ProcessStatus1)
                    .HasMaxLength(255)
                    .HasColumnName("Process_status1");

                entity.Property(e => e.PublicHoliday)
                    .HasMaxLength(255)
                    .HasColumnName("Public_Holiday");

                entity.Property(e => e.RecWbsElem)
                    .HasMaxLength(255)
                    .HasColumnName("Rec_WBS_elem");

                entity.Property(e => e.ReportingManagerId).HasColumnName("Reporting_Manager_Id");

                entity.Property(e => e.ReportingManagerName)
                    .HasMaxLength(255)
                    .HasColumnName("Reporting_Manager_Name");

                entity.Property(e => e.ResourceCountry)
                    .HasMaxLength(255)
                    .HasColumnName("Resource_Country");

                entity.Property(e => e.ShipToParty).HasColumnName("Ship_to_party");

                entity.Property(e => e.ShipToPartyName)
                    .HasMaxLength(255)
                    .HasColumnName("Ship_to_party_Name");

                entity.Property(e => e.StartTime)
                    .HasMaxLength(255)
                    .HasColumnName("Start_Time");

                entity.Property(e => e.TimeOff)
                    .HasMaxLength(255)
                    .HasColumnName("Time_Off");

                entity.Property(e => e.TimeOffType)
                    .HasMaxLength(255)
                    .HasColumnName("Time_Off_Type");

                entity.Property(e => e.TimeSheetApprEmpId)
                    .HasMaxLength(255)
                    .HasColumnName("TimeSheet_Appr_EmpId");

                entity.Property(e => e.TimeSheetApprName)
                    .HasMaxLength(255)
                    .HasColumnName("TimeSheet_Appr_Name");

                entity.Property(e => e.TimeSheetApprPid)
                    .HasMaxLength(255)
                    .HasColumnName("TimeSheet_Appr_PId");

                entity.Property(e => e.ToDate)
                    .HasMaxLength(255)
                    .HasColumnName("To_Date");

                entity.Property(e => e.TotalRecHrs)
                    .HasMaxLength(255)
                    .HasColumnName("Total_rec_hrs");

                entity.Property(e => e.TotalTargHrs)
                    .HasMaxLength(255)
                    .HasColumnName("Total_targ_hrs");

                entity.Property(e => e.TransferredToCo)
                    .HasMaxLength(255)
                    .HasColumnName("Transferred_to_CO");

                entity.Property(e => e.WbsDescription)
                    .HasMaxLength(255)
                    .HasColumnName("Wbs_Description");

                entity.Property(e => e.WbsPersName)
                    .HasMaxLength(255)
                    .HasColumnName("WBS_Pers_Name");

                entity.Property(e => e.WbsPersPortalid).HasColumnName("WBS_Pers_Portalid");

                entity.Property(e => e.WbsPersResponsible).HasColumnName("WBS_Pers_Responsible");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
