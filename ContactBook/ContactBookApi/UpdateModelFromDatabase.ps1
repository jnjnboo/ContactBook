#
# UpdateModelFromDatabae.ps1
# Can be run in Package Manager Console
#
 Scaffold-DbContext "Server=localhost;Database=ContactBook;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Force

 # Then change ContactBookContext.cs constructor to:
 #        public ContactBookContext(DbContextOptions<ContactBookContext> options) : base(options) { }
