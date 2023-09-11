class CarTireDb : DbContext
{ 
    public CarTireDb(DbContextOptions<CarTireDb> options) 
        : base(options) { } 
 
    public DbSet<CarTire> CarTires => Set<CarTire>(); 
}