connectionstring: Scaffold-DbContext "Data Source=LAPTOP-EIA3MJA1\KAOGSQLSERVER;Database=PetMedPlus;Integrated Security=True;TrustServerCertificate=True"
https://www.youtube.com/watch?v=QDCAIYs1Ktk 
https://www.youtube.com/watch?v=o6iqoPDr-nw
https://www.youtube.com/watch?v=7GnXQUMLJzA
https://www.youtube.com/watch?v=fCWvPy-TmR8

under tools nuget package manager in the console insert it. To create the model from the db
Scaffold-DbContext "Data Source=LAPTOP-EIA3MJA1\KAOGSQLSERVER;Database=PetMedPlus;Integrated Security=True;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
update tablé: Scaffold-DbContext "Data Source=LAPTOP-EIA3MJA1\KAOGSQLSERVER;Database=PetMedPlus;Integrated Security=True;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -t tablename -f
update all: update: Scaffold-DbContext "Data Source=LAPTOP-EIA3MJA1\KAOGSQLSERVER;Database=PetMedPlus;Integrated Security=True;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -f

3, Generate DbContext using scaffold command
     Scaffold-DbContext "connectionstring" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

4, Update DbContext object
    Scaffold-DbContext "Connectionstring" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -t tablename -f



frontend con Veu.js
install it and in the folder ´create project with the command vue create projectname